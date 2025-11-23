using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Workify.Core.Entities.Employer;
using Workify.Core.Entities.JobSeeker;

namespace Workify.Core.Entities.Other
{
    public class ResumeEntity
    {
        private ResumeEntity() {} 


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [NotMapped]
        public int LikeCount => WhoLikes.Count;
        public ICollection<EmployerEntity> WhoLikes { get; set; } = new List<EmployerEntity>();

        [NotMapped]
        public int DislikeCount => WhoDislikes.Count;

        public ICollection<EmployerEntity> WhoDislikes { get; set; } = new List<EmployerEntity>();

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [ForeignKey(nameof(AuthorId))]
        public JobSeekerEntity Author { get; set; }

        [Required]
        public string PhoneNumber {  get; set; }
        public Guid CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public CityEntity City { get; set; }

        [Required]
        public int Age { get; set; }
        public ICollection<EducationEntity> Education { get; set; } = new List<EducationEntity>();
        public ICollection<LanguageSkillEntity> LanguageSkills { get; set; }

        [Required]
        public SallaryEntity Sallary { get; set; }

        [Required]
        public AdditionalEntity Additional { get; set; }

        public ICollection<ExperienceEntity> Experiences { get; set; } = new List<ExperienceEntity>();
        public ICollection<CourseEntity> Courses { get; set; } = new List<CourseEntity>();

        static public ResumeEntity Create()
        {
            return new ResumeEntity();
        }

    }
}
