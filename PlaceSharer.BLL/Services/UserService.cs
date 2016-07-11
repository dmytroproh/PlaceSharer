using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;
using PlaceSharer.BLL.Interfaces;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.Interfaces;

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

        public async Task<OperationDetails> CreateAsync(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);

            if(user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                    var confToken = Database.UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //var callBackUrl = Url.

                    //await Database.UserManager.SendEmailAsync(
                    //    user.Id,
                    //    "Confirm Email for Login in PlaceSharer",
                    //    "To complete the registration please go to: <a href=\"" +
                    //    +callBackUrl + "\">Complete registration</a>"
                    //    );
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

        public async Task<OperationDetails> ChangePasswordAsync(ChangePasswordDTO cpDto)
        {
            var result = await Database.UserManager.ChangePasswordAsync(cpDto.UserId, cpDto.OldPassword, cpDto.NewPassword);
            if(result.Succeeded)
            {
                await Database.SaveAsync();
                return new OperationDetails(true, "Password Changed", "");
            }
            else
            {
                return new OperationDetails(false, "Password wasn`t changed", "");
            }
            
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
            await CreateAsync(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
