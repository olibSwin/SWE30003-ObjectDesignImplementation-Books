namespace FavouriteBooks.Classes
{
    /// <summary>
    /// Stores the data of an item in an order
    /// </summary>
    public class OrderItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal BookPurchasePrice { get; set; }

        // REQUIRED for JSON deserialization
        public OrderItem() { }

        public OrderItem(Book book, int quantity, decimal purchasePrice)
        {
            Book = book;
            Quantity = quantity;
            BookPurchasePrice = purchasePrice;
        }

        public decimal SubTotal
        {
            get
            {
                return BookPurchasePrice * Quantity;
            }
        }
    }
}