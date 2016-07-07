using System;
using PlaceSharer.DAL.Entities;

namespace PlaceSharer.DAL.Interfaces
{
    public interface ILocationManager : IDisposable
    {
        void Create(Location item);
    }
}
