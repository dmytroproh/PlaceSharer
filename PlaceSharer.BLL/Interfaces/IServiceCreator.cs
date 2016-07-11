namespace PlaceSharer.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);

        IPlaceService CreatePlaceService(string connection);
    }
}
