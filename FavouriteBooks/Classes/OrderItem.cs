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

        public decimal SubTotal
        {
            get
            {
                return BookPurchasePrice * Quantity;
            }
        }
    }
}
