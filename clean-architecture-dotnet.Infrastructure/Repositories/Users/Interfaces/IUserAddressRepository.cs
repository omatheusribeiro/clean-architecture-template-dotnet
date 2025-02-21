using clean_architecture_dotnet.Domain.Entities.Users;

namespace clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces
{
    public interface IUserAddressRepository
    {
        Task<IEnumerable<UserAddress>> GetAll();
        Task<UserAddress> GetById(int id);
        Task<UserAddress> Put(UserAddress address);
        Task<UserAddress> Post(UserAddress address);
        Task<UserAddress> Delete(UserAddress address);
    }
}
