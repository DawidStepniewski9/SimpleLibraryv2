using SimpleLibraryv2.Models;

namespace SimpleLibraryv2.Services
{
    public class BookMapperService
    {
        internal static Book Mapp(BookDTO bookDTO)
        {
            Book book = new Book();
            book.Author = bookDTO.Author;
            book.Title = bookDTO.Title;
            book.Year = bookDTO.Year;

            return book;
        }
    }
}
