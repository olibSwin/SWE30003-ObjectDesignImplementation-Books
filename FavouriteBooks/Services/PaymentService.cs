using FavouriteBooks.Classes;

namespace FavouriteBooks.Services
{
    /// <summary>
    /// Processes payments
    /// </summary>
    public class PaymentService
    {
        public PaymentService() { }

        /// <summary>
        /// Processes the payment. For the purpose of this assignment, the processing is simulated
        /// </summary>
        /// <param name="payment">Payment details</param>
        /// <returns>Success value</returns>
        public static bool ProcessPayment(Payment payment)
        {
            // Pretend processing

            Console.WriteLine("Processing payment...");
            Console.WriteLine(payment);

            bool result = true;

            return result;
        }
    }
}
