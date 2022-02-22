using Approovia.Core.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Approovia.Core.Utility.Constants;

namespace Approovia.Core.Exceptions
{
   public  class AlreadyExistException : BaseException
    {

        public AlreadyExistException(string message) : base(message)
        {
            Code = ResponseCodes.AlreadyExist;
            httpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }

        public AlreadyExistException(string message, string[] errors) : base(message)
        {
            Code = ResponseCodes.AlreadyExist; ;
            httpStatusCode = System.Net.HttpStatusCode.BadRequest;
            Errors = errors;
        }
    }
}
