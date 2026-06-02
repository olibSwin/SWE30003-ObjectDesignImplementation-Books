using FavouriteBooks.Classes;
using FavouriteBooks.Services;
using System.Windows;
using System.Windows.Controls;

namespace FavouriteBooks.Views
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        private CartService _cartService;
        public CartPage(CartService cartService)
        {
            InitializeComponent();

            _cartService = cartService;

            RefreshCart();
        }

        public void RefreshCart()
        {
            CartItemGrid.ItemsSource = null;

            CartItemGrid.ItemsSource = _cartService.Cart.Items;

            TotalText.Text = $"Total: ${_cartService.GetSubTotal()}";
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
                    _cartService.UpdateCartItemQuantity(item.Book.Id, 1);
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
                _cartService.UpdateCartItemQuantity(item.Book.Id, -1);

                RefreshCart();
            }
        }
    }
}
