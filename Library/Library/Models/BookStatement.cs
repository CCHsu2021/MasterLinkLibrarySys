using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class BookStatement
{
    public Guid Id { get; set; }

    public int BookId { get; set; }

    public Guid BorrowerId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public virtual BookList Book { get; set; } = null!;

    public virtual LibraryUser Borrower { get; set; } = null!;
}
