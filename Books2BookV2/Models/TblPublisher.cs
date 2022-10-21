using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblPublisher")]
    public partial class TblPublisher
    {
        [Key]
        [Column("PublisherID")]
        public int PublisherId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string PublisherName { get; set; } = null!;
    }
}
