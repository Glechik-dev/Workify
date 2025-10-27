using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities.JobSeeker;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class JobSeekerSettingsRepository 
    {
        private readonly MyDBContext _context; 
        public JobSeekerSettingsRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<JobSeekerSettingsEntity> GetSettingsById(string jobSeekerId)
        {
            if (!Guid.TryParse(jobSeekerId, out Guid gujobSeekerId))
                return null;

            return await _context.JobSeekerSettings.FirstOrDefaultAsync(entity => entity.JobSeekerId == gujobSeekerId);
        }

        public async Task AddSettingToJobSeeker(JobSeekerSettingsEntity jobSeekerSettings)
        {
            await _context.JobSeekerSettings.AddAsync(jobSeekerSettings);
            await _context.SaveChangesAsync();
        }
    }
}
