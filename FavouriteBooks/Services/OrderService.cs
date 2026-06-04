using FavouriteBooks.Classes;

namespace FavouriteBooks.Services
{
    /// <summary>
    /// Manages orders
    /// </summary>
    public class OrderService
    {
        public OrderService()
        {
        }

        /// <summary>
        /// Validates an order before processing payment and sending an invoice and receipt
        /// </summary>
        /// <param name="customer">Customer who placed order</param>
        /// <param name="cart">Current shopping cart</param>
        /// <returns>Order details</returns>
        public static Order PlaceOrder(CustomerAccount customer, ShoppingCart cart, PaymentInfo paymentInfo)
        {
            Order newOrder = new(customer);

            foreach (CartItem item in cart.Items)
            {
                // Check stock for cart items
                if (!InventoryService.HasStock(item.Book, item.Quantity))
                {
                    throw new InvalidOperationException($"{item.Book.Title}'s stock ({item.Book.Stock}) is less than the requested amount ({item.Quantity})");
                }

                // Create and add new item
                OrderItem newItem = new(item.Book, item.Quantity, item.Book.Price);

                newOrder.Items.Add(newItem);

                InventoryService.ReduceStock(item.Book, item.Quantity);
            }

            Payment newPayment = new(newOrder.OrderId, newOrder.GetTotal(), paymentInfo);

            if (!PaymentService.ProcessPayment(newPayment))
            {
                CancelOrder(newOrder);
                throw new Exception("Payment failed");
            }

            newOrder.Status = OrderStatus.Paid;

            Receipt newReceipt = new(newOrder.OrderId, newPayment.Amount);

            customer.ReceiptList.Add(newReceipt);

            cart.ClearCart();

            newOrder.Status = OrderStatus.Completed;

            return newOrder;
        }

        public static void CancelOrder(Order order)
        {
            foreach (OrderItem item in order.Items)
            {
                InventoryService.IncreaseStock(item.Book, item.Quantity);
            }
        }
    }
}
