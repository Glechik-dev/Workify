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
        public Guid Id { get; private set; }
        [Required]
        public string FirstName { get; private set; }

        public string? SecondName { get; private set; }


        [Required]
        public string PhoneNumber { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public string Password { get; private set; }
        public TokenEntity Token { get; private set; }
        public UserSettingsEntity UserSettings { get; private set; }
        public ICollection<UserRoleEntity> UserRoles { get; private set; } = new List<UserRoleEntity>();


        public static UserEntity Create(string firstName, string secondName, string phoneNubmer, string email, string password)
        {
            return new UserEntity(firstName, secondName, phoneNubmer, email, password);
        }
    }
}
