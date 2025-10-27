using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities
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

        static public JobSeekerEntity Create()
        {
            return new JobSeekerEntity();
        }
    }
}
