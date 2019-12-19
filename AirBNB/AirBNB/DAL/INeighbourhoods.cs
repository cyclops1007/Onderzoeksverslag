using AirBNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNB.DAL
{
    public interface INeighbourhoodsRepository : IRepository<Neighbourhoods>
    {
        IEnumerable<Neighbourhoods> GetNeighbourhoodsContainingString(string indexString); //Extra methode om neighbourhoods te filteren
    }
}
