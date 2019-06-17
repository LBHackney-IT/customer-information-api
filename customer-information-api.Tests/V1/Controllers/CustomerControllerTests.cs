using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using customer_information_api.Tests.V1.Helper;
using customer_information_api.V1.Boundary;
using customer_information_api.V1.Controllers;
using customer_information_api.V1.Domain;
using customer_information_api.V1.UseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace customer_information_api.Tests.V1.Controllers
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _classUnderTest;
        private Mock<IGetCustomersUseCase> _mockUseCase;
        private Mock<ILogger<CustomerController>> _mockLogger;
        private Faker faker;
        [SetUp]
        public void SetUp()
        {
            _mockUseCase = new Mock<IGetCustomersUseCase>();
            _mockLogger = new Mock<ILogger<CustomerController>>();
            _classUnderTest = new CustomerController(_mockUseCase.Object, _mockLogger.Object);
            faker = new Faker();
        }

        [Test]
        public void ControllerShouldReturnCorrectResultAndStatus()
        {
            var customerRecord = CustomerHelper.CreateCustomer();
            var request = new GetCustomersUseCaseRequest(){tagReference = faker.Random.Hash(10)};
            var expectedResult =
                new GetCustomersUseCaseResponse(request,
                    new List<Customer>() {customerRecord});

            _mockUseCase.Setup(x => x.Execute(request)).Returns(expectedResult);

            var result = _classUnderTest.GetCustomersByTagReference(request);

            Assert.NotNull(result);
            Assert.AreEqual(200, ((ObjectResult)result).StatusCode);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedResult),
                JsonConvert.SerializeObject(((ObjectResult)result).Value));

        }
    }
}
