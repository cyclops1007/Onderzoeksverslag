using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AirBNB.DAL
{
    public interface IRepository<TEntity> where TEntity : class //zorgt ervoor dat er alleen een repository aangemaakt kan worden voor classes
    {
        TEntity Get(int id); //Vind een enitity met primary key
        IEnumerable<TEntity> GetAll(); //Alle entities in repository ophalen
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate); //Vind meerdere entities met een predicate

        void Add(TEntity entity); //Entity toevoegen aan de repository
        void AddRange(IEnumerable<TEntity> entities); //Meerdere entities toevoegen aan de repository

        void Remove(TEntity entity); //Entity verwijderen uit de repository
        void RemoveRange(IEnumerable<TEntity> entities); //Meerdere entities verwijderen uit de repository
    }
}
