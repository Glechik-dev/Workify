using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workify.Core.Entities.Other;

namespace Workify.Core.Entities.User
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
