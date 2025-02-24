using clean_architecture_dotnet.Application.Models.Http;

namespace clean_architecture_dotnet.Application.Services.Login.Interfaces
{
    public interface ILoginService
    {
        Task<Result<string>> GetLogin(string email);
    }
}
