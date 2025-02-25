using AutoMapper;
using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Users.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Users;
using clean_architecture_dotnet.Domain.Entities.Users;
using clean_architecture_dotnet.Domain.Enums;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;

namespace clean_architecture_dotnet.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IUserContactRepository _userContactRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IUserAddressRepository userAddressRepository,
            IUserContactRepository contactRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userAddressRepository = userAddressRepository;
            _userContactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<UserViewModel>>> GetAll()
        {
            try
            {
                var users = await _userRepository.GetAll();

                if (users is null)
                    return Result<IEnumerable<UserViewModel>>.Fail("Unable to identify users in the database.", (int)HttpStatus.NotFound);

                var mapUsers = _mapper.Map<IEnumerable<UserViewModel>>(users);

                return Result<IEnumerable<UserViewModel>>.Ok(mapUsers);

            }
            catch (Exception ex)
            {
                return Result<IEnumerable<UserViewModel>>.Fail("There was an error listing users: " + ex.Message, (int)HttpStatus.BadRequest);
            }

        }

        public async Task<Result<UserViewModel>> GetById(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);

                if (user is null)
                    return Result<UserViewModel>.Fail("User not found.", (int)HttpStatus.NotFound);

                var mapUser = _mapper.Map<UserViewModel>(user);

                return Result<UserViewModel>.Ok(mapUser);
            }
            catch (Exception ex)
            {
                return Result<UserViewModel>.Fail("There was an error when searching for the user: " + ex.Message, (int)HttpStatus.BadRequest);
            }

        }

        public async Task<Result<UserViewModel>> Put(UserViewModel user)
        {
            try
            {
                var mapUserModel = new UserViewModel();
                var mapAddressModel = new UserAddressViewModel();
                var mapContactModel = new UserContactViewModel();

                if (user is null)
                    return Result<UserViewModel>.Fail("There is missing information to perform user change.", (int)HttpStatus.NotFound);

                var userEntity = await _userRepository.GetById(user.Id);

                if (userEntity is null)
                    return Result<UserViewModel>.Fail("User not found.", (int)HttpStatus.NotFound);

                var mapUser = _mapper.Map<User>(user);

                var resultUser = await _userRepository.Put(mapUser);

                mapUserModel = _mapper.Map<UserViewModel>(resultUser);

                if (user.Address is not null)
                {
                    var addressEntity = await _userAddressRepository.GetById(user.Address.Id);

                    if (addressEntity is null)
                        return Result<UserViewModel>.Fail("Address not found.", (int)HttpStatus.NotFound);

                    var mapAddress = _mapper.Map<UserAddress>(user.Address);
                    var resultAddress = await _userAddressRepository.Put(mapAddress);
                    mapAddressModel = _mapper.Map<UserAddressViewModel>(resultAddress);
                    mapUserModel.Address = mapAddressModel;
                }

                if (user.Contact is not null)
                {
                    var contactEntity = await _userContactRepository.GetById(user.Contact.Id);

                    if (contactEntity is null)
                        return Result<UserViewModel>.Fail("Contact not found.", (int)HttpStatus.NotFound);

                    var mapContact = _mapper.Map<UserContact>(user.Contact);
                    var resultContact = await _userContactRepository.Put(mapContact);
                    mapContactModel = _mapper.Map<UserContactViewModel>(resultContact);
                    mapUserModel.Contact = mapContactModel;
                }

                return Result<UserViewModel>.Ok(mapUserModel);
            }
            catch (Exception ex)
            {
                return Result<UserViewModel>.Fail("There was an error editing the user: " + ex.Message, (int)HttpStatus.BadRequest);
            }

        }

        public async Task<Result<UserViewModel>> Post(UserViewModel user)
        {
            try
            {
                if(user is null)
                    return Result<UserViewModel>.Fail("There is missing information to perform user creation.", (int)HttpStatus.NotFound);

                if (user.Address is null)
                    return Result<UserViewModel>.Fail("There is missing information to perform user address creation.", (int)HttpStatus.NotFound);

                if (user.Contact is null)
                    return Result<UserViewModel>.Fail("There is missing information to perform user address creation.", (int)HttpStatus.NotFound);

                var mapUser = _mapper.Map<User>(user);
                var mapAddress = _mapper.Map<UserAddress>(user.Address);
                var mapContact = _mapper.Map<UserContact>(user.Contact);

                var resultUser = await _userRepository.Post(mapUser);
                var resultAddress = await _userAddressRepository.Post(mapAddress);
                var resultContact = await _userContactRepository.Post(mapContact);

                var mapUserModel = _mapper.Map<UserViewModel>(resultUser);
                var mapAddressModel = _mapper.Map<UserAddressViewModel>(resultAddress);
                var mapContactModel = _mapper.Map<UserContactViewModel>(resultContact);

                mapUserModel.Address = mapAddressModel;
                mapUserModel.Contact = mapContactModel;

                return Result<UserViewModel>.Ok(mapUserModel);
            }
            catch (Exception ex)
            {
                return Result<UserViewModel>.Fail("There was an error registering the user: " + ex.Message, (int)HttpStatus.BadRequest);
            }

        }

        public async Task<Result<UserViewModel>> Delete(UserViewModel user)
        {
            try
            {
                if (user is null)
                    return Result<UserViewModel>.Fail("There is missing information to delete the user.", (int)HttpStatus.NotFound);

                if (user.Address is null)
                    return Result<UserViewModel>.Fail("There is missing information to delete the user address.", (int)HttpStatus.NotFound);

                if (user.Contact is null)
                    return Result<UserViewModel>.Fail("There is missing information to delete the user contact.", (int)HttpStatus.NotFound);

                var userEntity = await _userRepository.GetById(user.Id);
                var addressEntity = await _userAddressRepository.GetById(user.Address.Id);
                var contactEntity = await _userContactRepository.GetById(user.Contact.Id);

                if (userEntity is null)
                    return Result<UserViewModel>.Fail("User not found.", (int)HttpStatus.NotFound);

                if (addressEntity is null)
                    return Result<UserViewModel>.Fail("Address not found.", (int)HttpStatus.NotFound);

                if (contactEntity is null)
                    return Result<UserViewModel>.Fail("Contact not found.", (int)HttpStatus.NotFound);

                var mapUser = _mapper.Map<User>(user);
                var mapAddress = _mapper.Map<UserAddress>(user.Address);
                var mapContact = _mapper.Map<UserContact>(user.Contact);

                var resultUser = await _userRepository.Delete(mapUser);
                var resultAddress = await _userAddressRepository.Delete(mapAddress);
                var resultContact = await _userContactRepository.Delete(mapContact);

                var mapUserModel = _mapper.Map<UserViewModel>(resultUser);

                return Result<UserViewModel>.Ok(mapUserModel);
            }
            catch (Exception ex)
            {
                return Result<UserViewModel>.Fail("There was an error deleting the user: " + ex.Message, (int)HttpStatus.BadRequest);
            }

        }
    }
}
