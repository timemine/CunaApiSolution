using CunaApi.Models;
using System;

namespace CunaApi.Interfaces

{
    /// <summary>
    /// Interface for communication with repository.
    /// </summary>
    public interface IRepositoryService
    {
        /// <summary>
        /// Creates a new request status in the repository
        /// </summary>
        /// <param name="requestStatus">The status to create</param>
        void CreateRequest(RequestStatus requestStatus);

        /// <summary>
        /// Updates a request status in the repository
        /// </summary>
        /// <param name="requestStatus">The status to create</param>
        void UpdateStatus(RequestStatus requestStatus);

        /// <summary>
        /// Gets the current status of a request from the repository
        /// </summary>
        /// <param name="id">The unique identifier for the request to get</param>
        /// <returns>The <see cref="RequestStatusInfo"/> for the request</returns>
        RequestStatusInfo GetStatus(Guid id);
    }
}
