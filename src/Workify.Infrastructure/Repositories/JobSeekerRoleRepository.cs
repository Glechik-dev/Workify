using Workify.Core.Entities;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class JobSeekerRoleRepository
    {
        private readonly MyDBContext _context;
        public JobSeekerRoleRepository(MyDBContext context) 
        {
            _context = context;
        }

        public async Task AddRoleToUser(JobSeekerEntity jobSeeker, RoleEntity role) 
        {
            await _context.JobSeekerRole.AddAsync(new JobSeekerRoleEntity { JobSeeker = jobSeeker, Role = role });
            await _context.SaveChangesAsync();
        }
    }
}
