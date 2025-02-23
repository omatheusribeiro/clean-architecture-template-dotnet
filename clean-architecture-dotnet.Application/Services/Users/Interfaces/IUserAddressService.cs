using clean_architecture_dotnet.Application.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_dotnet.Application.Services.Users.Interfaces
{
    public interface IUserAddressService
    {
        Task<IActionResult> Put(UserAddressViewModel address);
    }
}
