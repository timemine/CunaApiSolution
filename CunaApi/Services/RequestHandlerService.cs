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

        // appUrlPath is passed in from caller for unit testing simplification and to avoid having to  
        // create an extension to access context outside of controller
        public Guid InitiateRequest(ClientRequest request, string appUrlPath)
        {
            var requestGuid = Guid.NewGuid();
            request.Id = requestGuid;
            var callback = new RequestCallback
            {
                Id = requestGuid,
                Body = request.Body,
                Callback = $"{appUrlPath}/{requestGuid}"
            };
            _thirdPartyApiService.InitiateRequest(callback);
            _repositoryService.CreateRequest(new RequestStatus { Id = requestGuid, Body = request.Body, Status = Enums.Status.INITIALIZED, Detail = "Request initialized" });
            return requestGuid;
        }

        public void SetStartStatus(Guid id)
        {
            _repositoryService.UpdateStatus(new RequestStatus { Id = id, Status = Enums.Status.STARTED, Detail = "Request started" });
            return;
        }

        public void UpdateStatus(RequestStatus requestStatus)
        {
            _repositoryService.UpdateStatus(requestStatus);
            return;
        } 

        public RequestStatusInfo GetStatus(Guid id)
        {
            return _repositoryService.GetStatus(id);
        }
    }
}
