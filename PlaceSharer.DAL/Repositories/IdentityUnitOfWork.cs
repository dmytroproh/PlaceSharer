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
        private ClientManager clientManager;
        private PlaceManager placeManager;

        public IdentityUnitOfWork(string connectionString)
        {
            database = new ApplicationContext(connectionString);

            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(database));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(database));
            clientManager = new ClientManager(database);
            placeManager = new PlaceManager(database);
        }

        public IRepository<ClientProfile> ClientManager
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

        public IRepository<Place> PlaceManager
        {
            get
            {
                return placeManager;
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
                    placeManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
