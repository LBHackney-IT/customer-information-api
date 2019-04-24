using Microsoft.EntityFrameworkCore;
using customer_information_api.V1.Domain;

namespace customer_information_api.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UhTransaction> UTransactions { get; set; }
    }
}
