using FavouriteBooks.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FavouriteBooks
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal static CartService CartService { get; } = new CartService();
        internal static OrderService OrderService { get; } = new OrderService();
    }

}
