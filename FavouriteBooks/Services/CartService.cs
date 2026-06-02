using FavouriteBooks.Classes;

namespace FavouriteBooks.Services
{
    /// <summary>
    /// Manages the ShoppingCart with validation against any actions
    /// </summary>
    internal class CartService
    {
        private readonly ShoppingCart _cart;

        public CartService()
        {
            _cart = new ShoppingCart();
        }


        /// <summary>
        /// Provided there is sufficient stock, if the book is not already in the cart, a new book is added otherwise it's stock is updated.
        /// </summary>
        /// <param name="book">Book to add or update</param>
        /// <param name="quantity">Quantity to add</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void AddBookToCart(Book book, int quantity)
        {
            CartItem? existingItem = _cart.Items.Find(x => x.Book.Id == book.Id);

            int newQuantity = existingItem != null ? existingItem.Quantity + quantity : quantity;

            if (!InventoryService.HasStock(book, quantity))
            {
                throw new InvalidOperationException("Insuficient stock");
            }

            if (existingItem != null)
            {
                _cart.UpdateQuantity(book.Id, quantity);
                return;
            }

            _cart.AddItem(new CartItem(book, quantity));
        }

        /// <summary>
        /// If the book matching the bookId is in the cart, the CartItem is removed from the cart
        /// </summary>
        /// <param name="bookId">Id of the book to remove</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void RemoveBookFromCart(int bookId)
        {
            CartItem? item = _cart.Items.Find(x => x.Book.Id == bookId) ?? throw new InvalidOperationException("Cannot remove non-existant item");

            _cart.RemoveItem(item);
        }

        /// <summary>
        /// Adds the new qauntity to the current quantity of the CartItem matching the bookId
        /// </summary>
        /// <param name="bookId">Id of the book to update</param>
        /// <param name="quantity">Quantity to add</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void UpdateCartItemQuantity(int bookId, int quantity)
        {
            CartItem? item = _cart.Items.Find(x => x.Book.Id == bookId) ?? throw new InvalidOperationException("Cannot update non-existant book");

            int newQuantity = item.Quantity + quantity;

            // Remove the book if the quantity is negative
            if (newQuantity <= 0)
            {
                RemoveBookFromCart(bookId);
                return;
            }

            _cart.UpdateQuantity(bookId, newQuantity);
        }

        /// <summary>
        /// Gets the cart subtotal
        /// </summary>
        /// <returns>Cart subtotal</returns>
        public decimal GetSubTotal()
        {
            return _cart.GetSubTotal();
        }

        /// <summary>
        /// Removes all items from the cart
        /// </summary>
        public void ClearCart()
        {
            _cart.ClearCart();
        }
    }
}
