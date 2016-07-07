using System;
using PlaceSharer.DAL.Entities;

namespace PlaceSharer.DAL.Interfaces
{
    public interface IPlaceManager : IDisposable
    {
        void Create(Place item);
    }
}
