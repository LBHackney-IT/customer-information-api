using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Gateways;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace customer_information_api.Tests.V1.Gateways
{
    [TestFixture()]
    public class CustomerInformationGatewayTests
    {
        private CustomerInformationGateway _classUnderTest;
        [SetUp]
        public void SetUp()
        {
            _classUnderTest = new CustomerInformationGateway();
        }

        [Test]
        public void CallingTheGatewayShouldReturnNullIfNoMatches()
        {

        }
    }
}
