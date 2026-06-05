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
        private readonly CartService _cartService;
        private readonly CustomerAccount _customer;
        public CartPage(CartService cartService, CustomerAccount customer)
        {
            InitializeComponent();

            _cartService = cartService;
            _customer = customer;

            RefreshCart();
        }

        public void RefreshCart()
        {
            CartItemGrid.ItemsSource = null;

            CartItemGrid.ItemsSource = _cartService.Cart.Items;

            TotalText.Text = $"SubTotal: ${_cartService.GetSubTotal()}";
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (_cartService.Cart.Items.Count > 0)
            {
                NavigationService.Navigate(new CheckoutPage(_cartService, _customer));
            }
            else
            {
                MessageBox.Show("Cart is empty", "Unable to checkout", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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

        private void RemoveAll_Click(object sender, RoutedEventArgs e)
        {
            if (CartItemGrid.SelectedItem is CartItem item)
            {
                _cartService.RemoveBookFromCart(item.Book.Id);

                RefreshCart();
            }
        }
    }
}
