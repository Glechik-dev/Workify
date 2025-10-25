using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities
{
    public class UserRoleEntity
    {

        private UserRoleEntity() 
        { 
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public UserEntity User { get; set; }

        [Required]
        public UserRoleEntity Role { get; set; }
    }
}
