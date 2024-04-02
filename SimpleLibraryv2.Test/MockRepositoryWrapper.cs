using Moq;
using SimpleLibraryv2.Models;
using SimpleLibraryv2.Repository;
using SimpleLibraryv2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryv2.Test
{
    internal class MockRepositoryWrapper
    {
        public static Mock<IBookService> GetMock()
        {
            var mock = new Mock<IBookService>();

            mock.Setup(m=>m.GetBook(1)).Returns(()=> new Mock<Models.Book>().Object);
            mock.Setup(m=>m.GetBooks()).Returns(()=> new Mock<List<Models.Book>>().Object);

            mock.Setup(m => m.Create(new Models.BookDTO())).Callback(() => { return; });
            mock.Setup(m => m.Update(1,new Models.BookDTO())).Callback(() => { return; });
            mock.Setup(m => m.Delete(1)).Callback(() => { return; });

            return mock;
        }

        public static Mock<BookRepository> GetMockRepository()
        {
            var mock = new Mock<BookRepository>();

            var book = new List<Book>()
            {
                new Book()
                {
                    Author="Test",
                    Title="Test",
                    Id=1,
                    Year=2024
                }
            };


            mock.Setup(m=>m.GetById(It.IsAny<long>)).Returns((int id)=> book.FirstOrDefault(b=> b.Id==id));
            return mock;
        }


    }
}
