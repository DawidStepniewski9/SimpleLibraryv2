using Azure;
using Microsoft.EntityFrameworkCore;
using SimpleLibraryv2.Models;
using SimpleLibraryv2.Repository;
using System.Reflection;
using static SimpleLibraryv2.Services.BookService;
using Microsoft.AspNetCore.JsonPatch;

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
            Book book = BookMapperService.Mapp(bookDTO);

            book.Title = Extensions.ToUpperFirstLetter(book.Title);

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


        public async Task<Book> UpdateBook(long id, string title)
        {
            var bookQuery = await _repository.GetById(id);
            if (bookQuery == null)
            {
                return bookQuery;
            }

            bookQuery.Title = title;

            await _repository.Update(bookQuery);         

            return bookQuery;
        }

        public async Task<Book> UpdateBook(long id, BookModelPut bookModelPut)
        { 
            var dbBook = await _repository.GetById(id);
            if(dbBook == null)
            {
                return dbBook;
            }
            dbBook.Author = bookModelPut.Author;
            dbBook.Title = bookModelPut.Title;

            await _repository.Update(dbBook);

            return dbBook;
        }

    }
}
