using AutoMapper;
using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Users.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Users;
using clean_architecture_dotnet.Domain.Entities.Users;
using clean_architecture_dotnet.Infrastructure.Repositories.Users;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clean_architecture_dotnet.Application.Services.Users
{
    public class UserAddresService : IUserAddressService
    {
        private IUserAddressRepository _userAddressRepository;
        private readonly IMapper _mapper;

        public UserAddresService(IMapper mapper, IUserAddressRepository userAddressRepository)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<Result<UserAddressViewModel>> Put(UserAddressViewModel user)
        {
            try
            {
                var mapAddres = _mapper.Map<UserAddress>(user);

                var result = await _userAddressRepository.Put(mapAddres);

                var mapAddresModel = _mapper.Map<UserAddressViewModel>(result);

                return Result<UserAddressViewModel>.Ok(mapAddresModel);
            }
            catch (Exception ex)
            {
                return Result<UserAddressViewModel>.Fail("There was an error editing the user addres: " + ex.Message, 500);
            }

        }
    }
}
