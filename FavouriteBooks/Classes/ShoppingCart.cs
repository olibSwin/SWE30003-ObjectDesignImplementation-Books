namespace FavouriteBooks.Classes
{
    /// <summary>
    /// Manages the items currently in the ShoppingCart
    /// </summary>
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }

        public ShoppingCart()
        {
            Items = [];
        }

        /// <summary>
        /// Add a new CartItem to the cart
        /// </summary>
        /// <param name="newItem">CartItem to add</param>
        public void AddItem(CartItem newItem)
        {
            Items.Add(newItem);
        }

        /// <summary>
        /// Removes a CartItem from the cart
        /// </summary>
        /// <param name="item">CartItem to remove</param>
        public void RemoveItem(CartItem item)
        {
            Items.Remove(item);
        }

        /// <summary>
        /// Updates the quantity of a CartItem with the matching bookId
        /// </summary>
        /// <param name="bookId">Id of the book to update</param>
        /// <param name="newQuantity">New quantity</param>
        public void UpdateQuantity(int bookId, int newQuantity)
        {
            CartItem? item = Items.Find(x => x.Book.Id == bookId);

            if (item != null)
            {
                item.Quantity = newQuantity;
            }
        }

        /// <summary>
        /// Removes all items from the cart
        /// </summary>
        public void ClearCart()
        {
            Items.Clear();
        }

        /// <summary>
        /// Get the current total cost of all the items in the cart
        /// </summary>
        /// <returns>Current total cost</returns>
        public decimal GetSubTotal()
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
