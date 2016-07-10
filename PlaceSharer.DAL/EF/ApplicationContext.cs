using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PlaceSharer.DAL.Entities;

namespace PlaceSharer.DAL.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string connectionString) : base(connectionString)
        {
            //Database.SetInitializer(new DbInitializer());
        }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
