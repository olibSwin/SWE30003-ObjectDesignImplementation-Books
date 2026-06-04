using FavouriteBooks.Classes;

namespace FavouriteBooks.Services
{
    /// <summary>
    /// Manages the ShoppingCart with validation against any actions
    /// </summary>
    public class CartService
    {
        public readonly ShoppingCart Cart;

        public CartService()
        {
            Cart = new ShoppingCart();
        }


        /// <summary>
        /// Provided there is sufficient stock, if the book is not already in the cart, a new book is added otherwise it's stock is updated.
        /// </summary>
        /// <param name="book">Book to add or update</param>
        /// <param name="quantity">Quantity to add</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddBookToCart(Book book, int quantity)
        {
            CartItem? existingItem = Cart.Items.Find(x => x.Book.Id == book.Id);

            int newQuantity = existingItem != null ? existingItem.Quantity + quantity : quantity;

            if (!InventoryService.HasStock(book, newQuantity))
            {
                throw new InvalidOperationException("Insuficient stock");
            }

            if (existingItem != null)
            {
                Cart.UpdateQuantity(book.Id, newQuantity);
                return;
            }

            Cart.AddItem(new CartItem(book, newQuantity));
        }

        /// <summary>
        /// If the book matching the bookId is in the cart, the CartItem is removed from the cart
        /// </summary>
        /// <param name="bookId">Id of the book to remove</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveBookFromCart(int bookId)
        {
            CartItem? item = Cart.Items.Find(x => x.Book.Id == bookId) ?? throw new InvalidOperationException("Cannot remove non-existant item");

            Cart.RemoveItem(item);
        }

        /// <summary>
        /// Adds the new qauntity to the current quantity of the CartItem matching the bookId
        /// </summary>
        /// <param name="bookId">Id of the book to update</param>
        /// <param name="quantity">Quantity to add</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void UpdateCartItemQuantity(int bookId, int quantity)
        {
            CartItem? item = Cart.Items.Find(x => x.Book.Id == bookId) ?? throw new InvalidOperationException("Cannot update non-existant book");

            int newQuantity = item.Quantity + quantity;

            // Remove the book if the quantity is negative
            if (newQuantity <= 0)
            {
                RemoveBookFromCart(bookId);
                return;
            }

            if (!InventoryService.HasStock(item.Book, newQuantity))
            {
                throw new InvalidOperationException("Insuficient stock");
            }

            Cart.UpdateQuantity(bookId, newQuantity);
        }

        /// <summary>
        /// Removes all items from the cart
        /// </summary>
        public void ClearCart()
        {
            Cart.ClearCart();
        }

        /// <summary>
        /// Gets the cart subtotal
        /// </summary>
        /// <returns>Cart subtotal</returns>
        public decimal GetSubTotal()
        {
            return Cart.GetSubTotal();
        }

        /// <summary>
        /// Gets the number of books in the cart. Adds quantities of all cart items
        /// </summary>
        /// <returns>Item count</returns>
        public int GetItemCount()
        {
            int itemCount = 0;

            foreach (CartItem item in Cart.Items)
            {
                itemCount += item.Quantity;
            }

            return itemCount;
        }
    }
}
