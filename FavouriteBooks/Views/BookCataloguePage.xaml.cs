using FavouriteBooks.Services;
using System.Windows;
using System.Windows.Controls;
using FavouriteBooks;

namespace FavouriteBooks.Views
{
    /// <summary>
    /// Interaction logic for BookCataloguePage.xaml
    /// </summary>
    public partial class BookCataloguePage : Page
    {
        private CartService _cartService;

        public BookCataloguePage()
        {
            InitializeComponent();
            _cartService = App.CartService;

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
            NavigationService.Navigate(new CartPage());
        }
    }
}
