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
            List<CustomerInformation> customers = _uhContext.UhAgreements.Where(a => a.TagRef == tagReference)
                .Join(_uhContext.UhCustomerInformations, a => a.HouseRef, c => c.HouseRef, (a, c) =>
                new CustomerInformation
                {
                    houseRef = a.HouseRef,
                    title = c.Title,
                    forenames = c.Forename,
                    surname = c.Surname,
                    nationalInsuranceNumber = c.Ni_No,
                    dateOfBirth = c.DOB,
                    gender = c.Gender,
                    tenancyRef = a.TagRef
                })
                .ToList();
 
            return customers;
        }
    }

    internal class CustomerInformationFactory
    {
    }
}
