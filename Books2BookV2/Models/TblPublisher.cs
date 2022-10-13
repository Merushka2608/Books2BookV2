using System;
using System.Collections.Generic;

namespace Books2Book.Models
{
    public partial class TblPublisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; } = null!;
    }
}
