using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workify.Core.Entities
{
    public class UserEntity
    {

        private UserEntity(string firstName, string secondName, string phoneNumber, string email, string password)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            SecondName = secondName;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string? SecondName { get; set; }


        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public TokenEntity Token { get; set; }

        public ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRoleEntity>();

        public JobSeekerEntity? JobSeeker { get; set; }
        public EmployerEntity? Employer { get; set; }

        public static UserEntity Create(string firstName, string secondName, string phoneNumber, string email, string password)
        {
            return new UserEntity(firstName, secondName, phoneNumber, email, password);
        }
    }
}
