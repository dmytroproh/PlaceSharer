using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;

namespace PlaceSharer.BLL.Interfaces 
{
    public interface IPlaceService : IDisposable
    {
        Task<OperationDetails> CreateAsync(PlaceDTO placeDto);


    }
}
