using Workify.Core.Entities;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class UserRoleRepository
    {
        private readonly MyDBContext _context;
        public UserRoleRepository(MyDBContext context) 
        {
            _context = context;
        }

        public async Task AddRoleToUser(UserEntity user, RoleEntity role) 
        {
            await _context.UserRole.AddAsync(new UserRoleEntity { User = user, Role = role });
            await _context.SaveChangesAsync();
        }
    }
}
