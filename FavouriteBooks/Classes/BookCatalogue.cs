using System.Linq;
namespace FavouriteBooks.Classes
{
    public class BookCatalogue
    {
        //Using a singleton pattern to ensure there is only one copy of BookCatalogue
        private static BookCatalogue _instance = null;
        private List<Book> _books;

        private BookCatalogue()
        {
            _books = new List<Book>();
            SeedBooks();
        }

        private void SeedBooks()
        {
            // Add some sample books to the catalogue
            //public Book(string title, string author, string isbn, decimal price, int stock)
            _books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565", 200.00m, 10)
            { Description = "Great guyd does great things" });
            _books.Add(new Book("To Kill a Mockingbird", "Harper Lee", "978-0061120084", 15.99m, 15)
            { Description = "Killing a really cool bird" });
            _books.Add(new Book("1984", "George Orwell", "978-0451524935", 10.99m, 11)
            { Description = "a book a little too close to the future" });
            _books.Add(new Book("test book", "Oliver Brand", "978-041524934", 1.99m, 1)
            { Description = "Best book ever" });
        }

        public static BookCatalogue Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BookCatalogue();
                }
                return _instance;
            }
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }

        //Used later to display all books 
        public IReadOnlyList<Book> GetAllBooks()
        {
            return _books.AsReadOnly();
        }

        public IReadOnlyList<Book> SearchBooks(string query)
        {
            return _books.Where(b => b.Title.Contains(query) ||
                                     b.Author.Contains(query) ||
                                     b.ISBN.Contains(query) ||
                                     b.Description.Contains(query)
                                     ).ToList().AsReadOnly();
        }


    }
}