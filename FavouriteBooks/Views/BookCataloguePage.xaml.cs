using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FavouriteBooks.Classes;

namespace FavouriteBooks.Views
{
    /// <summary>
    /// Interaction logic for BookCataloguePage.xaml
    /// </summary>
    public partial class BookCataloguePage : Page
    {
        private BookCatalogue _catalogue = BookCatalogue.Instance;
        //private ShoppingCart _cart = new ShoppingCart();
        private CustomerAccount _currentUser;


        public BookCataloguePage()
        {
            InitializeComponent();
            MainWindow main = Application.Current.MainWindow as MainWindow;
            _currentUser = main.CurrentUser;
            BookList.ItemsSource = _catalogue.GetAllBooks().ToList();
            //UpdateCartDisplay();
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
            // TODO: Navigate to ShoppingCartPage
        }
        /*
        private void UpdateCartDisplay()
        {
            CartItemCount.Text = $"{_cart.Items.Count} items";
            CartTotal.Text = $"${_cart.GetSubTotal():F2}";
        }
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Book selectedBook = button.Tag as Book;

            // Check if user is logged in
            if (_currentUser == null)
            {
                MessageBox.Show("Please log in to add books to your cart.");
                NavigationService.Navigate(new AccountPage());
                return;
            }

            // Check if book is already in cart
            CartItem existingItem = _cart.Items.Find(x => x.Book.Id == selectedBook.Id);

            if (existingItem != null)
            {
                // Increase quantity if already in cart
                _cart.UpdateQuantity(selectedBook.Id, existingItem.Quantity + 1);
                MessageBox.Show($"Added another copy of {selectedBook.Title} to cart.");
            }
            else
            {
                // Add new cart item
                _cart.AddItem(new CartItem(selectedBook, 1));
                MessageBox.Show($"{selectedBook.Title} added to cart!");
            }
            UpdateCartDisplay();
        
        }
        */
        private void AddToCart_Click(object sender, RoutedEventArgs e)
        { }
    }
}
