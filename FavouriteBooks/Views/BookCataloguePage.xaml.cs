using FavouriteBooks.Services;
using System.Windows;
using System.Windows.Controls;

namespace FavouriteBooks.Views
{
    /// <summary>
    /// Interaction logic for BookCataloguePage.xaml
    /// </summary>
    public partial class BookCataloguePage : Page
    {
        private readonly CartService _cartService;
        private readonly CustomerAccount _customer;
        public BookCataloguePage(CartService cartService)
        {
            InitializeComponent();

            _cartService = cartService;
            _customer = new CustomerAccount(1, "TestUser", "test@email.com", "password");
            _customer.PhoneNumber = "1234567890";
            _customer.DeliveryAddress = "123 street, city, state, country";

            BooksGrid.ItemsSource = SampleData.GetBooks();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (BooksGrid.SelectedItem is not Book selectedBook)
            {
                return;
            }

            try
            {
                _cartService.AddBookToCart(selectedBook, 1);
                MessageBox.Show("Book added to cart");
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Unable to add book. Max stock reached.", "Insufficient Stock", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ViewCart_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage(_cartService, _customer));
        }
    }
}
