
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workify.Core.Entities.Other;
using Workify.Core.Entities.User;

namespace Workify.Core.Entities.Employer
{
    public class EmployerEntity
    {
        private EmployerEntity() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public EmployerSettingsEntity EmployerSettings { get; set; }
        public EmployerCompanyEntity EmployerCompany { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = default!;

        public ICollection<VacancyEntity> Vacancies { get; set; } = new List<VacancyEntity>();

        public ICollection<ResumeEntity> LikedResume { get; set; } = new List<ResumeEntity>();

        public ICollection<ResumeEntity> DislikedResume { get; set; } = new List<ResumeEntity>();

        static public EmployerEntity Create()
        {
            return new EmployerEntity();
        }
    }
}
