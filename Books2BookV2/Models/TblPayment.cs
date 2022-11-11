using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblPayments")]
    public partial class TblPayment
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        [Unicode(false)]
        public string BookIds { get; set; } = null!;

        [ForeignKey("AccountId")]
        [InverseProperty("TblPayments")]
        public virtual TblAccount Account { get; set; } = null!;
    }
}
