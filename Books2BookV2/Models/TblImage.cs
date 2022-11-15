using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblImage")]
    public partial class TblImage
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Unicode(false)]
        public string Title { get; set; } = null!;
        [Column("image")]
        [Unicode(false)]
        public string Image { get; set; } = null!;
        [Column("ISBN")]
        [StringLength(15)]
        [Unicode(false)]
        public string Isbn { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string BookTitle { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Author { get; set; } = null!;
        [StringLength(300)]
        [Unicode(false)]
        public string DescriptionOfCondition { get; set; } = null!;
    }
}
