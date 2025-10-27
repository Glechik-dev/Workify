using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities.Other;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class RoleRepository
    {
        private readonly MyDBContext _context;

        public RoleRepository(MyDBContext context) 
        { 
            _context = context;
        }
        public async Task<RoleEntity> FindRoleByName(string roleName)
        {
            return await _context.Role.FirstOrDefaultAsync((e) => e.RoleName == roleName);
        }
    }
}
