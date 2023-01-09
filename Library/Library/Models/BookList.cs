using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class BookList
{
    public int Id { get; set; }

    public string BookName { get; set; } = null!;

    public string BookClassification { get; set; } = null!;

    public string Author { get; set; } = null!;

    public virtual ICollection<BookStatement> BookStatements { get; } = new List<BookStatement>();
}
