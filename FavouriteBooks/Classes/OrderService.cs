namespace FavouriteBooks.Classes
{
    internal class OrderService
    {
        private readonly InventoryService inventoryService;
        private readonly PaymentService paymentService;

        public OrderService()
        {
            inventoryService = new InventoryService();
            paymentService = new PaymentService();
        }

        public Order PlaceOrder(CustomerAccount customer, ShoppingCart cart)
        {
            /*
             * for each item in cart's items list:
             *      if item's stock is insuficient (using inventoryservice):
             *          return error
             * 
             * create order
             * 
             * for each item in cart's items list:
             *      create orderitem
             *      
             *      add orderitem to order
             *      
             *      reduce stock of item
             * 
             * process payment with payment service
             * 
             * create invoice
             * 
             * create receipt
             * 
             * clear cart
             * 
             * return order
             */
            return null;
        }
    }
}
