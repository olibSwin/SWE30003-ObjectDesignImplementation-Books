using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new HomePage()); // load HomePage on startup
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new HomePage());
        }

        private void Catalogue_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BookCataloguePage());
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new AccountPage());
        }
    }
}