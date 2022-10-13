using System;
using System.Collections.Generic;

namespace Books2Book.Models
{
    public partial class TblBook
    {
        public int BookId { get; set; }
        public string Isbn { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public bool InStock { get; set; }
        public int Edition { get; set; }
        public int Pages { get; set; }
        public string Condition { get; set; } = null!;
        public int NumberOfTimesBorrowed { get; set; }
        public string Description { get; set; } = null!;
        public float AverageRating { get; set; }
        public DateTime DatePublished { get; set; }
        public int AuthorId { get; set; }
    }
}
