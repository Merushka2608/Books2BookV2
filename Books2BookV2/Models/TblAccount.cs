﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblAccount")]
    public partial class TblAccount
    {
        public TblAccount()
        {
            TblUsers = new HashSet<TblUser>();
        }

        [Key]
        public int AccountId { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string Bank { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string AccountNumber { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string UserId { get; set; } = null!;

        [InverseProperty("Account")]
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
