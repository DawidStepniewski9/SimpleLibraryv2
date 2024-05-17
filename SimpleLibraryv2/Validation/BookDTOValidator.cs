using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SimpleLibraryv2.Models;

namespace SimpleLibraryv2.Validation
{
    public class BookDTOValidator : AbstractValidator<BookDTO>
    {
        public BookDTOValidator() 
        {
            RuleFor(t => t.Title)
                .NotEmpty()
                .Length(1, 250);
            RuleFor(a => a.Author)
                .NotEmpty()
                .Length(1, 30)
                .Matches(@"^[A-Z][A-Za-z\s]*$");
            RuleFor(y => y.Year)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now.Year)
                .GreaterThan(1900);               
        }
    }
}
