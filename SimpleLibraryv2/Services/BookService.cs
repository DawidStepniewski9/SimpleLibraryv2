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

        //public async Task Update(Book book)
        //{
        //    if( await _repository.GetById(book.Id) != null)
        //    {
        //       await _repository.Update(book);
        //    }
        //    else 
        //    { 
        //        throw new Exception("No book in library"); 
        //    }

            //if (await GetById(book.Id) != null)
            //{
            //    _db.Books.Update(book);
            //}
            //else
            //{
            //    throw new Exception("No book in library");
            //}
        //}

        public async Task Delete(long id)
        {
            var bookToDelete = await _repository.GetById(id);
            if (bookToDelete != null)
            {
                _repository.Delete(id);
            }
            else
            {
                throw new Exception("No book in library");
            }
        }

    }
}
