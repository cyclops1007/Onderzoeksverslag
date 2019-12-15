using System;
using System.Collections.Generic;

namespace AirBNB.Models
{
    public partial class SummaryReviews
    {
        public int SummaryreviewsId { get; set; }
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
    }
}
