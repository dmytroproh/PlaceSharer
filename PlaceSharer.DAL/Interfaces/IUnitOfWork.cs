using System;
using System.Threading.Tasks;
using PlaceSharer.DAL.Identity;
using PlaceSharer.DAL.Interfaces;
using PlaceSharer.DAL.Entities;

namespace PlaceSharer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IRepository<ClientProfile> ClientManager { get; }
        IRepository<Place> PlaceManager { get; }
        Task SaveAsync();
    }
}
