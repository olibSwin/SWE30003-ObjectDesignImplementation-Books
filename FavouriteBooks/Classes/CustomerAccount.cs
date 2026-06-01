using System.Security.Cryptography;
using System.Text;

public class CustomerAccount 
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string DeliveryAddress { get; set; }
    //private List<Order> OrderHistory { get; set; }
    private string _hashedPassword;

    public CustomerAccount(string name, string email, string password)
    {
        Name = name;
        Email = email;
        _hashedPassword = HashPassword(password);
        OrderHistory = new List<Order>();
    }

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
        return _hashedPassword == HashPassword(password);
    }
    /*
    public void AddOrder(Order order)
    {
        OrderHistory.Add(order);
    }
    */
}