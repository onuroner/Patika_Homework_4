﻿using AutoMapper;
using BookStore.Api.Common;
using BookStore.Api.DbOperations;

namespace BookStore.Api.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly Context _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(Context dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList); 
            return vm;
        }
    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
