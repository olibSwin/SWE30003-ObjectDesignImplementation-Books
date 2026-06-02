using FavouriteBooks.Services;
using System.Windows;

namespace FavouriteBooks.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CartService CartService { get; }

        public MainWindow()
        {
            InitializeComponent();

            CartService = new();

            MainFrame.Navigate(new BookCataloguePage(CartService));
        }
    }
}