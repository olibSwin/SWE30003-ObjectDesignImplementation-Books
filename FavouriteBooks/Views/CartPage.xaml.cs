using FavouriteBooks.Classes;
using System.Windows;
using System.Windows.Controls;

namespace FavouriteBooks.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public CartPage()
        {
            InitializeComponent();

            RefreshCart();
        }

        public void RefreshCart()
        {
            CartItemGrid.ItemsSource = null;

            CartItemGrid.ItemsSource = App.CartService.Cart.Items;

            TotalText.Text = $"Total: ${App.CartService.GetSubTotal()}";
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (CartItemGrid.SelectedItem is CartItem item)
            {
                try
                {
                    App.CartService.UpdateCartItemQuantity(item.Book.Id, 1);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Unable to increase item quantity. Max stock reached.", "Insufficient Stock", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                RefreshCart();
            }
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (CartItemGrid.SelectedItem is CartItem item)
            {
                App.CartService.UpdateCartItemQuantity(item.Book.Id, -1);

                RefreshCart();
            }
        }
    }
}
