using FavouriteBooks.Classes;
using FavouriteBooks.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FavouriteBooks.Views
{
    public partial class BookCataloguePage : Page
    {
        private BookCatalogue _catalogue = BookCatalogue.Instance;
        private CartService _cartService;
        private CustomerAccount _currentUser;

        public BookCataloguePage()
        {
            InitializeComponent();
            MainWindow main = Application.Current.MainWindow as MainWindow;
            _currentUser = main.CurrentUser;
            _cartService = main.CartService;
            BookList.ItemsSource = _catalogue.GetAllBooks().ToList();
            UpdateCartDisplay();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchBox.Text;
            if (string.IsNullOrEmpty(query))
                BookList.ItemsSource = _catalogue.GetAllBooks().ToList();
            else
                BookList.ItemsSource = _catalogue.SearchBooks(query).ToList();
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Please log in first.");
                NavigationService.Navigate(new AccountPage());
                return;
            }

            NavigationService.Navigate(
                new CartPage(_cartService, _currentUser)
            );
        }

        private void UpdateCartDisplay()
        {
            CartItemCount.Text = $"{_cartService.GetItemCount()} items";
            CartTotal.Text = $"${_cartService.GetSubTotal():F2}";
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Book selectedBook = button.Tag as Book;

            if (_currentUser == null)
            {
                MessageBox.Show("Please log in to add books to your cart.");
                NavigationService.Navigate(new AccountPage());
                return;
            }

            try
            {
                _cartService.AddBookToCart(selectedBook, 1);
                MessageBox.Show($"{selectedBook.Title} added to cart!");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateCartDisplay();
        }
    }
}