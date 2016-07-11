using System;
using System.Collections.Generic;
using System.Linq;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.EF;
using PlaceSharer.DAL.Interfaces;

namespace PlaceSharer.DAL.Repositories
{
    class PlaceManager : IRepository<Place>
    {
        ApplicationContext Database;

        public PlaceManager(ApplicationContext db)
        {
            Database = db;
        }

        public IEnumerable<Place> GetAll()
        {
            return Database.Places;
        }
        
        public IEnumerable<Place> Find(Func<Place, Boolean> predicate)
        {
            return Database.Places.Where(predicate).ToList();
        }

        public Place Get(string id)
        {
            return Database.Places.Find(id);
        }
        
        public void Create(Place item)
        {
            Database.Places.Add(item);
        }

        public void Update(Place item)
        {
            Database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(Place item)
        {
            Place place = Database.Places.Find(item);
            if (place != null)
                Database.Places.Remove(item);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
        
    }
}
