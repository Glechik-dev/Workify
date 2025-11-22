using Workify.Core.Entities.User;
using Workify.Infrastructure.Repositories;

namespace Workify.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<ICollection<UserEntity>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
