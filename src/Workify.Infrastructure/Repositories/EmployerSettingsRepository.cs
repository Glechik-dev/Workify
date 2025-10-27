using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class EmployerSettingsRepository
    {
        private readonly MyDBContext _context;
        public EmployerSettingsRepository(MyDBContext context) 
        { 
            _context = context;
        }

    }
}
