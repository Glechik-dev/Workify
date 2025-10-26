using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities;
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

        public async Task<JobSeekerSettingsEntity> GetSettingsById(string userId)
        {
            if (!Guid.TryParse(userId, out Guid guUserId))
                return null;

            return await _context.JobSeekerSettings.FirstOrDefaultAsync(entity => entity.JobSeekerId == guUserId);
        }

        public async Task AddSettingToUser(JobSeekerSettingsEntity userSettings)
        {
            await _context.JobSeekerSettings.AddAsync(userSettings);
            await _context.SaveChangesAsync();
        }
    }
}
