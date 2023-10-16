using BookStore.Api.DbOperations;

namespace BookStore.Api.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly Context _dbContext;
        public int BookId;
        public DeleteBookCommand(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();           
        }
    }
}
