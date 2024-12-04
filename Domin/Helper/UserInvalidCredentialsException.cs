using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public class UserInvalidCredentialsException : Exception
    {
        public UserInvalidCredentialsException()
        {
        }

        public UserInvalidCredentialsException(string message) : base(message)
        {
            message = "Invalid Credentials";
        }

        public UserInvalidCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
