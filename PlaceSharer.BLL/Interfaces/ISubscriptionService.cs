using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;

namespace PlaceSharer.BLL.Interfaces
{
    public interface ISubscriptionService : IDisposable
    {
        Task<OperationDetails> CreateAsync(SubscriptionDTO subscriptionDTO);
        Task<OperationDetails> RemoveAsync(SubscriptionDTO subscriptionDTO);
        IEnumerable<SubscriptionDTO> GetSubscriptions(string Id);
        IEnumerable<SubscriptionsManageDTO> GetSubscriptionsWithUserInfo(string userId);
    }
}
