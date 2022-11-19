using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Table("tblBooks")]
    public partial class TblBook
    {
        [Key]
        [Column("BookID")]
        public int BookId { get; set; }
        [Column("ISBN")]
        [StringLength(15)]
        [Unicode(false)]
        public string Isbn { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Title { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Category { get; set; } = null!;
        public bool InStock { get; set; }
        public int Edition { get; set; }
        public int Pages { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string Condition { get; set; } = null!;
        public int NumberOfTimesBorrowed { get; set; }
        [StringLength(300)]
        [Unicode(false)]
        public string Description { get; set; } = null!;
        public float RatingTotal { get; set; }
        [Column(TypeName = "date")]
        public DateTime DatePublished { get; set; }
        [Column("AuthorID")]
        public int AuthorId { get; set; }
        public int? NumberOfTimesRated { get; set; }
        public float? AverageRating { get; set; }
        [Column("PDFLink")]
        [Unicode(false)]
        public string? Pdflink { get; set; }

        [ForeignKey("AuthorId")]
        [InverseProperty("TblBooks")]
        public virtual TblAuthor Author { get; set; } = null!;
    }
}
