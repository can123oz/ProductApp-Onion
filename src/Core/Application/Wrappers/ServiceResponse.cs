using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Wrappers
{
    public class ServiceResponse<T> 
    {
        public T Value { set; get; }
        public ServiceResponse(T value)
        {
            Value = value;
        }
        public ServiceResponse()
        {

        }
    }
}
