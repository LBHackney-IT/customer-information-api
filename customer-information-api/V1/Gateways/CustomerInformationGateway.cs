using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Domain;
using customer_information_api.V1.Gateways;
using customer_information_api.V1.Infrastructure;

namespace customer_information_api.V1.Gateways
{
    public class CustomerInformationGateway : ICustomerInformationGateway
    {
        private readonly IUHContext _uhContext;
        private readonly CustomerInformationFactory _customerInformationFactory;

        public CustomerInformationGateway(IUHContext uhContext)
        {
            _customerInformationFactory = new CustomerInformationFactory();
            _uhContext = uhContext;
        }
        public List<CustomerInformation> GetCustomerInformationByTagReference(string tagReference)
        {
            var customerInformation = new List<CustomerInformation>();

            return customerInformation;
        }
    }

    internal class CustomerInformationFactory
    {
    }
}
