using System.Collections.Generic;
using System.Linq;
using customer_information_api.V1.Domain;

namespace customer_information_api.V1.Factory
{
    public abstract class AbstractTransactionFactory
    {
        public abstract Transaction FromUhTransaction(UhTransaction transaction);

        public List<Transaction> FromUhTransaction(IEnumerable<UhTransaction> result)
        {
            return result.Select(FromUhTransaction).ToList();
        }
    }
}
