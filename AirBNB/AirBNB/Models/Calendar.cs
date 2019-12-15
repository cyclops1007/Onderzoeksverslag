using System;
using System.Collections.Generic;

namespace AirBNB.Models
{
    public partial class Calendar
    {
        public int CalendarId { get; set; }
        public int ListingId { get; set; }
        public DateTime Date { get; set; }
        public string Available { get; set; }
        public string Price { get; set; }
    }
}
