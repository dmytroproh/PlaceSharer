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
        Task<OperationDetails> CreateAsync(UserDTO userDto);
        
        Task<OperationDetails> ChangePasswordAsync(ChangePasswordDTO cpDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);

        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
