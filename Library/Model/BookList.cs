using System;
using System.Collections.Generic;

namespace Library.Model
{
    public partial class BookList
    {
        public BookList()
        {
            BookStatements = new HashSet<BookStatement>();
        }

        public int Id { get; set; }
        public string BookName { get; set; } = null!;
        public string BookClassification { get; set; } = null!;
        public string Author { get; set; } = null!;

        public virtual ICollection<BookStatement> BookStatements { get; set; }
    }
}
