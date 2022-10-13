using System;
using System.Collections.Generic;

namespace Books2Book.Models
{
    public partial class TblAccount
    {
        public TblAccount()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public int AccountId { get; set; }
        public string Bank { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
