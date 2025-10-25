using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public UserSettingsEntity UserSettings { get; set; }
        public ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRoleEntity>();


        public static UserEntity Create(string firstName, string secondName, string phoneNumber, string email, string password)
        {
            return new UserEntity(firstName, secondName, phoneNumber, email, password);
        }
    }
}
