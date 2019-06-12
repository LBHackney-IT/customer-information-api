using Microsoft.EntityFrameworkCore;

namespace customer_information_api.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UhCustomerInformation> uHCustomerInformations { get; set; }
        public DbSet<UhAgreement> uHAgreements { get; set; }


    }
}
