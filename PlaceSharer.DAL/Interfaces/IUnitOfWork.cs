using System;
using System.Threading.Tasks;
using PlaceSharer.DAL.Identity;


namespace PlaceSharer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IClientManager ClientManager { get; }
        IPlaceManager PlaceManager { get; }
        ILocationManager LocationManager { get; }
        Task SaveAsync();
    }
}
