using System;
using System.Collections.Generic;

namespace BooksList;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string YearOfPublication { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int Rating { get; set; }
}
