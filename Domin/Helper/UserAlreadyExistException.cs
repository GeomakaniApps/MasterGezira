using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException()
        {
        }

        public UserAlreadyExistException(string message) : base(message)
        {
            message = "User Already Exist";
        }

        public UserAlreadyExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
