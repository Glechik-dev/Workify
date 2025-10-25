namespace Workify.Core.Exceptions
{
    public class UserNotExistsException : Exception
    {
        public UserNotExistsException() : base("There is no user with this email.") { }

        public UserNotExistsException(string message) : base(message) { }
    }
}
