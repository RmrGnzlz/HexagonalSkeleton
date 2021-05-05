using System.Collections.Generic;
using System.Net;

namespace Application.Base
{
    public interface IResponse<T>
    {
        public string Message { get; set; }
        public HttpStatusCode Code { get; set; }
        public bool State { get; set; }
        T Data { get; set; }
        public IDictionary<string, IEnumerable<string>> Errors { get; set; }
    }
}