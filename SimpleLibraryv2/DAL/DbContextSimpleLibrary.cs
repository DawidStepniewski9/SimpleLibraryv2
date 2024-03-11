using Microsoft.EntityFrameworkCore;
using SimpleLibraryv2.Models;

namespace SimpleLibraryv2.DAL
{
    public class DbContextSimpleLibrary : DbContext
    {
        public DbContextSimpleLibrary() : base()
               {

               }

        public DbSet<Book> book {  get; set; }
    }
}
