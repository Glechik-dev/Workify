using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities
{
    public class RoleEntity
    {

        private RoleEntity(string roleName) 
        {
            RoleName = roleName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        [Required]
        public UserRoleEntity UserRole { get; set; }

        public static RoleEntity Create(string roleName)
        {
            return new RoleEntity(roleName);
        }

    }
}
