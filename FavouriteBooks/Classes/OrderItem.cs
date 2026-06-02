namespace FavouriteBooks.Classes
{
    /// <summary>
    /// Stores the data of an item in an order
    /// </summary>
    public class OrderItem(Book book, int quantity, decimal purchasePrice)
    {
        public Book Book { get; } = book;
        public int Quantity { get; } = quantity;

        public decimal BookPurchasePrice { get; } = purchasePrice;

        /// <summary>
        /// Gets the subtotal cost of the order item
        /// </summary>
        /// <returns>Book purchase price times quantity</returns>
        public decimal GetSubTotal()
        {
            return BookPurchasePrice * Quantity;
        }
    }
}
