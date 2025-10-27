
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workify.Core.Entities.User;

namespace Workify.Core.Entities.Employer
{
    public class EmployerEntity
    {
        private EmployerEntity() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public EmployerSettingsEntity EmployerSettings { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = default!;

        static public EmployerEntity Create()
        {
            return new EmployerEntity();
        }
    }
}
