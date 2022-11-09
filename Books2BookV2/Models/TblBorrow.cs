using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblBorrow")]
    public partial class TblBorrow
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        [StringLength(256)]
        public string UserName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? DateToBorrow { get; set; }

        public TblBorrow(int BookId, string UserName, DateTime? DateToBorrow) { 
            this.BookId = BookId;
            this.UserName = UserName;
            this.DateToBorrow = DateToBorrow;
        }


    }
}
