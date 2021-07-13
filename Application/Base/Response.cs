using System.Collections.Generic;
using System.Net;

namespace Application.Base
{
    public abstract class BaseResponse : IResponse
    {
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public bool State { get; set; }
        public IDictionary<string, IEnumerable<string>> Errors { get; set; }
    }

    public class Response<T> : BaseResponse, IResponse<T>
    {
        public T Data { get; set; }

        public Response(string message, HttpStatusCode statusCode, bool status, T data = default)
        {
            Message = message;
            Code = statusCode;
            State = status;
            Data = data;
        }
    }
}