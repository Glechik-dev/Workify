using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities
{
    public class UserRoleEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Required] 
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        [Required]
        public Guid RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}
