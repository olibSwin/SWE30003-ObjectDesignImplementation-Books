public class Book
{ 
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; private set; }
    public string Description { get; set; }
    public int Stock { get; set; }

    public Book(string title, string author, string isbn, decimal price, int stock)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Price = price;
        Stock = stock;
    }
}