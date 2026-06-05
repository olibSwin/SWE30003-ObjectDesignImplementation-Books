namespace FavouriteBooks.Classes
{
    public class PaymentInfo
    {
        public string PaymentMethod { get; }

        public PaymentInfo(string paymentMethod)
        {
            PaymentMethod = paymentMethod;
        }
    }
}
