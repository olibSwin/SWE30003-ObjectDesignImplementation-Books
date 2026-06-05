namespace FavouriteBooks.Classes
{
    public class PaymentInfo(string paymentMethod)
    {
        public string PaymentMethod { get; } = paymentMethod;
    }
}
