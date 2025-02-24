using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.ViewModels.Users;

namespace clean_architecture_dotnet.Application.Services.Users.Interfaces
{
    public interface IUserAddressService
    {
        Task<Result<UserAddressViewModel>> Put(UserAddressViewModel address);
    }
}
