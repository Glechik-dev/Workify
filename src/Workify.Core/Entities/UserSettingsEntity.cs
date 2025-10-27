using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Workify.Core.Entities
{
    public class UserSettingsEntity
    {

        private UserSettingsEntity(bool isActive) 
        { 
            IsActive = isActive;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        static public UserSettingsEntity Create(bool isActive)
        {
            return new UserSettingsEntity(isActive);
        }
    }
}
