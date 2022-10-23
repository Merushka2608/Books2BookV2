using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblAuthor")]
    public partial class TblAuthor
    {
        public TblAuthor()
        {
            TblBooks = new HashSet<TblBook>();
        }

        [Key]
        [Column("AuthorID")]
        public int AuthorId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string AuthorName { get; set; } = null!;

        [InverseProperty("Author")]
        public virtual ICollection<TblBook> TblBooks { get; set; }
    }
}
