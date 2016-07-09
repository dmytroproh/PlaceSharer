using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;
using System.Threading.Tasks;

namespace PlaceSharer.BLL.Interfaces
{
    public interface IPlaceService
    {
        Task<OperationDetails> CreateAsync(PlaceDTO placeDto);
    }
}
