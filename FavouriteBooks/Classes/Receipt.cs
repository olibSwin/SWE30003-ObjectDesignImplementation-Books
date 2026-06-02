namespace FavouriteBooks.Classes
{
    /// <summary>
    /// Stores receipt information
    /// </summary>
    internal class Receipt(Guid orderId, decimal amountPaid)
    {
        public Guid ReceiptId { get; } = Guid.NewGuid();
        public Guid OrderId { get; } = orderId;
        public DateTime DateIssued { get; } = DateTime.Now;
        public decimal AmountPaid { get; } = amountPaid;

        public override string ToString()
        {
            return $"ReceiptId: {ReceiptId}, OrderId: {OrderId}, Issue Date: {DateIssued}, Total Cost: ${AmountPaid}";
        }
    }
}
