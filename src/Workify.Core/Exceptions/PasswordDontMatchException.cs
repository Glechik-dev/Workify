using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workify.Core.Exceptions
{
    public class PasswordDontMatchException : Exception
    {
        public PasswordDontMatchException() :base("Password don`t match") { }

        public PasswordDontMatchException(string message) : base(message) { }
    }
}
