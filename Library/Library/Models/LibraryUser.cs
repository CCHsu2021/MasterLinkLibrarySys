using System;
using System.Collections.Generic;

namespace Library.Models;

public partial class LibraryUser
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool EmailConfirmed { get; set; }

    public string Secret { get; set; } = null!;

    public virtual ICollection<BookStatement> BookStatements { get; } = new List<BookStatement>();
}
