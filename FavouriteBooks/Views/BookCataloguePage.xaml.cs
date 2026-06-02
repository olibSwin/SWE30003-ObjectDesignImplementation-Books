using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace FavouriteBooks.Views
{
    /// <summary>
    /// Interaction logic for BookCataloguePage.xaml
    /// </summary>
    public partial class BookCataloguePage : Page
    {
        private BookCatalogue _catalogue = BookCatalogue.Instance;

        public BookCataloguePage()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchBox.Text;
            if (string.IsNullOrEmpty(query))
                BookList.ItemsSource = _catalogue.GetAllBooks();
            else
                BookList.ItemsSource = _catalogue.SearchBooks(query);
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Navigate to ShoppingCartPage
        }
    }
}
