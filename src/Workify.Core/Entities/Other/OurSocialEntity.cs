using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Workify.Core.Entities.Employer;
using Workify.Core.Entities.JobSeeker;

namespace Workify.Core.Entities.Other
{
    public class OurSocialEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string SocialName { get; set; }

        [Required]
        public string SocialUrl { get; set; }

        public Guid CompanyId { get; set; }
        public Guid JobSeekerId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public EmployerCompanyEntity Company { get; set; }

        [ForeignKey(nameof(JobSeekerId))]
        public JobSeekerEntity JobSeeker { get; set; }
    }
}
