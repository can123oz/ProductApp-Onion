using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Validation error occured")
        {

        }

        public ValidationException(string Message): base(Message)
        {

        }

        public ValidationException(Exception ex) : this(ex.Message)
        {

        }
    }
}
