namespace FavouriteBooks.Classes
{
    internal class InventoryService
    {
        public InventoryService() { }

        public bool HasStock(Book book, int quantity)
        {
            /*
             * if book's stock >= quantity:
             *      return true
             * else:
             *      return false
             */
            return false;
        }

        public void ReduceStock(Book book, int quantity)
        {
            /*
             * book's stock -= quantity
             */
        }

        public void IncreaseStock(Book book, int quantity)
        {
            /*
             * book's stock += quantity
             */
        }
    }
}
