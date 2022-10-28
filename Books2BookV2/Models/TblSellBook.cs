using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Keyless]
    [Table("tblSellBooks")]
    public partial class TblSellBook
    {
		[Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Title { get; set; } = null!;
        public byte[] FrontPicture { get; set; } = null!;
        public byte[] BackPicture { get; set; } = null!;
    }
}
