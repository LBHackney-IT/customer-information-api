using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Boundary;
using customer_information_api.V1.Domain;
using customer_information_api.V1.Gateways;

namespace customer_information_api.V1.UseCase
{
    public class GetCustomersUseCase : IGetCustomersUseCase
    {
        public ICustomerGateway _customerGateway;
        public GetCustomersUseCase(ICustomerGateway gateway)
        {
            _customerGateway = gateway;
        }
        public GetCustomersUseCaseResponse Execute(GetCustomersUseCaseRequest request)
        {
            var results = _customerGateway.GetCustomersByTagReference(request.tagReference);
            return new GetCustomersUseCaseResponse(request,results);
        }
    }
}
