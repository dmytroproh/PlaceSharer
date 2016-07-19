using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using PlaceSharer.DAL.Identity;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.Repositories;

namespace PlaceSharer.DAL.EF
{
    public class PlaceSharerDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            //var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            ApplicationRoleManager roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
            PlaceManager placeManager = new PlaceManager(context);
            SubscriptionManager subscriptionManger = new SubscriptionManager(context);

            //var userRole = new IdentityRole { Name = "user" };

            var roleUser = new ApplicationRole { Name = "user" };
            var roleAdmin = new ApplicationRole { Name = "admin" };
            roleManager.Create(roleUser);
            roleManager.Create(roleAdmin);

            var user1 = new ApplicationUser { Email = "alex@gmail.com", UserName = "alex@gmail.com" };
            var user2 = new ApplicationUser { Email = "john@yahoo.com", UserName = "john@yahoo.com" };
            var user3 = new ApplicationUser { Email = "jack@hotmail.com", UserName = "jack@hotmail.com" };
            string password1 = "123456";
            string password2 = "654321";

            var result = userManager.Create(user1, password1);
            var result1 = userManager.Create(user2, password2);
            var result2 = userManager.Create(user3, password1);

            if (result.Succeeded && result1.Succeeded && result2.Succeeded)
            {
                userManager.AddToRole(user1.Id, roleUser.Name);
                userManager.AddToRole(user2.Id, roleUser.Name);
                userManager.AddToRole(user3.Id, roleUser.Name);
            }

            Place place1 = new Place
            {
                Name = "Zylyany",
                Description = "Zylyany Aeroport",
                UserId = user1.Id,
                GeoLat = 50.411799459510576,
                GeoLong = 30.44328689575
            };

            Place place2 = new Place
            {
                Name = "Ocean Plaza",
                Description = "Ocean Plaza Shop",
                UserId = user2.Id,
                GeoLat = 50.41217639889114,
                GeoLong = 30.52225112915039
            };

            Place place3 = new Place
            {
                Name = "National Sport Complex",
                Description = "National Sport Complex",
                UserId = user2.Id,
                GeoLat = 50.4331264560791,
                GeoLong = 30.521564483642578
            };

            Place place4 = new Place
            {
                Name = "Hydropark",
                Description = "Hydropark Kyiv",
                UserId = user3.Id,
                GeoLat = 50.445808729341124,
                GeoLong = 30.5766677854453
            };

            Place place5 = new Place
            {
                Name = "National Circus",
                Description = "National Circus in Kyiv",
                UserId = user1.Id,
                GeoLat = 50.44766705287248,
                GeoLong = 30.492210388183594
            };


            Place place6 = new Place
            {
                Name = "Kontractova area",
                Description = "Kontractova area in Kyiv",
                UserId = user1.Id,
                GeoLat = 50.46613700635715,
                GeoLong = 30.514869689941406
            };

            placeManager.Create(place1);
            placeManager.Create(place2);
            placeManager.Create(place3);
            placeManager.Create(place4);
            placeManager.Create(place5);
            placeManager.Create(place6);

            Subscription subs1 = new Subscription()
            {
                SubscriberId = user1.Id,
                SubscriptionUserId = user2.Id
            };


            Subscription subs2 = new Subscription()
            {
                SubscriberId = user1.Id,
                SubscriptionUserId = user3.Id
            };

            Subscription subs3 = new Subscription()
            {
                SubscriberId = user2.Id,
                SubscriptionUserId = user3.Id
            };

            Subscription subs4 = new Subscription()
            {
                SubscriberId = user3.Id,
                SubscriptionUserId = user1.Id
            };

            Subscription subs5 = new Subscription()
            {
                SubscriberId = user2.Id,
                SubscriptionUserId = user3.Id
            };

            Subscription subs6 = new Subscription()
            {
                SubscriberId = user2.Id,
                SubscriptionUserId = user1.Id
            };

            subscriptionManger.Create(subs1);
            subscriptionManger.Create(subs2);
            subscriptionManger.Create(subs3);
            subscriptionManger.Create(subs4);
            subscriptionManger.Create(subs5);
            subscriptionManger.Create(subs6);


            base.Seed(context);
        }
    }
}
