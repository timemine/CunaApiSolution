using CunaApi.Interfaces;
using CunaApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CunaApi.Services
{
    /// <summary>
    /// Service that handles api requests
    /// </summary>
    public class RequestHandlerService : IRequestHandlerService
    {
        // I would want to implement logging in this layer. Probably try/catch -> log -> throw (Not throw new. Don't want to lose the callstack)
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
        public async Task<Guid> InitiateRequestAsync(ClientRequest request, string appUrlPath)
        {
            var requestGuid = Guid.NewGuid();
            request.Id = requestGuid;
            var callback = new RequestCallback
            {
                Id = requestGuid,
                Body = request.Body,
                Callback = $"{appUrlPath}/{requestGuid}"
            };

            // If there are any errors in the api service it will throw an exception so the request will not be called. 
            // By awaiting we guarantee we won't miss the exception. There's no need for a try/catch because ApiController
            // has built in exception handling.
            await _thirdPartyApiService.InitiateRequestAsync(callback);

            // Could easily make this method async, but that's not necessary for this
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
