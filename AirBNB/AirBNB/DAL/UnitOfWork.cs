using AirBNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirBNB.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AirBNBContext context;

        public IListings Listings { get; private set; }
        // voeg hier de andere repositories toe

        public UnitOfWork(AirBNBContext context) {
            this.context = context;
            Listings = new ListingsRepository(context);
        }

        public int Complete() {
            return context.SaveChanges();
        }

        public void Dispose() {
            context.Dispose();
        }


    }
}
