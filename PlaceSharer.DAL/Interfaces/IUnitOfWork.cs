using System;
using System.Threading.Tasks;
using PlaceSharer.DAL.Identity;


namespace PlaceSharer.DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IClientManager ClientManager { get; }
        Task SaveAsync();
    }
}
