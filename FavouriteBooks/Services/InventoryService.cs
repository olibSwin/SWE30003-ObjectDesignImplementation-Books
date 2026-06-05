using FavouriteBooks.Classes;

namespace FavouriteBooks.Services
{
    /// <summary>
    /// Manages the inventory
    /// </summary>
    public class InventoryService
    {
        public InventoryService() { }

        /// <summary>
        /// Checks if a book has equal or more than the request stock amount
        /// </summary>
        /// <param name="book">Book to check</param>
        /// <param name="quantity">Stock quantity to check</param>
        /// <returns>If quantity of stock is available</returns>
        public static bool HasStock(Book book, int quantity)
        {
            return book.Stock >= quantity;
        }

        /// <summary>
        /// Reduces the stock of the book by the requested quantity
        /// </summary>
        /// <param name="book">Book to update</param>
        /// <param name="quantity">Quantity to reduce by</param>
        public static void ReduceStock(Book book, int quantity)
        {
            book.Stock -= quantity;
        }

        /// <summary>
        /// Increases the stock of the book by the requested quantity
        /// </summary>
        /// <param name="book">Book to update</param>
        /// <param name="quantity">Quantity to increase by</param>
        public static void IncreaseStock(Book book, int quantity)
        {
            book.Stock += quantity;
        }
    }
}
