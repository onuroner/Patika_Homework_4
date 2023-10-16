using AutoMapper;
using BookStore.Api.BookOperations.GetBooks;
using BookStore.Api.Common;
using BookStore.Api.DbOperations;

namespace BookStore.Api.BookOperations.GetBookById
{
    public class GetBookByIdQuery
    {
        private readonly Context _dbContext;
        private readonly IMapper _mapper;
        public int BookId;
        public GetBookByIdQuery(Context dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BooksViewModel Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            var vm = _mapper.Map<BooksViewModel>(book);
            return vm;
        }
    }
}
