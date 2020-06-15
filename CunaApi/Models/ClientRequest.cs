using System;

namespace CunaApi.Models
{
    /// <summary>
    /// Client request object with a body
    /// </summary>
    /// <remarks>Didn't name this class Request to avoid confusion/annoyances with C# Request class</remarks>
    public class ClientRequest
    {
        /// <summary>
        /// The unique id for the request
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The body of the client request
        /// </summary>
        public string Body { get; set; }
    }
}
