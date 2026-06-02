using FavouriteBooks.Classes;

namespace FavouriteBooks.Services
{
    /// <summary>
    /// Manages orders
    /// </summary>
    internal class OrderService
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
        public Order PlaceOrder(CustomerAccount customer, ShoppingCart cart)
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

            Payment newPayment = new(newOrder.OrderId, newOrder.GetTotal(), "Credit Card");

            if (!PaymentService.ProcessPayment(newPayment))
            {
                throw new Exception("Payment failed");
            }

            Receipt newReceipt = new(newOrder.OrderId, newPayment.Amount);

            Console.WriteLine("Sending customer receipt...");
            Console.WriteLine(newReceipt.ToString());

            cart.ClearCart();

            return newOrder;
        }
    }
}
