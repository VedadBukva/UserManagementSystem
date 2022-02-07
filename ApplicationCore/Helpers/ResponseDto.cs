using System.Net;

namespace ApplicationCore.Helpers
{
    public class ResponseDto<T>
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
