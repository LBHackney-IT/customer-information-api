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
    public class CustomerInformationUseCaseTests
    {
        private Mock<ICustomerInformationGateway> gateway;
        private ListCustomerInformationUseCase useCase;
        private ListCustomerInformationRequest request;
        private Faker faker;
        [SetUp]
        public void SetUp()
        {
            gateway = new Mock<ICustomerInformationGateway>();
            useCase = new ListCustomerInformationUseCase(gateway.Object);
            faker = new Faker();
            request = new ListCustomerInformationRequest()
            {
                tagReference = faker.Random.Hash()
            };

        }
        [Test]
        public void customer_information_use_case_should_return_customer_information_response()
        {
            //Arrange
            var expectedResult = new List<CustomerInformation>(){new CustomerInformation()};
            //Act
            gateway.Setup(x => x.GetCustomerInformationByTagReference(request.tagReference))
                .Returns(expectedResult);
            var actualResult = useCase.Execute(request);
            //Assert
            Assert.IsNotNull(actualResult);
            Assert.IsInstanceOf<ListCustomerInformationResponse>(actualResult);
            Assert.IsInstanceOf<ListCustomerInformationRequest>(actualResult.request);
            Assert.IsInstanceOf<CustomerInformation>(actualResult.result.First());

        }

        [Test]
        public void VerifyThatUseCaseCallsTheGateway()
        {
            useCase.Execute(request);
            gateway.Verify(x => x.GetCustomerInformationByTagReference(request.tagReference));
        }

        [TestCase("abc", "cdef")]
        [TestCase("FirstName", "LastName")]
        public void ExecuteReturnsACorrectListOfCustomerInformation(string firstName, string lastName)
        {
            CustomerInformation customerInformationA = CustomerInformationHelper.CreateCustomerInformation();
            customerInformationA.Forenames = firstName;
            customerInformationA.LastName = lastName;

            CustomerInformation customerInformationB = CustomerInformationHelper.CreateCustomerInformation();

            var expectedGatewayResult = new List<CustomerInformation>() {customerInformationA, customerInformationB};

            gateway.Setup(x => x.GetCustomerInformationByTagReference(request.tagReference)).Returns(expectedGatewayResult);

            var expectedResult = useCase.Execute(request);

            Assert.AreEqual(expectedResult.result,expectedGatewayResult);
            Assert.AreEqual(expectedResult.result.First().Forenames,firstName);
            Assert.AreEqual(expectedResult.result.First().LastName, lastName);
        }

        [Test]
        public void ExecuteReturnsObjectWithNullValueForResultIfGatewayRespondsWithNull()
        {
            gateway.Setup(x => x.GetCustomerInformationByTagReference(request.tagReference)).Returns(()=>null);

            var expectedResult = useCase.Execute(request);

            Assert.IsNull(expectedResult.result);
        }
    }
}
