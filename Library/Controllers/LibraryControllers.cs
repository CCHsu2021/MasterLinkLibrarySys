using Library.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Library.Controllers
{
    public class LibraryControllers
    {
        private readonly LibraryContext _libraryContext;

        public LibraryControllers(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        
/*        public IActionResult BookList()
        {
            var a = _libraryContext.BookLists.ToList();
            return View(new BookList());
        }*/
    }
}
