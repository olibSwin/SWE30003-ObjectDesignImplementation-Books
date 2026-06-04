using FavouriteBooks.Classes;
using FavouriteBooks.Services;
using System.Windows;
using System.Windows.Controls;

namespace FavouriteBooks.Views
{
    public partial class AccountPage : Page
    {
        private MainWindow _main;
        private AccountService _accountService;
        private class OrderDisplayModel
        {
            public Guid Id { get; set; }
            public DateTime Date { get; set; }
            public decimal Total { get; set; }
            public OrderStatus Status { get; set; }
            public int ItemsCount { get; set; }
        }
        public AccountPage()
            {
                InitializeComponent();

                _main = (MainWindow)Application.Current.MainWindow;
                _accountService = _main.AccountService;

                if (_main.CurrentUser != null)
                {
                    ShowManagePanel();
                }
            }

            private void Login_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    var user = _accountService.Login(
                        LoginEmail.Text,
                        LoginPassword.Password);

                    if (user == null)
                    {
                        MessageBox.Show("Invalid email or password.");
                        return;
                    }

                    _main.CurrentUser = user;
                    ShowManagePanel();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void Register_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    var user = _accountService.Register(
                        RegisterName.Text,
                        RegisterEmail.Text,
                        RegisterPassword.Password,
                        RegisterPhone.Text,
                        RegisterAddress.Text);

                    _main.CurrentUser = user;
                    ShowManagePanel();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            private void ShowManagePanel()
            {
                if (_main?.CurrentUser == null)
                    return;

                LoginPanel.Visibility = Visibility.Collapsed;
                RegisterPanel.Visibility = Visibility.Collapsed;
                AccountScroll.Visibility = Visibility.Visible;

                var user = _main.CurrentUser;

                WelcomeText.Text = $"Welcome, {user.Name}";
                ManageName.Text = user.Name;
                ManagePhone.Text = user.PhoneNumber;
                ManageAddress.Text = user.DeliveryAddress;

                LoadOrderHistory();
            }


            private void SaveChanges_Click(object sender, RoutedEventArgs e)
            {
                _main.CurrentUser.Name = ManageName.Text;
                _main.CurrentUser.PhoneNumber = ManagePhone.Text;
                _main.CurrentUser.DeliveryAddress = ManageAddress.Text;

                _accountService.Save();

                MessageBox.Show("Changes saved successfully.");
            }

            private void Logout_Click(object sender, RoutedEventArgs e)
            {
                _main.CurrentUser = null;
                _main.CartService.ClearCart();

                LoginPanel.Visibility = Visibility.Visible;
                AccountScroll.Visibility = Visibility.Collapsed;


                _accountService.Save();
            }

            private void ShowRegister_Click(object sender, RoutedEventArgs e)
            {
                LoginPanel.Visibility = Visibility.Collapsed;
                RegisterPanel.Visibility = Visibility.Visible;
            }

            private void ShowLogin_Click(object sender, RoutedEventArgs e)
            {
                RegisterPanel.Visibility = Visibility.Collapsed;
                LoginPanel.Visibility = Visibility.Visible;
            }

        private void LoadOrderHistory()
        {
            if (_main.CurrentUser == null)
                return;

            var displayOrders = _main.CurrentUser.OrderHistory
                .Select(o => new OrderDisplayModel
                {
                    Id = o.OrderId,
                    Date = o.OrderDate,
                    Status = o.Status,
                    ItemsCount = o.Items?.Count ?? 0,
                    Total = o.GetTotal()
                })
                .ToList();

            OrderHistoryList.ItemsSource = displayOrders;
        }
    }
    }
