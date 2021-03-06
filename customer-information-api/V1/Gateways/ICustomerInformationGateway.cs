using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Domain;

namespace customer_information_api.V1.Gateways
{
    public interface ICustomerInformationGateway
    {
        List<CustomerInformation> GetCustomerInformationByTagReference(string tagReference);
    }
}
