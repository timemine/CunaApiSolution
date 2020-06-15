using System;

namespace CunaApi.Models
{
    /// <summary>
    /// Information about the current status of the request
    /// </summary>
    /// 
    public class RequestStatusInfo : RequestStatus
    {
        /// <summary>
        /// The timestamp for when the request status was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The timestamp for when the request status was last updated
        /// </summary>
        public DateTime Updated { get; set; }
    }
}
