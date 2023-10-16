using FluentValidation;

namespace BookStore.Api.BookOperations.GetBookById
{
    public class GetBookByIdQueryValidator:AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(query => query.BookId).NotEmpty().GreaterThan(0);
        }
    }
}
