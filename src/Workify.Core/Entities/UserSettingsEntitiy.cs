using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workify.Core.Entities
{
    public class UserSettingsEntity
    {

        private UserSettingsEntity(bool isActive) 
        {
           Id = Guid.NewGuid();
           IsActive = isActive; 
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public bool IsActive { get; private set; }
        public Guid UserId { get; private set; }
        [Required]
        public UserEntity User { get; private set; }

        public static UserSettingsEntity Create(bool isActive)
        {
            return new UserSettingsEntity(isActive);
        }
    }
}
