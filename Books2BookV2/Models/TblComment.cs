using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblComments")]
    [Index("BookId", Name = "IX_tblComments")]
    [Index("UserId", Name = "IX_tblComments_userID")]
    public partial class TblComment
    {
        public TblComment()
        {
            TblReplies = new HashSet<TblReply>();
        }

        [Key]
        [Column("commentId")]
        public int CommentId { get; set; }
        [Column("comment")]
        [StringLength(150)]
        [Unicode(false)]
        public string Comment { get; set; } = null!;
        [Column("bookID")]
        public int BookId { get; set; }
        [Column("userID")]
        public int UserId { get; set; }
        [Column("ParentID")]
        public int? ParentId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("TblComments")]
        public virtual TblUser User { get; set; } = null!;
        [InverseProperty("Comment")]
        public virtual ICollection<TblReply> TblReplies { get; set; }
    }
}
