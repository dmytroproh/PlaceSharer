using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
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
    public class SubscriptionService : ISubscriptionService
    {
        IUnitOfWork Database;

        public SubscriptionService(IUnitOfWork db)
        {
            Database = db;
        }

        public async Task<OperationDetails> CreateAsync(SubscriptionDTO subscriptionDTO)
        {
            ApplicationUser currentUser = await Database.UserManager.FindByIdAsync(subscriptionDTO.SubscriberId);
            ApplicationUser subscribeUser = await Database.UserManager.FindByIdAsync(subscriptionDTO.SubscriptionUserId);

            if (currentUser != null)
            {
                Subscription subscription = new Subscription
                {
                    SubscriberId = currentUser.Id,
                    SubscriptionUserId = subscribeUser.Id
                };

                Database.SubscriptionManager.Create(subscription);
                await Database.SaveAsync();
                return new OperationDetails(true, "Subscription added", "");
                }
                return new OperationDetails(false, "User with this Id already exists", "Id");
        }

        public async Task<OperationDetails> RemoveAsync(SubscriptionDTO subscriptionDTO)
        {
            ApplicationUser currentUser = await Database.UserManager.FindByIdAsync(subscriptionDTO.SubscriberId);
            ApplicationUser subscribeUser = await Database.UserManager.FindByIdAsync(subscriptionDTO.SubscriptionUserId);

            if (currentUser != null)
            {
                Subscription subscription = new Subscription
                {
                    SubscriberId = currentUser.Id,
                    SubscriptionUserId = subscribeUser.Id
                };

                Database.SubscriptionManager.Delete(subscription.SubscriptionUserId);
                await Database.SaveAsync();
                return new OperationDetails(true, "Subscription deleted", "");
            }
            return new OperationDetails(false, "User with this Id already exists", "Id");
        }

        public IEnumerable<SubscriptionDTO> GetSubscriptions(string userId)
        {
            var config = new MapperConfiguration(r => r.CreateMap<Subscription, SubscriptionDTO>()
            .ForMember("SubscriptionUserName", u => u.MapFrom(us => us.SubscriptionUser.UserName))
            ).CreateMapper();
            List<SubscriptionDTO> subscriptions = new List<SubscriptionDTO>();
            if (userId != null)
            {
                subscriptions = config.Map<IEnumerable<Subscription>, List<SubscriptionDTO>>(Database.SubscriptionManager.Find(u => u.SubscriberId == userId));
            }
           
            return subscriptions;
        }

        public IEnumerable<SubscriptionsManageDTO> GetSubscriptionsWithUserInfo(string userId)
        {
            var config = new MapperConfiguration(r => r.CreateMap<Subscription, SubscriptionsManageDTO>()
            .ForMember("FirstName", u => u.MapFrom(us => us.SubscriptionUser.ClientProfile.Name))
            .ForMember("LastName", u => u.MapFrom(us => us.SubscriptionUser.ClientProfile.LastName))
            .ForMember("PostsCount", u => u.MapFrom(us => us.SubscriptionUser.Places.Count))
            .ForMember("SubscriptionUserId", u => u.MapFrom(us => us.SubscriptionUser.UserName))
            ).CreateMapper();
            List<SubscriptionsManageDTO> subscriptions = new List<SubscriptionsManageDTO>();
            if (userId != null)
            {
                subscriptions = config.Map<IEnumerable<Subscription>, List<SubscriptionsManageDTO>>(Database.SubscriptionManager.Find(u => u.SubscriberId == userId));
            }

            return subscriptions;
        }

        public async Task<string> GetSubscriptionIdByName(string userName)
        {
            ApplicationUser user = await Database.UserManager.FindByNameAsync(userName);
            return user.Id.ToString();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
