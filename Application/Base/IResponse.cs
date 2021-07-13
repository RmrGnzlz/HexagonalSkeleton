using System.Collections.Generic;
using System.Net;

namespace Application.Base
{
    public interface IResponse
    {
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public bool State { get; set; }
        public IDictionary<string, IEnumerable<string>> Errors { get; set; }
    }

    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
    }
}