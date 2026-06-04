using System.Web;
namespace FavouriteBooks.Classes
{
    public class Book
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; private set; }
        public int Stock { get; set; }
        //Later when displaying books check if descritiion is empty then display message (no desc availble)
        public string Description { get; set; } = string.Empty;

        public Book(string title, string author, string isbn, decimal price, int stock)
        {
            Id = _nextId++;
            Title = title;
            Author = author;
            ISBN = isbn;
            Price = price;
            Stock = stock;
        }
    }
}