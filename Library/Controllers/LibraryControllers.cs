using Library.Model;

namespace Library.Controllers
{
    public class LibraryControllers
    {
        private readonly LibraryContext _libraryContext;

        public LibraryControllers(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }


    }
}
