using System;
using System.Collections.Generic;

namespace IdentityServer.Models
{
    public partial class Reviews
    {
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}
