using CunaApi.Interfaces;
using CunaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CunaApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class RequestController : ControllerBase
    {
        // NOTES:   
        // I would typically make the methods asynchronous because it's more work to implement asynchronisity later. 
        // However, because it's a small sample API I think it would be outside of the current scope.

        private readonly ILogger<RequestController> _logger;
        private readonly IRequestHandlerService _requestHandlerService;

        public RequestController(IRequestHandlerService requestHandlerService, ILogger<RequestController> logger)
        {
            _requestHandlerService = requestHandlerService;
            _logger = logger;
        }

        // POST: /request
        [HttpPost("request")]
        public ActionResult<string> Post([FromBody] ClientRequest request)
        {
            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status501NotImplemented);
        }

        // POST: /{id}
        [HttpPost("{id}")]
        public ActionResult Callback([FromRoute] Guid id)
        {
            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status501NotImplemented);
        }

        // PUT: /{id}
        [HttpPut("{id}")]
        public ActionResult Callback([FromBody] RequestStatus requestStatus)
        {
            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status501NotImplemented);
        }

        // GET: /status/{id}
        [HttpGet("status/{id}")]
        public ActionResult<RequestStatusInfo> Status([FromRoute] Guid id)
        {
            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status501NotImplemented);
        }
    }
}
