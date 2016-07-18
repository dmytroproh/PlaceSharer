using System;
using System.Collections.Generic;
using System.Linq;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.EF;
using PlaceSharer.DAL.Interfaces;

namespace PlaceSharer.DAL.Repositories
{
    public class ClientManager : IRepository<ClientProfile>
    {
        public ApplicationContext Database { get; set; }

        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public IEnumerable<ClientProfile> GetAll()
        {
            return Database.ClientProfiles;
        }

        public IEnumerable<ClientProfile> Find(Func<ClientProfile, Boolean> predicate)
        {
            return Database.ClientProfiles.Where(predicate).ToList();
        }

        public ClientProfile Get(string id)
        {
            return Database.ClientProfiles.Find(id);
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
        }

        public void Edit(ClientProfile item)
        {
            Database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Update(ClientProfile item)
        {
            Database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(string id)
        {
            ClientProfile profile = Database.ClientProfiles.Find(id);
            if (profile != null)
                Database.ClientProfiles.Remove(profile);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
