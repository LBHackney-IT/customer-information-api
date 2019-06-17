using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Domain;

namespace customer_information_api.V1.Boundary
{
    public class GetCustomersUseCaseResponse
    {
        public GetCustomersUseCaseRequest request { get; set; }
        public List<Customer> result { get; set; }
        public GetCustomersUseCaseResponse(GetCustomersUseCaseRequest getCustomersRequest, List<Customer> expectedResult)
        {
            request = getCustomersRequest;
            result = expectedResult;
        }
    }
}
