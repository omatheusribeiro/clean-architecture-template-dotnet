using AutoMapper;
using clean_architecture_dotnet.Application.Models.Http;
using clean_architecture_dotnet.Application.Services.Users.Interfaces;
using clean_architecture_dotnet.Application.ViewModels.Users;
using clean_architecture_dotnet.Domain.Entities.Users;
using clean_architecture_dotnet.Infrastructure.Repositories.Users.Interfaces;

namespace clean_architecture_dotnet.Application.Services.Users
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<UserViewModel>>> GetAll()
        {
            try
            {
                var users = await _userRepository.GetAll();

                if (users is null)
                    return Result<IEnumerable<UserViewModel>>.Fail("Unable to identify users in the database.", 404);

                var mapUsers = _mapper.Map<IEnumerable<UserViewModel>>(users);

                return Result<IEnumerable<UserViewModel>>.Ok(mapUsers);

            }
            catch (Exception ex)
            {
                return Result<IEnumerable<UserViewModel>>.Fail("There was an error listing users: " + ex.Message, 500);
            }

        }

        public async Task<Result<UserViewModel>> GetById(int id)
        {
            try
            {
                var user = await _userRepository.GetById(id);

                if (user is null)
                    return Result<UserViewModel>.Fail("User not found.", 404);

                var mapUser = _mapper.Map<UserViewModel>(user);

                return Result<UserViewModel>.Ok(mapUser);
            }
            catch (Exception ex)
            {
                return Result<UserViewModel>.Fail("There was an error when searching for the user: " + ex.Message, 500);
            }

        }

        public async Task<Result<UserViewModel>> Put(UserViewModel user)
        {
            try
            {
                var mapUser = _mapper.Map<User>(user);

                var result = await _userRepository.Put(mapUser);

                var mapUserModel = _mapper.Map<UserViewModel>(result);

                return Result<UserViewModel>.Ok(mapUserModel);
            }
            catch (Exception ex)
            {
                return Result<UserViewModel>.Fail("There was an error editing the user: " + ex.Message, 500);
            }

        }

        public async Task<Result<UserViewModel>> Post(UserViewModel user)
        {
            try
            {

                var mapUser = _mapper.Map<User>(user);

                var result = await _userRepository.Post(mapUser);

                var mapUserModel = _mapper.Map<UserViewModel>(result);

                return Result<UserViewModel>.Ok(mapUserModel);
            }
            catch (Exception ex)
            {
                return Result<UserViewModel>.Fail("There was an error registering the user: " + ex.Message, 500);
            }

        }

        public async Task<Result<UserViewModel>> Delete(UserViewModel user)
        {
            try
            {

                var mapUser = _mapper.Map<User>(user);

                var result = await _userRepository.Delete(mapUser);

                var mapUserModel = _mapper.Map<UserViewModel>(result);

                return Result<UserViewModel>.Ok(mapUserModel);
            }
            catch (Exception ex)
            {
                return Result<UserViewModel>.Fail("There was an error deleting the user: " + ex.Message, 500);
            }

        }
    }
}
