using System.Linq;
using FavouriteBooks.Classes;
namespace FavouriteBooks.Services
{
    public class BookCatalogue
    {
        //Using a singleton pattern to ensure there is only one copy of BookCatalogue
        private static BookCatalogue _instance = null;
        private List<Book> _books;
        private int _nextId = 1;
        private const string FilePath = "Data/books.json";

        private BookCatalogue()
        {
            _books = new List<Book>();
            //if(_books.Count == 0){SeedData();}
            Load();
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
            book.Id = _nextId++;
            _books.Add(book);
            Save();
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
            Save();
        }

        //Used later to display all books 
        public IReadOnlyList<Book> GetAllBooks()
        {
            return _books.AsReadOnly();
        }

        public IReadOnlyList<Book> SearchBooks(string query)
        {
            return _books.Where(b =>
                b.Title.Contains(query) ||
                b.Author.Contains(query) ||
                b.ISBN.Contains(query) ||
                (!string.IsNullOrEmpty(b.Description) &&
                 b.Description.Contains(query))
            ).ToList().AsReadOnly();
        }
        public void Load()
        {
            var loaded = JsonStorageService.Load<List<Book>>(FilePath);

            if (loaded != null && loaded.Count > 0)
            {
                _books = loaded;
                SyncNextId();
                return;
            }

            SyncNextId();
            Save();
        }
        public void Save()
        {
            JsonStorageService.Save(FilePath, _books);
        }
        private void SyncNextId()
        {
            if (_books == null || _books.Count == 0)
            {
                _nextId = 1;
                return;
            }

            _nextId = _books.Max(b => b.Id) + 1;
        }

        private void SeedData()
        {
            if (_books.Any())
                return;

            _books = new List<Book>
    {
        new Book("1984", "George Orwell", "123", 10m, 5)
        {
            Id = _nextId++,
            Description = "Dystopian novel about surveillance and control."
        },

        new Book("Dune", "Frank Herbert", "456", 15m, 5)
        {
            Id = _nextId++,
            Description = "Epic science fiction story set on a desert planet."
        },

        new Book("The Hobbit", "J.R.R. Tolkien", "789", 20m, 5)
        {
            Id = _nextId++,
            Description = "Fantasy adventure following Bilbo Baggins."
        },

        new Book("Foundation", "Isaac Asimov", "999", 18m, 5)
        {
            Id = _nextId++,
            Description = "Sci-fi story about the fall of a galactic empire."
        }
    };

            Save();
        }

    }
}