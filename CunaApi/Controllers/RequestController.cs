using CunaApi.Interfaces;
using CunaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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
        public async Task<ActionResult<string>> PostAsync([FromBody] ClientRequest request)
        {
            var appUrlPath = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            var requestId = await _requestHandlerService.InitiateRequestAsync(request, appUrlPath);
            return Ok(requestId.ToString());
        }

        // POST: /{id}
        [HttpPost("{id}")]
        public ActionResult Callback([FromRoute] Guid id)
        {
            _requestHandlerService.SetStartStatus(id);
            return NoContent();
        }

        // PUT: /{id}
        [HttpPut("{id}")]
        public ActionResult Callback([FromBody] RequestStatus requestStatus)
        {
            _requestHandlerService.UpdateStatus(requestStatus);
            return NoContent();
        }

        // GET: /status/{id}
        [HttpGet("status/{id}")]
        public ActionResult<RequestStatusInfo> Status([FromRoute] Guid id)
        {
            return Ok(_requestHandlerService.GetStatus(id));
        }
    }
}
