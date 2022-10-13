using System;
using System.Collections.Generic;

namespace Books2Book.Models
{
    public partial class TblAuthor
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
    }
}
