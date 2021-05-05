using System;
using Application.Base;

namespace Application.Exceptions
{
    public class ServiceException : Exception
    {
        public BaseResponse Response { get; set; }

        public ServiceException(BaseResponse response, Exception innerException = default) : base(response.Message, innerException)
        {
            Response = response;
        }
    }
}