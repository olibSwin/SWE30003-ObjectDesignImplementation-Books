namespace FavouriteBooks.Classes
{
    internal class Invoice
    {
        public int InvoiceId { get; }
        public int OrderId { get; }
        public DateTime DateIssued { get; }
        public decimal TotalAmount { get; }

        public Invoice(int invoiceId, int orderId, decimal totalAmount)
        {
            InvoiceId = invoiceId;
            OrderId = orderId;
            DateIssued = DateTime.Now;
            TotalAmount = totalAmount;
        }
    }
}
