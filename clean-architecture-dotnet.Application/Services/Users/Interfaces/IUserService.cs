using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.ViewModels.Users;

namespace clean_architecture_dotnet.Application.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserViewModel>>> GetAll();
        Task<Result<UserViewModel>> GetById(int id);
        Task<Result<UserViewModel>> Put(UserViewModel user);
        Task<Result<UserViewModel>> Post(UserViewModel user);
        Task<Result<UserViewModel>> Delete(int userId);
    }
}
