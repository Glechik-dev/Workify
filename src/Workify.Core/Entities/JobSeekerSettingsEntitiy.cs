using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities
{
    public class JobSeekerSettingsEntity
    {

        private JobSeekerSettingsEntity(bool isActive) 
        {
           Id = Guid.NewGuid();
           IsActive = isActive; 
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public bool IsActive { get; private set; }
        public Guid JobSeekerId { get; private set; }
        [Required]
        public JobSeekerEntity JobSeeker { get; private set; }

        public static JobSeekerSettingsEntity Create(bool isActive)
        {
            return new JobSeekerSettingsEntity(isActive);
        }
    }
}
