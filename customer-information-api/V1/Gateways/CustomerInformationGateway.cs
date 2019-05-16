using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Domain;
using customer_information_api.V1.Gateways;

namespace customer_information_api.V1.Gateways
{
    public class CustomerInformationGateway : ICustomerInformationGateway
    {
        public List<CustomerInformation> GetCustomerInformationByTagReference(string tagReference)
        {
            throw new NotImplementedException();
        }
    }
}
