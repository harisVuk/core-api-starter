using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Api.Utils
{
    public class ApiError
    {
        public ApiError()
        {
        }

        public ApiError(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
