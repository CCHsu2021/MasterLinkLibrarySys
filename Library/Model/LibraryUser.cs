using System;
using System.Collections.Generic;

namespace Library.Model
{
    public partial class LibraryUser
    {
        public LibraryUser()
        {
            BookStatements = new HashSet<BookStatement>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Secret { get; set; } = null!;

        public virtual ICollection<BookStatement> BookStatements { get; set; }
    }
}
