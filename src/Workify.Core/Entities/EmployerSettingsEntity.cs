using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workify.Core.Entities
{
    public class EmployerSettingsEntity
    {
        private EmployerSettingsEntity() 
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public bool IsActive { get; private set; }

        public Guid EmployerId { get; set; }
        public EmployerEntity Employer { get; set; }

        static public EmployerSettingsEntity Create()
        {
            return new EmployerSettingsEntity();
        }

    }
}
