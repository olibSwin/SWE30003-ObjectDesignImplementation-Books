namespace FavouriteBooks.Classes
{
    /// <summary>
    /// Stores the data of a placed order
    /// </summary>
    public class Order(CustomerAccount customer)
    {
        public Guid OrderId { get; } = Guid.NewGuid();
        public CustomerAccount Customer { get; } = customer;
        public DateTime OrderDate { get; } = DateTime.Now;
        public List<OrderItem> Items { get; set; } = [];
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        /// <summary>
        /// Gets the total cost of the order
        /// </summary>
        /// <returns>Total cost of the order</returns>
        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (OrderItem item in Items)
            {
                total += item.SubTotal + (item.Quantity * 2.5m);
            }

            return total;
        }

        /// <summary>
        /// Gets the number of books in the order. Adds quantities of all order items
        /// </summary>
        /// <returns>Item count</returns>
        public int GetItemCount()
        {
            int itemCount = 0;

            foreach (OrderItem item in Items)
            {
                itemCount += item.Quantity;
            }

            return itemCount;
        }
    }

    /// <summary>
    /// Status of the order
    /// </summary>
    public enum OrderStatus
    {
        Pending,
        Paid,
        Completed
    }
}
