namespace CunaApi.Models
{
    /// <summary>
    /// Enums available for use in the application
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// List of available statuses
        /// </summary>
        /// <remarks>Verified: According to Merriam-Webster statuses is the plural of status.</remarks>
        public enum Status
        {
            NONE,
            INITIALIZED,
            STARTED,
            PROCESSED,
            COMPLETED,
            ERROR
        }
    }
}
