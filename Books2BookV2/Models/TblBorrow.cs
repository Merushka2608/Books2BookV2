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
        public TblBorrow(int bookId, string userName, DateTime? dateToBorrow, bool? isPaid)
        {

            BookId = bookId;
            UserName = userName;
            DateToBorrow = dateToBorrow;
            IsPaid = isPaid;
        }

        [Key]

        public int Id { get; set; }
        public int BookId { get; set; }
        [StringLength(256)]
        public string UserName { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime? DateToBorrow { get; set; }
        [Column("isPaid")]
        public bool? IsPaid { get; set; }
    }
}
