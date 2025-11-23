using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Workify.Core.Entities.Employer;
using Workify.Core.Entities.JobSeeker;

namespace Workify.Core.Entities.Other
{
    public class ExperienceEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public string SpecialityName { get; set; }

        public string WorkDuration { get; set; }

        public Guid ResumeId { get; set; }

        [ForeignKey(nameof(ResumeId))]
        public ResumeEntity Resume  { get; set; }

    }
}
