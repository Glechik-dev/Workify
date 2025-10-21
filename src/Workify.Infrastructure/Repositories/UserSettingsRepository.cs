using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class UserSettingsRepository
    {
        private readonly MyDBContext _context; 
        public UserSettingsRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<UserSettingsEntity> GetSettingsById(string userId)
        {
            if (!Guid.TryParse(userId, out Guid guUserId))
                return null;

            return await _context.UserSettings.FirstOrDefaultAsync(entity => entity.UserId == guUserId);
        }

        public async Task AddSettingToUser(UserSettingsEntity userSettings)
        {
            await _context.UserSettings.AddAsync(userSettings);
            await _context.SaveChangesAsync();
        }
    }
}
