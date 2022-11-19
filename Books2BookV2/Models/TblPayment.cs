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
        public TblPayment(string userName, string accNumber, DateTime datePaid, double total)
        {
            UserName = userName;
            AccNumber = accNumber;
            DatePaid = datePaid;
            Total = total;
        }

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

        public TblPayment(string UserName, string AccNumber, DateTime DatePaid, double Total)
        {
            this.UserName = UserName;
            this.AccNumber = AccNumber;
            this.DatePaid = DatePaid;
            this.Total = Total;
        }

    }
}
