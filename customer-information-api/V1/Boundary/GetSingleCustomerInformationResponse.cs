using customer_information_api.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_information_api.V1.Boundary
{
    public class GetSingleCustomerInformationResponse
    {
        public GetSingleCustomerInformationRequest request { get; set; }
        public CustomerInformation result { get; set; }

        public GetSingleCustomerInformationResponse(GetSingleCustomerInformationRequest getSingleCustomerInformationRequest, CustomerInformation returnedResult)
        {
            request = getSingleCustomerInformationRequest;
            result = returnedResult;
        }
    }
}
