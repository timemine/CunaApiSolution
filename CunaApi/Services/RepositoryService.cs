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
        public void CreateRequest(RequestStatus requestStatus)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(RequestStatus requestStatus)
        {
            throw new NotImplementedException();
        }

        public RequestStatusInfo GetStatus(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
