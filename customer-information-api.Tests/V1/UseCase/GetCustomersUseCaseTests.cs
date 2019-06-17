using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using customer_information_api.Tests.V1.Domain;
using customer_information_api.Tests.V1.Helper;
using customer_information_api.V1.Boundary;
using customer_information_api.V1.Gateways;
using customer_information_api.V1.Domain;
using customer_information_api.V1.UseCase;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace customer_information_api.Tests.V1.UseCase
{
    [TestFixture]
    public class GetCustomersUseCaseTests
    {
        private Mock<ICustomerGateway> gateway;
        private GetCustomersUseCase useCase;
        private GetCustomersUseCaseRequest request;
        private Faker faker;
        [SetUp]
        public void SetUp()
        {
            gateway = new Mock<ICustomerGateway>();
            useCase = new GetCustomersUseCase(gateway.Object);
            faker = new Faker();
            request = new GetCustomersUseCaseRequest()
            {
                tagReference = faker.Random.Hash()
            };

        }
        [Test]
        public void Customer_use_case_should_return_customer_response()
        {
            //Arrange
            var expectedResult = new List<Customer>(){new Customer()};
            //Act
            gateway.Setup(x => x.GetCustomersByTagReference(request.tagReference))
                .Returns(expectedResult);
            var actualResult = useCase.Execute(request);
            //Assert
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOf<GetCustomersUseCaseResponse>(actualResult);
            Assert.IsInstanceOf<GetCustomersUseCaseRequest>(actualResult.request);
            Assert.IsInstanceOf<Customer>(actualResult.result.First());

        }

        [Test]
        public void VerifyThatUseCaseCallsTheGateway()
        {
            useCase.Execute(request);
            gateway.Verify(x => x.GetCustomersByTagReference(request.tagReference));
        }

        [TestCase("abc", "cdef")]
        [TestCase("FirstName", "LastName")]
        public void ExecuteReturnsACorrectListOfCustomers(string firstName, string lastName)
        {
            Customer customerA = CustomerHelper.CreateCustomer();
            customerA.forenames = firstName;
            customerA.surname = lastName;

            Customer customerB = CustomerHelper.CreateCustomer();

            var expectedGatewayResult = new List<Customer>() {customerA, customerB};

            gateway.Setup(x => x.GetCustomersByTagReference(request.tagReference)).Returns(expectedGatewayResult);

            var expectedResult = useCase.Execute(request);

            Assert.AreEqual(expectedResult.result,expectedGatewayResult);
            Assert.AreEqual(expectedResult.result.First().forenames,firstName);
            Assert.AreEqual(expectedResult.result.First().surname, lastName);
        }

        [Test]
        public void ExecuteReturnsObjectWithNullValueForResultIfGatewayRespondsWithNull()
        {
            gateway.Setup(x => x.GetCustomersByTagReference(request.tagReference)).Returns(()=>null);

            var expectedResult = useCase.Execute(request);

            Assert.IsNull(expectedResult.result);
        }
    }
}
