using Newtonsoft.Json;
using System.Net;

namespace Application.Utilities.Common.Responses.Abstract
{
    public interface IResponseStatus
    {
        [JsonProperty("statusCode")]
        public HttpStatusCode StatusCode { get; }
    }
}
