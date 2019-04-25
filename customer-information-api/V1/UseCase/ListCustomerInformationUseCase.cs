using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Boundary;
using customer_information_api.V1.Domain;
using customer_information_api.V1.Gateways;

namespace customer_information_api.V1.UseCase
{
    public class ListCustomerInformationUseCase : IListCustomerInformationUseCase
    {
        public ICustomerInformationGateway _customerInformationGateway;
        public ListCustomerInformationUseCase(ICustomerInformationGateway gateway)
        {
            _customerInformationGateway = gateway;
        }
        public ListCustomerInformationResponse Execute(ListCustomerInformationRequest request)
        {
            var results = _customerInformationGateway.GetCustomerInformationByTagReference(request.tagReference);
            return new ListCustomerInformationResponse(request,results);
        }
    }
}
