using AutoMapper;
using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Users.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Users;
using clean_architecture_dotnet.Domain.Entities.Users;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;

namespace clean_architecture_dotnet.Application.Services.Users
{
    public class UserAddresService : IUserAddressService
    {
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;

        public UserAddresService(IMapper mapper, IUserAddressRepository userAddressRepository)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserAddressViewModel>> Put(UserAddressViewModel address)
        {
            try
            {
                var mapAddress = _mapper.Map<UserAddress>(address);

                var result = await _userAddressRepository.Put(mapAddress);

                var mapAddressModel = _mapper.Map<UserAddressViewModel>(result);

                return Result<UserAddressViewModel>.Ok(mapAddressModel);
            }
            catch (Exception ex)
            {
                return Result<UserAddressViewModel>.Fail("There was an error editing the user address: " + ex.Message, 500);
            }

        }
    }
}
