using Microsoft.EntityFrameworkCore;
using SimpleLibraryv2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLibraryv2.Test
{
    public class LibraryInitController
    {
        public LibraryInitController(DbContextMock<DbContextSimpleLibrary> dbContextMock) 
        { 
            
        }
    }
}
