namespace FavouriteBooks.Classes
{
    internal class ShoppingCart
    {
        public List<CartItem> Items { get; set; }

        public ShoppingCart()
        {
            Items = [];
        }

        public void AddBook(Book book, int quantity)
        {
            CartItem newItem = new CartItem(book, quantity);

            Items.Add(newItem);
        }

        public void RemoveBook(int bookId)
        {
            CartItem? item = Items.Find(x => x.Book.Id == bookId);

            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public void UpdateQuantity(int bookId, int quantity)
        {
            CartItem? item = Items.Find(x => x.Book.Id == bookId);

            if (item != null)
            {
                item.Quantity = quantity;
            }
        }

        public void ClearCart()
        {
            Items.Clear();
        }

        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (CartItem item in Items)
            {
                total += item.GetSubTotal();
            }

            return total;
        }
    }
}
