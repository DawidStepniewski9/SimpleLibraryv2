using Azure;
using Microsoft.EntityFrameworkCore;
using SimpleLibraryv2.DAL;
using SimpleLibraryv2.Models;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace SimpleLibraryv2.Repository
{
    public class BookRepository
    {
        private readonly DbContextSimpleLibrary _db;
        public BookRepository(DbContextSimpleLibrary db) 
        { 
            _db = db;
        }

        public async Task Create(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
        }
        public async Task<Book> GetById(long id)
        {
            var book = await _db.Books.FindAsync(id);
            return book;
        }
        public async Task<List<Book>> GetAll()
        {
            return await _db.Books.ToListAsync();
        }
        public async Task Update(Book bookToUpdate)
        {
            _db.Books.Update(bookToUpdate);
            await _db.SaveChangesAsync();
        }
        public async Task Delete(Book bookToDelete) 
        {
            _db.Books.Remove(bookToDelete);
            await _db.SaveChangesAsync();
        }
    }
}
