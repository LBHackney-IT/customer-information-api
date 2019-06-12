using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using customer_information_api.Tests.V1.Helper;
using customer_information_api.V1.Domain;
using customer_information_api.V1.Gateways;
using customer_information_api.V1.Infrastructure;
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

            UhCustomerInformation dbCustomerInformation =
                UhCustomerInformationHelper.CreateUhCustomerInformationFrom(customerInformation);

            UhAgreement dbAgreement = new UhAgreement()
            {
                HouseRef = dbCustomerInformation.HouseRef,
                TagRef = "000035/01",
                Active = _faker.Random.Bool(),
                AdditionalDebit = _faker.Random.Bool(),
                Committee =  _faker.Random.Bool(),
                CourtApp =  _faker.Random.Bool(),
                DtStamp = _faker.Date.Past(),
                Eviction =  _faker.Random.Bool(),
                FdCharge =  _faker.Random.Bool(),
                FreeActive =  _faker.Random.Bool(),
                OtherAccounts =  _faker.Random.Bool(),
                Terminated =  _faker.Random.Bool(),
                IntroDate = _faker.Date.Past(),
                ReceiptCard =  _faker.Random.Bool(),
                IntroExtDate = _faker.Date.Past(),
                PotentialEndDate = _faker.Date.Soon(),
                UPaymentExpected = _faker.Random.AlphaNumeric(3)
            };
            _uhContext.uHCustomerInformations.Add(dbCustomerInformation);
            _uhContext.uHAgreements.Add(dbAgreement);
            _uhContext.SaveChanges();

            var response = _classUnderTest.GetCustomerInformationByTagReference(dbCustomerInformation.HouseRef);
            Assert.NotNull(response.FirstOrDefault());
            Assert.AreEqual(dbAgreement.TagRef, response.FirstOrDefault().tenancyRef);
        }


    }
}
