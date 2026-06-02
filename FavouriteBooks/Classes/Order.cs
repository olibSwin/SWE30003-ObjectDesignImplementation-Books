namespace FavouriteBooks.Classes
{
    /// <summary>
    /// Stores the data of a placed order
    /// </summary>
    internal class Order(CustomerAccount customer)
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
                total += item.GetSubTotal();
            }

            return total;
        }
    }

    /// <summary>
    /// Status of the order
    /// </summary>
    enum OrderStatus
    {
        Pending,
        Paid,
        Shipped,
        Completed
    }
}
