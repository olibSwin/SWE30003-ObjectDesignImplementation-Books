using System.Linq;

public class BookCatalogue
{
    //Using a singleton pattern to ensure there is only one copy of BookCatalogue
    private static BookCatalogue _instance = null;
    private List<Book> _books;
    
    private BookCatalogue() 
    {
        _books = new List<Book>();
    }

    public static BookCatalogue instance
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
                                 ).ToList().AsReadOnly() ;
    }
}