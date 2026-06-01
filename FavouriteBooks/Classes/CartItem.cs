namespace FavouriteBooks.Classes
{
    internal class CartItem
    {
        public Book Book { get; }
        public int Quantity { get; set; }

        public CartItem(Book book, int quantity)
        {
            Book = book;
            Quantity = quantity;
        }

        public decimal GetSubTotal()
        {
            return Book.Price * Quantity;
        }
    }
}
