using clean_architecture_dotnet.Application.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_dotnet.Application.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> GetAll();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Put(UserViewModel user);
        Task<IActionResult> Post(UserViewModel user);
        Task<IActionResult> Delete(UserViewModel user);
    }
}
