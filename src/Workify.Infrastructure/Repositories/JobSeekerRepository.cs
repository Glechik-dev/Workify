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

        public async Task<IEnumerable<JobSeekerEntity>> GetJobSeeker()
        {
            return await _context.JobSeeker.ToListAsync();
        }

        public async Task<JobSeekerEntity?> GetJobSeekerById(string id)
        {
            return await _context.JobSeeker.FindAsync(id);
        }

        public async Task AddJobSeeker(JobSeekerEntity jobSeeker)
        {
            await _context.JobSeeker.AddAsync(jobSeeker);
            await _context.SaveChangesAsync();

        }
    }
}
