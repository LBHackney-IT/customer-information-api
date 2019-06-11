using Microsoft.EntityFrameworkCore;

namespace customer_information_api.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UhCustomerInformation> uCustomerInformations { get; set; }

    }
}
