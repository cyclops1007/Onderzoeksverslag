using AirBNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNB.DAL
{
    public interface IListings : IRepository<Listings>
    {
        IEnumerable<Listings> GetListingsContainingString(string indexString); 
    }
}
