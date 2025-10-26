using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class JobSeekerRepository
    {
        private readonly MyDBContext _context;

        public JobSeekerRepository(MyDBContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<JobSeekerEntity>> GetUsers()
        {
            return await _context.JobSeeker.ToListAsync();
        }

        public async Task<JobSeekerEntity?> GetUserById(string id)
        {
            return await _context.JobSeeker.FindAsync(id);
        }

        public async Task<JobSeekerEntity?> GetUserByEmail(string email)
        {
            return await _context.JobSeeker.FirstOrDefaultAsync((entiti) => entiti.Email == email);
        }

        public async Task AddUser(JobSeekerEntity user)
        {
            await _context.JobSeeker.AddAsync(user);
            await _context.SaveChangesAsync();

        }
    }
}
