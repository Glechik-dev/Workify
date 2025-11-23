using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workify.Core.Entities.User;

namespace Workify.Core.Entities.Other
{
    public class RoleEntity
    {

        private RoleEntity(string roleName)
        {
            RoleName = roleName;
        }


        public RoleEntity() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string RoleName { get; set; }

        public ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRoleEntity>();

        public static RoleEntity Create(string roleName)
        {
            return new RoleEntity(roleName);
        }

    }
}
