using SimpleLibraryv2.Models;

namespace SimpleLibraryv2.Services
{
    public interface IBookService 
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBook(long id);
        Task Create(BookDTO bookDTO);
        //Task Update(Book book);
        Task Delete(long id);
    }
}
