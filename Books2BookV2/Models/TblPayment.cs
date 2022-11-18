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
        public string UserName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string AccNumber { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DatePaid { get; set; }
        [Column("total")]
        public double Total { get; set; }
    }
}
