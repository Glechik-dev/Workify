using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities
{
    public class JobSeekerRoleEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Required] 
        public Guid JobSeekerId { get; set; }
        public JobSeekerEntity JobSeeker { get; set; }

        [Required]
        public Guid RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}
