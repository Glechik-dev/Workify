using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workify.Application.Services;
using Workify.Infrastructure.Repositories;

namespace Workify.Api.Controllers
{
    [Route("api/resumes")]
    [ApiController]
    public class ResumesController : ControllerBase
    {
        private readonly ResumeService _resumeService;
        public ResumesController(ResumeService resumeService) 
        { 
            _resumeService = resumeService;
        }


        [HttpGet("all")]
        public Task GetAllResumes()
        {
            return null;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ResumePages>> GetResumeById(string Id)
        {

            return Ok();
        }

        [HttpGet("create")]
        public Task CreateResume()
        {
            return null;
        }
    }
}
