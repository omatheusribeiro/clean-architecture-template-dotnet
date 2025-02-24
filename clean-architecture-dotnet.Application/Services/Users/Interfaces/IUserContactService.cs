using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.ViewModels.Users;

namespace clean_architecture_dotnet.Application.Services.Users.Interfaces
{
    public interface IUserContactService
    {
        Task<Result<UserContactViewModel>> Put(UserContactViewModel address);
    }
}
