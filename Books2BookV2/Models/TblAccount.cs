using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblAccount")]
    public partial class TblAccount
    {
        [Key]
        public int AccountId { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string Bank { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string AccountNumber { get; set; } = null!;
        [StringLength(256)]
        public string UserName { get; set; } = null!;

        public virtual AspNetUser UserNameNavigation { get; set; } = null!;
    }
}
