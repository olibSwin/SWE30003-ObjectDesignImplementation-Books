using FavouriteBooks.Classes;
using System.Windows;
using System.Windows.Controls;

namespace FavouriteBooks.Views
{
    /// <summary>
    /// Interaction logic for OrderCompletePage.xaml
    /// </summary>
    public partial class OrderCompletePage : Page
    {
        private readonly CustomerAccount _customer;
        private readonly Order _order;
        private readonly Receipt? _receipt;
        public OrderCompletePage(CustomerAccount customer, Order order)
        {
            InitializeComponent();

            _customer = customer;
            _order = order;

            if (_customer.ReceiptList.Find(x => x.OrderId == _order.OrderId) is Receipt receipt)
            {
                _receipt = receipt;
            }
            else
            {
                MessageBox.Show("No receipt for this order", "Missing Receipt", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            OrderItemList.ItemsSource = _order.Items;
            OrderDate.Text = _order.OrderDate.ToString();
            OrderStatusInfo.Text = _order.Status.ToString();
            ShippingCost.Text = $"${_order.GetItemCount() * 2.5m}";

            ReceiptId.Text = _receipt.ReceiptId.ToString();
            ReceiptDate.Text = _receipt.DateIssued.ToString();
            ReceiptPaid.Text = $"${_receipt.AmountPaid.ToString()}";
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            while (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
