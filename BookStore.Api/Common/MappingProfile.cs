using AutoMapper;
using BookStore.Api.BookOperations.CreateBook;
using BookStore.Api.BookOperations.GetBooks;

namespace BookStore.Api.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
