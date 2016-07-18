using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;
using PlaceSharer.BLL.Interfaces;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.Interfaces;
using AutoMapper;

namespace PlaceSharer.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork db)
        {
            Database = db;
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task<OperationDetails> CreateAsync(UserDTO userDto, string pathForConfirmEmail)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);

            if(user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                    
                    //await SendEmailForConfirmEmail(user.Id, pathForConfirmEmail);
                }
                ClientProfile clientProfile = new ClientProfile
                {
                    Id = user.Id,
                    Name = userDto.Name,
                    LastName = userDto.LastName
                };
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();

                return new OperationDetails(true, "Registration completed successfully", "");
            }
            else
            {
                return new OperationDetails(false, "User with this login already exists", "Email");
            }
        }

        public IEnumerable<UserDTO> GetUsers(string name)
        {
            var config = new MapperConfiguration(r => r.CreateMap<ApplicationUser, UserDTO>()).CreateMapper();
            List<UserDTO> users = new List<UserDTO>();
            if(name != null)
                users = config.Map<IEnumerable<ApplicationUser>, List<UserDTO>>(Database.UserManager.Users
                .Include(cp => cp.ClientProfile)
                .Include(subs => subs.Subscriptions)
                .Where(u => u.UserName.Contains(name)));
            else
                users = config.Map<IEnumerable<ApplicationUser>, List<UserDTO>>(Database.UserManager.Users
                    .Include(subs => subs.Subscriptions)
                    .Include(cp => cp.ClientProfile));
            
            return users;
        }

        public async Task<OperationDetails> ChangePasswordAsync(ChangePasswordDTO cpDto)
        {
            var result = await Database.UserManager.ChangePasswordAsync(cpDto.UserId, cpDto.OldPassword, cpDto.NewPassword);
            if (result.Succeeded)
            {
                await Database.SaveAsync();
                return new OperationDetails(true, "Password Changed", "");
            }
            else
            {
                return new OperationDetails(false, "Password wasn`t changed", "");
            }
        }

        public async Task<OperationDetails> EditUser(UserDTO userDto)
        {
            var cProfile = Database.ClientManager.Get(userDto.Id);

            cProfile.Name = userDto.Name;
            cProfile.LastName = userDto.LastName;

            Database.ClientManager.Update(cProfile);

            await Database.SaveAsync();
            return new OperationDetails(true, "User updated successfully", "");
            
                //return new OperationDetails(false, "User wasn't updated", "");
        }

        public async Task<OperationDetails> ConfirmEmailAsync(string userId, string confirmCode)
        {
            var user = await Database.UserManager.FindByIdAsync(userId);
            if (user == null)
                return new OperationDetails(false, "User with currently Id not exist", "Id");
            var confirmResult = await Database.UserManager.ConfirmEmailAsync(userId, confirmCode);
            if (!confirmResult.Succeeded)
                return new OperationDetails(false, "Email has not been confirmed", "");
            else
                return new OperationDetails(true, "Email was confirmed", "");

        }

        public async Task<string> GetUserIdByName(string userName)
        {
            ApplicationUser user = await Database.UserManager.FindByNameAsync(userName);
            return user.Id.ToString();
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach(string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if(role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await CreateAsync(adminDto, "");
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        private async Task SendEmailForConfirmEmail(string userId, string onePartOfConfirmLink)
        {
            var confToken = await Database.UserManager.GenerateEmailConfirmationTokenAsync(userId);
            var callbackUrl = onePartOfConfirmLink + "?" + "userId=" + userId + "&code=" + confToken;

            await Database.UserManager.SendEmailAsync(userId,
                "Confirmation e-mail",
                "To complete the registration please go to: <a href=\""
                + callbackUrl + "\">to complete registration!</a>");
        }
    }
}
