namespace FavouriteBooks.Classes
{
    internal class OrderItem
    {
        public Book Book { get; }
        public int Quantity { get; }

        public decimal BookPurchasePrice { get; }

        public OrderItem(Book book, int quantity, decimal purchasePrice)
        {
            Book = book;
            Quantity = quantity;
            BookPurchasePrice = purchasePrice;
        }

        public decimal GetSubTotal()
        {
            return BookPurchasePrice * Quantity;
        }
    }
}
