using System.Collections.Generic;
using customer_information_api.V1.Domain;

namespace customer_information_api.V1.Gateways
{
    public interface ITransactionsGateway
    {
        List<Transaction> GetTransactionsByPropertyRef(string propertyRef);
    }
}
