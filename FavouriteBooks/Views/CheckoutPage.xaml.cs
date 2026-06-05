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
            OrderTotalCost.Text = $"${_cartService.Cart.GetSubTotal() + (_cartService.GetItemCount() * 2.5m)}";

            paymentMethods = ["Credit Card", "Debit Card", "Apple Pay", "Google Pay", "PayPal"];

            PaymentMethodDropdown.ItemsSource = paymentMethods;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if (PaymentMethodDropdown.SelectedItem is string selectedPayementMethod)
            {
                PaymentInfo newPaymentInfo = new(selectedPayementMethod.ToString());

                Order? newOrder = null;

                try
                {
                    newOrder = OrderService.PlaceOrder(_customer, _cartService.Cart, newPaymentInfo);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message + ". The order has been cancelled", "Insufficient Stock", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("The payment failed and the order has been cancelled", "Payment Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (newOrder is not null)
                {
                    NavigationService.Navigate(new OrderCompletePage(_customer, newOrder));
                }
            }
            else
            {
                MessageBox.Show("Please select a payment method", "No Payment Method Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
