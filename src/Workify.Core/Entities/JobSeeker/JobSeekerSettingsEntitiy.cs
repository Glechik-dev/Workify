using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities.JobSeeker
{
    public class JobSeekerSettingsEntity
    {

        private JobSeekerSettingsEntity()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public Guid JobSeekerId { get; private set; }
        [Required]
        public JobSeekerEntity JobSeeker { get; private set; }

        public static JobSeekerSettingsEntity Create()
        {
            return new JobSeekerSettingsEntity();
        }
    }
}
