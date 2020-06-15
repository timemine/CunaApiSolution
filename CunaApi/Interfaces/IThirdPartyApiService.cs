using CunaApi.Models;

namespace CunaApi.Interfaces
{
    /// <summary>
    /// Interface for facilitating third-party service communication.
    /// </summary>
    public interface IThirdPartyApiService
    {
        /// <summary>
        /// Initiates a request to the third party api
        /// </summary>
        /// <param name="callback">A <see cref="RequestCallback"/> object to relay a callback to the api.</param>
        /// <remarks>No response is expected from the call so returns void.</remarks>
        void InitiateRequest(RequestCallback callback);
    }
}
