using AutoMapper;
using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Users.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Users;
using clean_architecture_dotnet.Domain.Entities.Users;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;

namespace clean_architecture_dotnet.Application.Services.Users
{
    public class UserContactService : IUserContactService
    {
        private readonly IUserContactRepository _userContactRepository;
        private readonly IMapper _mapper;

        public UserContactService(IMapper mapper, IUserContactRepository userContactRepository)
        {
            _userContactRepository = userContactRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserContactViewModel>> Put(UserContactViewModel user)
        {
            try
            {
                var mapContact = _mapper.Map<UserContact>(user);

                var result = await _userContactRepository.Put(mapContact);

                var mapContactModel = _mapper.Map<UserContactViewModel>(result);

                return Result<UserContactViewModel>.Ok(mapContactModel);
            }
            catch (Exception ex)
            {
                return Result<UserContactViewModel>.Fail("There was an error editing the user contact: " + ex.Message, 500);
            }

        }
    }
}
