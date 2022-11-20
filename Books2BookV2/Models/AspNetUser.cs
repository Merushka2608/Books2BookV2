using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Books2BookV2.Models
{
    [Index("NormalizedEmail", Name = "EmailIndex")]
    [Index("UserName", Name = "UserName", IsUnique = true)]
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
        }

        [Key]
        public string Id { get; set; } = null!;
        [StringLength(256)]
        public string? UserName { get; set; }
        [StringLength(256)]
        public string? NormalizedUserName { get; set; }
        [StringLength(256)]
        public string? Email { get; set; }
        [StringLength(256)]
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
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
        public string? Institution { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? SubscriptionType { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? AccountNumber { get; set; }
        public double? DamageFeeOwed { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
    }
}
