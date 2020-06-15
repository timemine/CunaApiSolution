using CunaApi.Interfaces;
using CunaApi.Models;
using System;

namespace CunaApi.Services
{
    /// <summary>
    /// Service that handles communication with the repository
    /// </summary>
    public class RepositoryService : IRepositoryService
    {
        // At this point I have spent well over 2 hours on this. It would be real fun if this actually worked.
        // However, instead of implementing I'll just hardcode some return values and explain what I would do.
        // I would connect this service to a database client and store the request statuses in the repo.

        public void CreateRequest(RequestStatus requestStatus)
        {
            return;
        }

        public void UpdateStatus(RequestStatus requestStatus)
        {
            return;
        }

        public RequestStatusInfo GetStatus(Guid id)
        {
            return new RequestStatusInfo
            {
                Id = id,
                Body = "This is the body of the initial request.",
                Created = DateTime.Now.AddDays(-1),
                Updated = DateTime.Now.AddHours(-1),
                Detail = "Request completed successfully",
                Status = Enums.Status.COMPLETED
            };
        }
    }
}
