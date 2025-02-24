using clean_architecture_dotnet.Domain.Entities.Users;

namespace clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces
{
    public interface IUserContactRepository
    {
        Task<IEnumerable<UserContact>> GetAll();
        Task<UserContact> GetById(int id);
        Task<UserContact> Put(UserContact contact);
        Task<UserContact> Post(UserContact contact);
        Task<UserContact> Delete(UserContact contact);
    }
}
