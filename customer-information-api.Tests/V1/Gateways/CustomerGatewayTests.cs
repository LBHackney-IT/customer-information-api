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
    public class CustomerGatewayTests : DbTest
    {
        private readonly Faker _faker = new Faker();
        private CustomerGateway _classUnderTest;
        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new CustomerGateway(_uhContext);
        }

        [Test]
        public void ListOfCustomersImplementBoundaryInterface()
        {
            Assert.NotNull(_classUnderTest is ICustomerGateway);
        }

        [TestCase("010135/01", "010135")]
        [TestCase("020815/01", "020815")]
        public void GivenAnUnmatchingTagRef_WhenAGatewayIsCalled_ThenItReturnsAnEmptyCollectionOfCustomers(string tagRef, string houseRef)
        {
            //arrange
            #region Unmatching data
            //Without this data, this test has only checked if the Gateway returns nothing, when there is nothing to return
            //rather than checking whether the Gateway genuinely ignores the unmatching TagRefs in DB and returns nothing because of it.

            UhAgreement dbAgreement = UhAgreementHelper.CreateUhAgreement();
            dbAgreement.HouseRef = houseRef;
            dbAgreement.TagRef = tagRef;

            UhCustomer dbCustomer =
                UhCustomerHelper.CreateUhCustomer(); //customer1
            dbCustomer.HouseRef = houseRef;

            _uhContext.UhCustomers.Add(dbCustomer);
            _uhContext.UhAgreements.Add(dbAgreement);
            #endregion

            _uhContext.SaveChanges();

            //act
            var response = _classUnderTest.GetCustomersByTagReference("Test");

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IList<Customer>>(response); //check if it's a collection

            Assert.Zero(response.Count);
            Assert.Null(response.FirstOrDefault());
        }

        [TestCase("000345/01", "000345", "001212")]
        [TestCase("000628/03", "000628", "002323")]
        public void GivenAMatchingTagRefOfARecordThatDoesNotLinkToUhCustomer_WhenAGatewayIsCalled_ThenItReturnsAnEmptyCollectionOfCustomers(string tagRef, string houseRef, string houseRef2)
        {
            //arrange
            #region Matching data
            UhAgreement dbAgreement = UhAgreementHelper.CreateUhAgreement(); //matching agreement
            dbAgreement.HouseRef = houseRef;
            dbAgreement.TagRef = tagRef;

            UhCustomer dbCustomerUnmatching =
                UhCustomerHelper.CreateUhCustomer(); //unmatching customer
            dbCustomerUnmatching.HouseRef = houseRef2;

            _uhContext.UhCustomers.Add(dbCustomerUnmatching);
            _uhContext.UhAgreements.Add(dbAgreement);
            #endregion

            _uhContext.SaveChanges();
            //act
            var response = _classUnderTest.GetCustomersByTagReference(tagRef);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IList<Customer>>(response);

            Assert.Zero(response.Count);
            Assert.Null(response.FirstOrDefault());
        }

        [TestCase("000125/01", "000125", "000305")]
        [TestCase("000778/03", "000778", "000420")]
        public void GivenAMatchingTagRef_WhenAGatewayIsCalled_ThenItReturnsACollectionOfMathcingCustomers(string tagRef, string houseRef, string unmatchHouseRef)
        {
            //arrange
            #region Matching data
            UhAgreement dbAgreement = UhAgreementHelper.CreateUhAgreement();
            dbAgreement.HouseRef = houseRef;
            dbAgreement.TagRef = tagRef;

            UhCustomer dbCustomer1 =
                UhCustomerHelper.CreateUhCustomer(); //customer1
            dbCustomer1.HouseRef = houseRef;

            UhCustomer dbCustomer2 =
                UhCustomerHelper.CreateUhCustomer(); //customer2
            dbCustomer2.HouseRef = houseRef;


            _uhContext.UhCustomers.Add(dbCustomer1);
            _uhContext.UhCustomers.Add(dbCustomer2);
            _uhContext.UhAgreements.Add(dbAgreement);
            #endregion

            #region Unmatching data
            //Without it there is no way to tell if your Gateway is returning just what you need,
            //or is it simply returning everything it sees in the database.
            string houseRef2 = unmatchHouseRef;
            string tagRef2 = houseRef2 + "/01";

            UhAgreement dbAgreement2 = UhAgreementHelper.CreateUhAgreement(); //agreement 2
            dbAgreement2.HouseRef = houseRef2;
            dbAgreement2.TagRef = tagRef2;

            //A customer without a matching tag ref to ensure that we don't return customers we didn't ask for.
            UhCustomer dbCustomer3 =
                UhCustomerHelper.CreateUhCustomer(); //customer3
            dbCustomer3.HouseRef = houseRef2;

            _uhContext.UhCustomers.Add(dbCustomer3);
            _uhContext.UhAgreements.Add(dbAgreement2);

            //While our current test configuration has the accumulation of these data entity objects (db rollback only after db tests),
            //it is best not to have any dependencies on which test runs first, as they are supposed to be isolated. Even though they are run alphabetically.
            #endregion

            _uhContext.SaveChanges();

            //act
            var response = _classUnderTest.GetCustomersByTagReference(tagRef);

            //assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IList<Customer>>(response); //check if it's a collection

            Assert.AreEqual(2, response.Count);

            Assert.AreEqual(tagRef, response[0].tenancyRef);
            Assert.AreEqual(tagRef, response[1].tenancyRef);

            Assert.AreEqual(houseRef, response[0].houseRef);
            Assert.AreEqual(houseRef, response[1].houseRef);
        }
    }
}
