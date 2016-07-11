using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using PlaceSharer.BLL.DTO;
using PlaceSharer.BLL.Infrastructure;
using PlaceSharer.BLL.Interfaces;
using PlaceSharer.DAL.Entities;
using PlaceSharer.DAL.Interfaces;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.Execution;
using AutoMapper.Mappers;
using AutoMapper.QueryableExtensions;

namespace PlaceSharer.BLL.Services
{
    public class PlaceService : IPlaceService
    {
        IUnitOfWork Database { get; set; }

        public PlaceService(IUnitOfWork db)
        {
            Database = db;
        }

        public async Task<OperationDetails> CreateAsync(PlaceDTO placeDto)
        {
            ApplicationUser currentUser = await Database.UserManager.FindByIdAsync(placeDto.UserId);
            if (currentUser != null)
            {
                Place place = new Place
                {
                    Name = placeDto.Name,
                    Description = placeDto.Description,
                    UserId = placeDto.UserId,
                    GeoLong = placeDto.GeoLong,
                    GeoLat = placeDto.GeoLat
                };

                //currentUser.Places.Add(place);
                Database.PlaceManager.Create(place);

                await Database.SaveAsync();
                return new OperationDetails(true, "Place added", "");
            }
            return new OperationDetails(false, "User with this Id already exists", "Id");
        }

        public Task<PlaceDTO> GetPlace(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaceDTO> GetPlacesByUserId(string UserId)
        {
            //return Mapper.Map<IEnumerable<Place>, List<PlaceDTO>>(Database.PlaceManager.GetAll());

            var config = new MapperConfiguration(r => r.CreateMap<Place, PlaceDTO>()).CreateMapper();
            var places = config.Map<IEnumerable<Place>, List<PlaceDTO>>(Database.PlaceManager.Find(u => u.UserId == UserId));
            return places;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}