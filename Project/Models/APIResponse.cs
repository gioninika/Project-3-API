using System.Net;

namespace Project.Models
{
    public class APIResponse
    {
        public bool status { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public dynamic Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
