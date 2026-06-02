namespace FavouriteBooks.Classes
{
    /// <summary>
    /// Stores payment data
    /// </summary>
    public class Payment(Guid orderId, decimal amount, string paymentMethod)
    {
        public Guid PaymentId { get; } = Guid.NewGuid();
        public Guid OrderId { get; } = orderId;
        public decimal Amount { get; } = amount;
        public DateTime PaymentDate { get; } = DateTime.Now;
        public string PaymentMethod { get; } = paymentMethod;
    }
}
