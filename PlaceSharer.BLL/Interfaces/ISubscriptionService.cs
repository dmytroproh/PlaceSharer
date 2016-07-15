using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;

namespace PlaceSharer.BLL.Interfaces
{
    public interface ISubscriptionService
    {
        Task<OperationDetails> CreateAsync(SubscriptionDTO subscriptionDTO);
    }
}
