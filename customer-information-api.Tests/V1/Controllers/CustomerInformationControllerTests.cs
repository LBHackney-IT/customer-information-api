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
    public class CustomerInformationControllerTests
    {
        private CustomerInformationController _classUnderTest;
        private Mock<IListCustomerInformationUseCase> _mockUseCase;
        private Mock<ILogger<CustomerInformationController>> _mockLogger;
        private Faker faker;
        [SetUp]
        public void SetUp()
        {
            _mockUseCase = new Mock<IListCustomerInformationUseCase>();
            _mockLogger = new Mock<ILogger<CustomerInformationController>>();
            _classUnderTest = new CustomerInformationController(_mockUseCase.Object, _mockLogger.Object);
            faker = new Faker();
        }

        [Test]
        public void ControllerShouldReturnCorrectResultAndStatus()
        {
            var customerInformationRecord = CustomerInformationHelper.CreateCustomerInformation();
            var request = new ListCustomerInformationRequest(){tagReference = faker.Random.Hash(10)};
            var expectedResult =
                new ListCustomerInformationResponse(request,
                    new List<CustomerInformation>() {customerInformationRecord});

            _mockUseCase.Setup(x => x.Execute(request)).Returns(expectedResult);

            var result = _classUnderTest.GetCustomerInformationByTagReference(request);

            Assert.NotNull(result);
            Assert.AreEqual(200, ((ObjectResult)result).StatusCode);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedResult),
                JsonConvert.SerializeObject(((ObjectResult)result).Value));

        }
    }
}
