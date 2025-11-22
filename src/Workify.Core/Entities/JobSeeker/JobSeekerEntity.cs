using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workify.Core.Entities.Other;
using Workify.Core.Entities.User;

namespace Workify.Core.Entities.JobSeeker
{
    public class JobSeekerEntity
    {

        public JobSeekerEntity() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = default!;
        public JobSeekerSettingsEntity JobSeekerSettings { get; set; }
        public ResumeEntity Resume { get; set; }

        public ICollection<VacancyEntity> LikedVacancy { get; set; } = new List<VacancyEntity>();

        public ICollection<VacancyEntity> DislikedVacancy { get; set; } = new List<VacancyEntity>();

        static public JobSeekerEntity Create()
        {
            return new JobSeekerEntity();
        }
    }
}
