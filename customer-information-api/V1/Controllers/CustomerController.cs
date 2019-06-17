using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.Controllers.V1;
using customer_information_api.V1.Boundary;
using customer_information_api.V1.Domain;
using customer_information_api.V1.UseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace customer_information_api.V1.Controllers
{
    [ApiVersion("1")]
    [Route("api/v1/customer")]
    [ApiController]
    [Produces("application/json")]
    public class CustomerController : BaseController
    {
        private IGetCustomersUseCase _useCase;
        private ILogger<CustomerController> _logger;

        public CustomerController(IGetCustomersUseCase useCase, ILogger<CustomerController> logger)
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
        [Produces("application/json")]
        [ProducesResponseType(typeof(GetCustomersUseCaseResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        public IActionResult GetCustomersByTagReference([FromQuery] GetCustomersUseCaseRequest request)
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

    internal class CustomerBadRequest
    {
        public string status;
        public List<string> errors;
    }
}
