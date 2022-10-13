using System;
using System.Collections.Generic;

namespace Books2Book.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblComments = new HashSet<TblComment>();
        }

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public string? Institution { get; set; }
        public string? SubscriptionType { get; set; }
        public int? AccountId { get; set; }

        public virtual TblAccount? Account { get; set; }
        public virtual ICollection<TblComment> TblComments { get; set; }
    }
}
