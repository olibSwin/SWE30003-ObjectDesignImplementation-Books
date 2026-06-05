namespace FavouriteBooks.Classes
{
    /// <summary>
    /// Stores a book and quantity for the shopping cart
    /// </summary>
    public class CartItem(Book book, int quantity)
    {
        public Book Book { get; } = book;
        public int Quantity { get; set; } = quantity;

        /// <summary>
        /// Gets the subtotal of the cart item
        /// </summary>
        /// <returns>Current book price times quantity</returns>
        public decimal GetSubTotal()
        {
            return Book.Price * Quantity;
        }
    }
}
