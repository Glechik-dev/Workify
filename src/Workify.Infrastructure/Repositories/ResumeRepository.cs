using Microsoft.EntityFrameworkCore;
using Workify.Core.Entities.Other;
using Workify.Infrastructure.DBContext;

namespace Workify.Infrastructure.Repositories
{

    public class ResumePages
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public int totalPages { get; set; }
        public ICollection<ResumeEntity> resumes { get; set; }
    }

    public class ResumeRepository
    {
        private readonly MyDBContext _context;
        public ResumeRepository(MyDBContext context) 
        { 
            _context = context;
        }

        public async Task<ICollection<ResumeEntity>> GetAllResumes()
        {
            return await _context.Resume.ToListAsync();
        }

        public async Task<ResumePages> GetResumesByPage(int page, int pageSize)
        {
            var totalCount = await _context.Resume.CountAsync();
            ICollection<ResumeEntity> resumes = await _context.Resume.OrderBy(e => e.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new ResumePages { page = page, pageSize = pageSize, totalCount = totalCount, totalPages = (int)Math.Ceiling(totalCount / (double)pageSize), resumes = resumes };
        }
    }
}
