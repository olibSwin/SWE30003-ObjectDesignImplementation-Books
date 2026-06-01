namespace FavouriteBooks.Classes
{
    internal class Order
    {
        public int OrderId { get; }
        public CustomerAccount Customer {  get; }
        public DateTime OrderDate { get; }
        public List<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public Order(int orderId, CustomerAccount customer)
        {
            OrderId = orderId;
            Customer = customer;
            Items = [];
            OrderDate = DateTime.Now;
        }

        public decimal GetTotal()
        {
            /*
             * total = 0
             * 
             * for each orderitem in items list:
             *      total += item's subtotal
             * 
             * return total
             */
            return 0;
        }
    }

    enum OrderStatus
    {
        Pending,
        Paid,
        Shipped,
        Completed
    }
}
