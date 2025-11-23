using Workify.Core.Entities.Other;
using Workify.Infrastructure.Repositories;

namespace Workify.Application.Services
{
    public class ResumeService
    {
        private readonly ResumeRepository _resumeRepository;
        public ResumeService(ResumeRepository resumeRepository) 
        { 
            _resumeRepository = resumeRepository;
        }

        public async Task<ICollection<ResumeEntity>> GetAllResumes()
        {
            return await _resumeRepository.GetAllResumes();
        }

        public async Task<ResumePages> GetReumesByPage(int page, int pageSize)
        {
            return await _resumeRepository.GetResumesByPage(page, pageSize);
        }

        public async Task CreateResume(ResumeDTO resumeDto)
        {
            await _resumeRepository.CreateResume(resumeDto);
        }
    }
}
