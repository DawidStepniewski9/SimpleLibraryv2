using Azure;
using SimpleLibraryv2.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace SimpleLibraryv2.Services
{
    public interface IBookService 
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBook(long id);
        Task Create(BookDTO bookDTO);
        Task Update(long id, BookDTO bookDTO);
        Task Delete(long id);
        Task<Book> UpdateBook(long id, string bookDocument);
        Task<Book> UpdateBook(long id, BookModelPut bookModelPut);
    }
}
