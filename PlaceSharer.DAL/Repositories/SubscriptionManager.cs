using System;
using System.Collections.Generic;
using System.Linq;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.EF;
using PlaceSharer.DAL.Interfaces;

namespace PlaceSharer.DAL.Repositories
{
    public class SubscriptionManager : IRepository<Subscription>
    {
        ApplicationContext Database;

        public SubscriptionManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(Subscription item)
        {
            Database.Subscriptions.Add(item);
        }

        public void Delete(Subscription item)
        {
            Database.Subscriptions.Find(item);
            if (item != null)
                Database.Subscriptions.Remove(item);
        }

        public void Update(Subscription item)
        {
            Database.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public IEnumerable<Subscription> Find(Func<Subscription, bool> predicate)
        {
            return Database.Subscriptions.Where(predicate).ToList();
        }

        public Subscription Get(string id)
        {
            return Database.Subscriptions.Find(id);
        }

        public IEnumerable<Subscription> GetAll()
        {
            return Database.Subscriptions;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
