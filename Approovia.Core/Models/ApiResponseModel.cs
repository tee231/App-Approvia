using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approovia.Core.Models
{
   public class ApiResponseModel
    {
        public class APIResponseModel<T> where T : class
        {
            public bool RequestSuccessful { get; set; }
            public T ResponseData { get; set; }
            public string Message { get; set; }
            public string ResponseCode { get; set; }
        }


        public class ResponseModel<T>
        {
            public bool RequestSuccessful { get; set; }
            public T ResponseData { get; set; }
            public string Message { get; set; }
            public string ResponseCode { get; set; }


        }

        public class ResponseObject<T>
        {
            public bool RequestSuccessful { get; set; }
            public T ResponseData { get; set; }
            public string Message { get; set; }
            public string ResponseCode { get; set; }

            public static object Failed(object p, string msg)
            {
                return new ResponseObject<Object>
                {
                    RequestSuccessful = false,
                    Message = msg,
                    ResponseCode = "99",
                    ResponseData = p
                };
            }

            public static object Successful(object p, string msg)
            {
                return new ResponseObject<Object>
                {
                    RequestSuccessful = false,
                    Message = msg,
                    ResponseCode = "00",
                    ResponseData = p
                };
            }

        }
        public class WebApiResponses<T> where T : class
        {
            public static APIResponseModel<T> InvalidModel = new APIResponseModel<T>
            {
                RequestSuccessful = false,
                ResponseCode = "XX",
                Message = "Invalid Model",
                ResponseData = null
            };

            public static APIResponseModel<T> ErrorOccured(string errorMsg)
            {
                return new APIResponseModel<T>
                {
                    RequestSuccessful = false,
                    ResponseCode = "99",
                    Message = errorMsg,
                    ResponseData = null
                };
            }

            public static APIResponseModel<T> Successful(T model)
            {
                return new APIResponseModel<T>
                {
                    RequestSuccessful = true,
                    ResponseCode = "00",
                    Message = "Successful",
                    ResponseData = model
                };
            }
        }


    }
}
