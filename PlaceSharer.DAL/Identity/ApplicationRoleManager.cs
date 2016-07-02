using Microsoft.AspNet.Identity;
using PlaceSharer.DAL.Entities;

namespace PlaceSharer.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store)
        {
        }

        public ApplicationRoleManager(IRoleStore<ApplicationRole> store) : base(store)
        {

        }
    }
}
