using customer_information_api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_information_api.V1.Boundary
{
    public class GetSingleCustomerResponse // I don't think this is needed anymore because we removed its action method
    {
        public GetSingleCustomerRequest request { get; set; }
        public Customer result { get; set; }

        public GetSingleCustomerResponse(GetSingleCustomerRequest getSingleCustomerRequest, Customer returnedResult)
        {
            request = getSingleCustomerRequest;
            result = returnedResult;
        }
    }
}
