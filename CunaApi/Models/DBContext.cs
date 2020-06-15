using Microsoft.EntityFrameworkCore;

namespace CunaApi.Models
{
    /// <summary>
    /// Quick repo implementation to track request information
    /// </summary>
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<RequestStatusInfo> RequestStatusInfoSet { get; set; }
    }
}
