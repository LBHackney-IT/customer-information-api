using Microsoft.EntityFrameworkCore;
using customer_information_api.V1.Domain;

namespace customer_information_api.V1.Infrastructure
{
    public interface IUHContext
    {
        DbSet<UhTransaction> UTransactions { get; set; }
    }
}
