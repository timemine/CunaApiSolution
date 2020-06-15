using System;
using CunaApi.Models;

namespace CunaApi.Interfaces
{
    /// <summary>
    /// Interface for handling api requests.
    /// </summary>
    public interface IRequestHandlerService
    {
        /// <summary>
        /// Handles the initiation of a request
        /// </summary>
        /// <param name="request">The request to initialize</param>
        /// <returns>A <see cref="Guid"/> that is the unique identifier for the request</returns>
        Guid InitiateRequest(ClientRequest request);

        /// <summary>
        /// Sets the request as started
        /// </summary>
        /// <param name="id">The unique identifier for the request</param>
        void SetStartStatus(Guid id);

        /// <summary>
        /// Updates the status of the request
        /// </summary>
        /// <param name="requestStatus">The status and request information to update.</param>
        void UpdateStatus(RequestStatus requestStatus);

        /// <summary>
        /// Gets a <see cref="RequestStatusInfo"/> with the information about the current status of the request
        /// </summary>
        /// <param name="id">The unique identifier for the request</param>
        /// <returns>A <see cref="RequestStatusInfo"/> with the information about the current status of the request</returns>
        RequestStatusInfo GetStatus(Guid id);
    }
}
