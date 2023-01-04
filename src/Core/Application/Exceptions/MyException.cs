using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class MyException : Exception
    {
        public MyException() : base("My error occured")
        {

        }

        public MyException(string message): base(message)
        {
                
        }

        public MyException(Exception e) : this(e.Message)
        {

        }
    }
}
