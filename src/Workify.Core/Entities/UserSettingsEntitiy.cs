using System.ComponentModel.DataAnnotations;

namespace Workify.Core.Entities
{
    public class UserSettingsEntitiy
    {

        private UserSettingsEntitiy(bool isActive) 
        {
           Id = Guid.NewGuid();
           IsActive = isActive; 
        }
        [Key]
        public Guid Id { get; private set; }
        public bool IsActive { get; private set; }
        public Guid UserId { get; private set; }
        [Required]
        public UserEntitiy User { get; private set; }

        public static UserSettingsEntitiy Create(bool isActive)
        {
            return new UserSettingsEntitiy(isActive);
        }
    }
}
