using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using static CunaApi.Models.Enums;

namespace CunaApi.Models
{
    /// <summary>
    /// The status of a request. 
    /// </summary>
    public class RequestStatus : ClientRequest
    {
        /// <summary>
        /// The status of the request
        /// </summary>
        [Required]
        public Status Status { get; set; }

        /// <summary>
        /// The details of the request status
        /// </summary>
        [Required]
        public string Detail { get; set; }
    }
}
