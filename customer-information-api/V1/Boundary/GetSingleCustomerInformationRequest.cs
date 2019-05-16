using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace customer_information_api.V1.Boundary
{
    public class GetSingleCustomerInformationRequest
    {
        public string customer_id { get; set; }
    }
}
