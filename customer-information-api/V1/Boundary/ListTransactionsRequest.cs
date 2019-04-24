

using System.ComponentModel.DataAnnotations;

namespace customer_information_api.V1.Boundary
{
    public class ListTransactionsRequest
    {
        [Required] public string PropertyRef { get; set; }
    }
}
