using System;
using System.Collections.Generic;
using customer_information_api.V1.Domain;

namespace customer_information_api.V1.Boundary
{
    public class ListTransactionsResponse
    {
        public readonly ListTransactionsRequest Request;
        public readonly DateTime GeneratedAt;
        public readonly List<Transaction> Transactions;

        public ListTransactionsResponse(List<Transaction> transactions, ListTransactionsRequest request, DateTime generatedAt)
        {
            Request = request;
            GeneratedAt = generatedAt;
            Transactions = transactions;
        }
    }
}
