using SimpleLibraryv2.Models;
using SimpleLibraryv2.Repository;
using System.Reflection;

namespace SimpleLibraryv2.Services
{
    public class BookService : IBookService
    {
        private BookRepository _repository;
        public BookService(BookRepository repository) {
            _repository = repository;
        }
        public async Task<List<Book>> GetBooks()
        {
            var result = await _repository.GetAll();
            return result;
        }

        public async Task<Book> GetBook(long id)
        { 
            var result = await _repository.GetById(id);
            return result;
        }

        public async Task Create(BookDTO bookDTO)
        {
            Book book = new Book(); 
            book.Author = bookDTO.Author;
            book.Title = bookDTO.Title;
            book.Year = bookDTO.Year;

            await _repository.Create(book);
        }

        public async Task Update(long id, BookDTO bookDTO)
        {
            var bookToUpdate = await _repository.GetById(id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Author = bookDTO.Author;
                bookToUpdate.Title = bookDTO.Title; 
                bookToUpdate.Year = bookDTO.Year;
                await _repository.Update(bookToUpdate);
            }
            else
            {
                throw new Exception("No book in library");
            }
        }

        public async Task Delete(long id)
        {
            var bookToDelete = await _repository.GetById(id);
            if (bookToDelete != null)
            {
                await _repository.Delete(bookToDelete);
            }
            else
            {
                throw new Exception("No book in library");
            }
        }

    }
}
