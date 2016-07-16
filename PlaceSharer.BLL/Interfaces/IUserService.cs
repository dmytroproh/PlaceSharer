using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;

namespace PlaceSharer.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDto, string pathForConfirmEmail);
        IEnumerable<UserDTO> GetUsers(string name);
        Task<OperationDetails> ChangePasswordAsync(ChangePasswordDTO cpDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);

        Task<OperationDetails> ConfirmEmailAsync(string userId, string confirmCode);
        Task<OperationDetails> EditUser(UserDTO userDto);

        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
