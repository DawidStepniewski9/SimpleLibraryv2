using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using SimpleLibraryv2.DAL;

namespace SimpleLibraryv2.Test
{
    public class BookTest1
    {
        [Fact]
        public void GetById_Book()
        {
            var mockedDbContext = Create.MockedDbContextFor<DbContextSimpleLibrary>();



        }
    }
}