using AirBNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNB.DAL
{
    public class ListingsRepository : Repository<Listings>, IListings
    {
        public AirBNBContext Context
        {
            get { return context as AirBNBContext; }
        }

        public ListingsRepository(AirBNBContext context) : base(context)
        {
        }

        public IEnumerable<Listings> GetListingsContainingString(string indexString)
        {
            return Context.Listings.Where(n => n.Name.ToLower().Contains("a"));
        }
    }
}
