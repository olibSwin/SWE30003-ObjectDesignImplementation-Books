using FavouriteBooks.Classes;
using System.Security.Cryptography;
using System.Text;
namespace FavouriteBooks.Classes
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public string PasswordHash { get; set; }
        public bool IsLocked { get; set; }
        public int FailedLoginAttempts { get; set; }
        public List<Order> OrderHistory { get; set; } = [];
        public List<Receipt> ReceiptList { get; set; } = [];


        public CustomerAccount(string name, string email, string password, string phoneNumber, string deliveryAddress)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            DeliveryAddress = deliveryAddress;

            PasswordHash = HashPassword(password);

            FailedLoginAttempts = 0;
            IsLocked = false;
        }

        public CustomerAccount() { }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(
                    Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        public bool VerifyPassword(string password)
        {
            return PasswordHash == HashPassword(password);
        }
        
        // Calling this after an orderaaa is processed or somewhere later
        public void AddOrder(Order order)
        {
            OrderHistory.Add(order);
        }
        
        public void RegisterFailedLogin()
        {
            FailedLoginAttempts++;

            if (FailedLoginAttempts >= 3)
                IsLocked = true;
        }

        public void ResetLoginAttempts()
        {
            FailedLoginAttempts = 0;
        }
    }
}