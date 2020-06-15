using CunaApi.Interfaces;
using CunaApi.Models;
using CunaApi.Services;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CunaApiTests.Services
{
    /// <summary>
    /// Only demonstrating unit tests for this class and a single method for brevity. 
    /// All tests are written with TDD
    /// </summary>
    class RequestHandlerServiceTests
    {
        private RequestHandlerService _requestHandlerService;
        private Mock<IThirdPartyApiService> _thirdPartyService;
        private Mock<IRepositoryService> _repositoryService;
        private ILogger<RequestHandlerService> _logger;
        private Guid _guid = new Guid("6c53e707-7582-4afe-9261-68eae0eb0bda");
        private string _appPath = "http://www.mypath.com";

        [SetUp]
        public void Setup()
        {
            _thirdPartyService = new Mock<IThirdPartyApiService>();
            _repositoryService = new Mock<IRepositoryService>();

            ILoggerFactory loggerFactory = new LoggerFactory(); ;
            _logger = loggerFactory.CreateLogger<RequestHandlerService>();

            _requestHandlerService = new RequestHandlerService(_thirdPartyService.Object, _repositoryService.Object, _logger);
        }

        #region InitiateRequest(ClientRequest request)

        [Test]
        public async Task InitiateRequest_CallsThirdPartyServiceToInitiateRequest_IfSuccessful()
        {
            // Arrange 
            var clientRequest = new ClientRequest { Body = "This is the body of the request" };

            // Act
            var result = await _requestHandlerService.InitiateRequestAsync(clientRequest, _appPath);

            // Assert
            _thirdPartyService.Verify(x => x.InitiateRequestAsync(It.IsAny<RequestCallback>()), Times.Once());
        }

        [Test]
        public async Task InitiateRequest_CallsRepoToStartRequest_IfSuccessful()
        {
            // Arrange 
            var clientRequest = new ClientRequest { Body = "This is the body of the request" };

            // Act
            var result = await _requestHandlerService.InitiateRequestAsync(clientRequest, _appPath);

            // Assert
            _repositoryService.Verify(x => x.CreateRequest(It.IsAny<RequestStatus>()), Times.Once());
        }

        [Test]
        public async Task InitiateRequest_ReturnsNonEmptyUniqueIdOfCreatedRequest_IfSuccessful()
        {
            // Arrange 
            var clientRequest = new ClientRequest { Body = "This is the body of the request" };

            // Act
            var result = await _requestHandlerService.InitiateRequestAsync(clientRequest, _appPath);

            // Assert
            Assert.That(result, Is.Not.EqualTo(Guid.Empty));
            Assert.That(result, Is.TypeOf<Guid>());
        }

        [Test]
        public void InitiateRequest_ThrowsException_IfExceptionOccursInThirdParty()
        {
            // Arrange 
            var clientRequest = new ClientRequest { Body = "This is the body of the request" };
            _thirdPartyService.Setup(x => x.InitiateRequestAsync(It.IsAny<RequestCallback>())).ThrowsAsync(new Exception());

            // Act && Assert
            Assert.That(async () => await _requestHandlerService.InitiateRequestAsync(clientRequest, _appPath), Throws.Exception);
        }

        #endregion InitiateRequest(ClientRequest request)
    }
}
