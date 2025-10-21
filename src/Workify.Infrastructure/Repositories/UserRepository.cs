using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly MyDBContext _context;

        public UserRepository(MyDBContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<UserEntity> GetUserById(string id)
        {
            return await _context.User.FindAsync(id);
        }

        public async void AddUser(UserEntity user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

        }
    }
}
