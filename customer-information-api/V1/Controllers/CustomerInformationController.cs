using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.Controllers.V1;
using customer_information_api.V1.Boundary;
using customer_information_api.V1.UseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace customer_information_api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/v1/property")]
    [ApiController]
    [Produces("application/json")]
    public class CustomerInformationController : BaseController
    {
        private IListCustomerInformationUseCase _useCase;
        private ILogger<CustomerInformationController> _logger;

        public CustomerInformationController(IListCustomerInformationUseCase useCase, ILogger<CustomerInformationController> logger)
        {
            _useCase = useCase;
            _logger = logger;
        }
        // GET customer information for a given reference
        /// <summary>
        /// Returns a list of customer information records for a reference
        /// </summary>
        /// <param name="tagReference">The tenancy reference</param>
        /// <returns>Returns a list of customer information records for a reference</returns>
        [HttpGet]
        [Route("{tagReference}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ListCustomerInformationResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public IActionResult GetCustomerInformationByTagReference(ListCustomerInformationRequest request)
        {
            _logger.LogInformation("Customer information was requested for " + request.tagReference);
            var result = _useCase.Execute(request);

            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

    }
}
