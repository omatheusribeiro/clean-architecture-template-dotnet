using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Login.Interfaces;
using clean_architecture_dotnet.Domain.Enums;
using clean_architecture_dotnet.Infrastructure.Authentication;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;

namespace clean_architecture_dotnet.Application.Services.Login
{
    public class LoginService : ILoginService
    {
        private IUserContactRepository _userContactRepository;
        private readonly TokenGenerator _tokenGenerator;

        public LoginService(IUserContactRepository userContactRepository, TokenGenerator tokenGenerator)
        {
            _userContactRepository = userContactRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<Result<string>> GetLogin(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return Result<string>.Fail("Unable to identify email in the database.", (int)HttpStatus.BadRequest);

                var result = await _userContactRepository.GetByEmail(email);

                if (result is null)
                    return Result<string>.Fail("Unable to identify email in the database.", (int)HttpStatus.BadRequest);

                var token = "Bearer " + _tokenGenerator.GenerateToken(result.Email);

                return Result<string>.Ok(token);

            }
            catch (Exception ex)
            {
                return Result<string>.Fail("There was an error generating the token: " + ex.Message);
            }

        }
    }
}
