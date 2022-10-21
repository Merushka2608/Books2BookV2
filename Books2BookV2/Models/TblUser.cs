using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblUsers")]
    [Index("AccountId", Name = "IX_tblUsers_AccountId")]
    public partial class TblUser
    {
        public TblUser()
        {
            TblComments = new HashSet<TblComment>();
        }

        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [Column("DOB", TypeName = "date")]
        public DateTime? Dob { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Address { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Password { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Institution { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? SubscriptionType { get; set; }
        public int? AccountId { get; set; }

        [ForeignKey("AccountId")]
        [InverseProperty("TblUsers")]
        public virtual TblAccount? Account { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TblComment> TblComments { get; set; }
    }
}
