namespace FavouriteBooks.Classes
{
    internal class Payment
    {
        public int PaymentId { get; }
        public int OrderId { get; }
        public decimal Amount { get; }
        public DateTime PaymentDate { get; }
        public string PaymentMethod { get; }

        public Payment(int paymentId, int orderId, decimal amount, string paymentMethod)
        {
            PaymentId = paymentId;
            OrderId = orderId;
            Amount = amount;
            PaymentDate = DateTime.Now;
            PaymentMethod = paymentMethod;
        }
    }
}
