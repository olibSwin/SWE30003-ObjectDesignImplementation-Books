namespace FavouriteBooks.Classes
{
    internal class CartService
    {
        private ShoppingCart cart;
        private InventoryService inventory;

        public CartService()
        {
            cart = new ShoppingCart();
            inventory = new InventoryService();
        }

        public void AddBookToCart(Book book, int quantity)
        {
            /*
             * if book's stock >= quantity:
             *      if book is already in cart:
             *          update cartitem's quantity
             *      else:
             *          add new cartitem
             * else:
             *      throw error
             */
        }

        public void RemoveBookFromCart(int bookId, int quantity)
        {
            /*
             * if book is in cart:
             *      remove cartitem
             * else:
             *      throw error
             */
        }

        public decimal GetSubTotal()
        {
            /*
             * return cart subtotal
             */
            return 0;
        }

        public void ClearCart()
        {
            /*
             * clear cart
             */
        }
    }
}
