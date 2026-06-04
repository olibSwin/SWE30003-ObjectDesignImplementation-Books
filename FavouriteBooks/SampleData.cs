namespace FavouriteBooks
{
    internal static class SampleData
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>()
            {
                new(1, "TestBook1", "TestAuthor1", "1111111111111", 12.99m, 12, "Description of book 1"),
                new(2, "TestBook2", "TestAuthor2", "2222222222222", 23.35m, 12, "Description of book 2"),
                new(3, "TestBook3", "TestAuthor3", "3333333333333", 91.46m, 2, "Description of book 3"),
            };
        }
    }
}
