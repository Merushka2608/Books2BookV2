using System;
using System.Collections.Generic;

namespace Books2Book.Models
{
    public partial class TblComment
    {
        public int CommentId { get; set; }
        public string Comment { get; set; } = null!;
        public int BookId { get; set; }
        public int UserId { get; set; }

        public virtual TblUser User { get; set; } = null!;
    }
}
