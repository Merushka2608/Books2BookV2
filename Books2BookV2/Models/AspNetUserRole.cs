using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Keyless]
    public partial class AspNetUserRole
    {
        [StringLength(450)]
        public string UserId { get; set; } = null!;
        [StringLength(450)]
        public string RoleId { get; set; } = null!;

        [ForeignKey("RoleId")]
        public virtual AspNetRole Role { get; set; } = null!;
        [ForeignKey("UserId")]
        public virtual AspNetUser User { get; set; } = null!;
    }
}
