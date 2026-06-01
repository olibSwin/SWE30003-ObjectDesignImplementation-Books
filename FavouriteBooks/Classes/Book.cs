public class Book
{ 
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; private set; }
    public int Stock { get; set; }
    public string Description { get; set; }

    public Book(int id, string title, string author, string isbn, decimal price, int stock, string description)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        Price = price;
        Stock = stock;
        Description = description;
    }
}