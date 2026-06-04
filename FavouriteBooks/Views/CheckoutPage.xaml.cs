using FavouriteBooks.Classes;
using FavouriteBooks.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace FavouriteBooks.Views
{
    /// <summary>
    /// Interaction logic for CheckoutPage.xaml
    /// </summary>
    public partial class CheckoutPage : Page
    {
        //private Order currentOrder;
        private readonly CartService _cartService;
        private readonly CustomerAccount _customer;
        private readonly ObservableCollection<string> paymentMethods;
        public CheckoutPage(CartService cartService, CustomerAccount customer)
        {
            InitializeComponent();

            _customer = customer;
            _cartService = cartService;

            // Set customer info
            CustomerName.Text = _customer.Name;
            CustomerEmail.Text = _customer.Email;
            CustomerPhone.Text = _customer.PhoneNumber;
            CustomerAddr.Text = _customer.DeliveryAddress;

            // Set order info
            OrderItemCount.Text = _cartService.GetItemCount().ToString();
            OrderSubtotal.Text = $"${_cartService.Cart.GetSubTotal()}";
            OrderShippingCost.Text = $"${_cartService.GetItemCount() * 2.5m}";

            paymentMethods = ["Credit Card", "Debit Card", "Apple Pay", "Google Pay", "PayPal"];

            PaymentMethodDropdown.ItemsSource = paymentMethods;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
