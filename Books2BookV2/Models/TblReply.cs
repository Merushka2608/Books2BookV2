using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblReplies")]
    public partial class TblReply
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Text { get; set; }
        [Column("CommentID")]
        public int? CommentId { get; set; }

        [ForeignKey("CommentId")]
        [InverseProperty("TblReplies")]
        public virtual TblComment? Comment { get; set; }
    }
}
