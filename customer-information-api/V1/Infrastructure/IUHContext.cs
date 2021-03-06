using Microsoft.EntityFrameworkCore;
using customer_information_api.V1.Domain;

namespace customer_information_api.V1.Infrastructure
{
    public interface IUHContext
    {
        DbSet<UhAgreement> UhAgreements { get; set; }
        DbSet<UhCustomerInformation> UhCustomerInformations { get; set; }
    }
}
