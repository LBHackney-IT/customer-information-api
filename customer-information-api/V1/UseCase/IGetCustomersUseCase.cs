using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using customer_information_api.V1.Boundary;

namespace customer_information_api.V1.UseCase
{
    public interface IGetCustomersUseCase
    {
        GetCustomersUseCaseResponse Execute(GetCustomersUseCaseRequest request);
    }
}
