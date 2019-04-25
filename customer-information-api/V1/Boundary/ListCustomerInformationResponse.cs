using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Domain;

namespace customer_information_api.V1.Boundary
{
    public class ListCustomerInformationResponse
    {
        public ListCustomerInformationRequest request { get; set; }
        public List<CustomerInformation> result { get; set; }
        public ListCustomerInformationResponse(ListCustomerInformationRequest listCustomerInformationRequest, List<CustomerInformation> expectedResult)
        {
            request = listCustomerInformationRequest;
            result = expectedResult;
        }
    }
}
