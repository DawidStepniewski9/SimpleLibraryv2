using Microsoft.EntityFrameworkCore;
using SimpleLibraryv2.Models;

namespace SimpleLibraryv2.DAL
{
    public class DbContextSimpleLibrary : DbContext
    {
        public DbContextSimpleLibrary(DbContextOptions<DbContextSimpleLibrary> options) : base(options) 
        { 

        }

        public DbSet<Book> Books {  get; set; }
    }
}
