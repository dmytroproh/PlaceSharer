using PlaceSharer.DAL.EF;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.Identity;
using PlaceSharer.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace PlaceSharer.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext database;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;
        private IPlaceManager placeManager;
        private ILocationManager locationManager;

        public IdentityUnitOfWork(string connectionString)
        {
            database = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(database));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(database));
            clientManager = new ClientManager(database);
            placeManager = new PlaceManager(database);
            locationManager = new LocationManager(database);
        }

        public IClientManager ClientManager
        {
            get
            {
                return clientManager;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return roleManager;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager;
            }
        }

        public IPlaceManager PlaceManager
        {
            get
            {
                return placeManager;
            }
        }

        public ILocationManager LocationManager
        {
            get
            {
                return locationManager;
            }
        }

        public async Task SaveAsync()
        {
            await database.SaveChangesAsync();
        }

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
