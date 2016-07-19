using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.EF;

namespace PlaceSharer.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string connectionString) : base(connectionString) { }

        static ApplicationContext()
        {
            //Database.SetInitializer(new PlaceSharerDbInitializer());
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
