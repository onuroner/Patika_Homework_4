using BookStore.Api.BookOperations.CreateBook;
using BookStore.Api.DbOperations;

namespace BookStore.Api.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }
        public int BookId;
        private readonly Context _dbContext;
        public UpdateBookCommand(Context dbContext)
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

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;

            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;

            book.Title = Model.Title != default ? Model.Title : book.Title;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
    }
}
