using Microsoft.EntityFrameworkCore;

namespace customer_information_api.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UhCustomerInformation> UhCustomerInformations { get; set; }
        public DbSet<UhAgreement> UhAgreements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //fluent API
        {
            //member table
            modelBuilder.Entity<UhCustomerInformation>()
                .Property(c => c.HouseRef).HasColumnName("house_ref");

            modelBuilder.Entity<UhCustomerInformation>()
                .Property(c => c.PersonNo).HasColumnName("person_no");

            modelBuilder.Entity<UhCustomerInformation>()
                .HasKey(c => new { c.HouseRef, c.PersonNo });

            //tenagree table
            modelBuilder.Entity<UhAgreement>()
                .Property(a => a.TagRef).HasColumnName("tag_ref");

            modelBuilder.Entity<UhAgreement>().HasKey(a => a.TagRef);
        }
    }
}
