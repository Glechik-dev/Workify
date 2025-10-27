using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities.Employer;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{
    public class EmployerRepository
    {
        private readonly MyDBContext _context;
        public EmployerRepository(MyDBContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<EmployerEntity>> GetEmployers()
        {
            return await _context.Employer.ToListAsync();
        }

        public async Task<EmployerEntity> FindEmployerById(Guid id)
        {
            return await _context.Employer.FindAsync(id);
        }

        public async Task AddEmployer(EmployerEntity employer)
        {
            await _context.Employer.AddAsync(employer);
            await _context.SaveChangesAsync();
        }
    }
}
