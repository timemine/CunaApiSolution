using Microsoft.Extensions.Logging;
using CunaApi.Interfaces;
using CunaApi.Models;
using System;

namespace CunaApi.Services
{
    /// <summary>
    /// Service that handles api requests
    /// </summary>
    public class RequestHandlerService : IRequestHandlerService
    {
        private readonly ILogger<RequestHandlerService> _logger;
        private readonly IThirdPartyApiService _thirdPartyApiService;
        private readonly IRepositoryService _repositoryService;

        public RequestHandlerService(IThirdPartyApiService thirdPartyApiService, IRepositoryService repositoryService, ILogger<RequestHandlerService> logger)
        {
            _thirdPartyApiService = thirdPartyApiService;
            _repositoryService = repositoryService;
            _logger = logger;
        }

        public Guid InitiateRequest(ClientRequest request)
        {
            throw new NotImplementedException();
        }

        public void SetStartStatus(Guid id)
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
