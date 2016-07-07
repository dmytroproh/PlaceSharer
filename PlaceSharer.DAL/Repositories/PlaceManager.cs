using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.EF;
using PlaceSharer.DAL.Interfaces;

namespace PlaceSharer.DAL.Repositories
{
    class PlaceManager : IPlaceManager
    {
        ApplicationContext Database;

        public PlaceManager(ApplicationContext db)
        {
            Database = db;
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
