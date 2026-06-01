namespace FavouriteBooks.Classes
{
    internal class Receipt
    {
        public int ReceiptId { get; }
        public int OrderId { get; }
        public DateTime DateIssued { get; }
        public decimal AmountPaid { get; }

        public Receipt(int receiptId, int orderId, decimal amountPaid)
        {
            ReceiptId = receiptId;
            OrderId = orderId;
            DateIssued = DateTime.Now;
            AmountPaid = amountPaid;
        }
    }
}
