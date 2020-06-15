using CunaApi.Interfaces;
using CunaApi.Models;
using CunaApi.Services;
using System;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

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
        public void InitiateRequest_CallsThirdPartyServiceToInitiateRequest_IsSuccessful()
        {
            // Arrange 
            var clientRequest = new ClientRequest { Body = "This is the body of the request" };

            // Act
            var result = _requestHandlerService.InitiateRequest(clientRequest, _appPath);

            // Assert
            _thirdPartyService.Verify(x => x.InitiateRequest(It.IsAny<RequestCallback>()), Times.Once());
        }

        [Test]
        public void InitiateRequest_CallsRepoToStartRequest_IsSuccessful()
        {
            // Arrange 
            var clientRequest = new ClientRequest { Body = "This is the body of the request" };

            // Act
            var result = _requestHandlerService.InitiateRequest(clientRequest, _appPath);

            // Assert
            _repositoryService.Verify(x => x.CreateRequest(It.IsAny<RequestStatus>()), Times.Once());
        }

        [Test]
        public void InitiateRequest_ReturnsNonEmptyUniqueIdOfCreatedRequest_IsSuccessful()
        {
            // Arrange 
            var clientRequest = new ClientRequest { Body = "This is the body of the request" };

            // Act
            var result = _requestHandlerService.InitiateRequest(clientRequest, _appPath);

            // Assert
            Assert.That(result, Is.Not.EqualTo(Guid.Empty));
            Assert.That(result, Is.TypeOf<Guid>());
        }

        #endregion InitiateRequest(ClientRequest request)
    }
}
