using System;
using PlaceSharer.DAL.Entities;

namespace PlaceSharer.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
