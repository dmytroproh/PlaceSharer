using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;

namespace PlaceSharer.BLL.Interfaces 
{
    public interface IPlaceService : IDisposable
    {
        Task<OperationDetails> CreateAsync(PlaceDTO placeDto);
        //Task<PlaceDTO> GetPlace(string id);
        IEnumerable<PlaceDTO> GetPlacesByUserId(string UserId);
    }
}
