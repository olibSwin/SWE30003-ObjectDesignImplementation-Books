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
            /*
             * add cartitem to items list with book and quantity
             */
        }

        public void RemoveBook(int bookId)
        {
            /*
             * remove cartitem from items list
             */
        }

        public void UpdateQuantity(int bookId, int quantity)
        {
            /*
             * find cartitem in items list
             * set cartitems quantity to quantity
             */
        }

        public void ClearCart()
        {
            /*
             * reset items list to empty list
             */
        }

        public decimal GetTotal()
        {
            /*
             * total = 0
             * 
             * for each item in items list:
             *      total += item's subtotal
             * 
             * return total
             */
            return 0;
        }
    }
}
