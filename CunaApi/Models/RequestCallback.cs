using CunaApi.Models;

namespace CunaApi.Models
{
    public class RequestCallback : ClientRequest
    {
        /// <summary>
        /// The callback for the request
        /// </summary>
        public string Callback { get; set; }
    }
}
