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
        public void GivenAnUnmatchingTagRef_WhenAGatewayIsCalled_ThenItReturnsAnEmptyCollectionOfCustomers()
        {
            //arrange

            //act
            var response = _classUnderTest.GetCustomerInformationByTagReference("Test");

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IList<CustomerInformation>>(response); //check if it's a collection

            Assert.AreEqual(0, response.Count);
            Assert.AreEqual(null, response.FirstOrDefault());
        }

        [TestCase("000125/01", "000125")]
        [TestCase("000778/03", "000778")]
        public void GivenAMatchingTagRef_WhenAGatewayIsCalled_ThenItReturnsACollectionOfMathcingCustomers(string tagRef, string houseRef)
        {
            //arrange
            UhAgreement dbAgreement = new UhAgreement()
            {
                HouseRef = houseRef,
                TagRef = tagRef,
                Active = _faker.Random.Bool(),
                AdditionalDebit = _faker.Random.Bool(),
                Committee = _faker.Random.Bool(),
                CourtApp = _faker.Random.Bool(),
                DtStamp = _faker.Date.Past(),
                Eviction = _faker.Random.Bool(),
                FdCharge = _faker.Random.Bool(),
                FreeActive = _faker.Random.Bool(),
                OtherAccounts = _faker.Random.Bool(),
                Terminated = _faker.Random.Bool(),
                IntroDate = _faker.Date.Past(),
                ReceiptCard = _faker.Random.Bool(),
                IntroExtDate = _faker.Date.Past(),
                PotentialEndDate = _faker.Date.Soon(),
                UPaymentExpected = _faker.Random.AlphaNumeric(3)
            };

            UhCustomerInformation dbCustomer1 =
                UhCustomerInformationHelper.CreateUhCustomerInformation(); //customer1
            dbCustomer1.HouseRef = houseRef;

            UhCustomerInformation dbCustomer2 =
                UhCustomerInformationHelper.CreateUhCustomerInformation(); //customer2
            dbCustomer2.HouseRef = houseRef;


            _uhContext.UhCustomerInformations.Add(dbCustomer1);
            _uhContext.UhCustomerInformations.Add(dbCustomer2);
            _uhContext.UhAgreements.Add(dbAgreement);
            _uhContext.SaveChanges();

            //act
            var response = _classUnderTest.GetCustomerInformationByTagReference(tagRef);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IList<CustomerInformation>>(response); //check if it's a collection

            Assert.AreEqual(2, response.Count);

            Assert.AreEqual(tagRef, response[0].tenancyRef);
            Assert.AreEqual(tagRef, response[1].tenancyRef);

            Assert.AreEqual(houseRef, response[0].houseRef);
            Assert.AreEqual(houseRef, response[1].houseRef);
        }
    }
}
