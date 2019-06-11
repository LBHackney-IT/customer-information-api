using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using customer_information_api.Tests.V1.Helper;
using customer_information_api.V1.Domain;
using customer_information_api.V1.Gateways;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnitTests;

namespace customer_information_api.Tests.V1.Gateways
{
    [TestFixture()]
    public class CustomerInformationGatewayTests : DbTest
    {
        private readonly Faker _faker = new Faker();
        private CustomerInformationGateway _classUnderTest;
        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new CustomerInformationGateway(_uhContext);
        }

        [Test]
        public void ListOfCustomersImplementBoundaryInterface()
        {
            Assert.NotNull(_classUnderTest is ICustomerInformationGateway);
        }

        [Test]
        public void CallingTheGatewayShouldReturnNullIfNoMatches()
        {
            var  response = _classUnderTest.GetCustomerInformationByTagReference("Test");
            Assert.AreEqual(0, response.Count);
            Assert.AreEqual(null, response.FirstOrDefault());
        }

        [Test]
        public void CallingTheGatewayShouldReturnACollectionOfCustomers()
        {
            CustomerInformation customerInformation = CustomerInformationHelper.CreateCustomerInformation();
            DbSet<CustomerInformation>
            _uhContext.Database.
        }


    }
}
