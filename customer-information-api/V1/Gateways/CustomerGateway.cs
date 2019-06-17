using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Domain;
using customer_information_api.V1.Gateways;
using customer_information_api.V1.Infrastructure;

namespace customer_information_api.V1.Gateways
{
    public class CustomerGateway : ICustomerGateway
    {
        private readonly IUHContext _uhContext;
        private readonly CustomerFactory _customerFactory; //this is not being used due to the nature of the query

        public CustomerGateway(IUHContext uhContext)
        {
            _customerFactory = new CustomerFactory();
            _uhContext = uhContext;
        }
        public List<Customer> GetCustomersByTagReference(string tagReference)
        {
            List<Customer> customers = _uhContext.UhAgreements.Where(a => a.TagRef == tagReference)
                .Join(_uhContext.UhCustomers, a => a.HouseRef, c => c.HouseRef, (a, c) =>
                new Customer
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

    internal class CustomerFactory
    {
    }
}
