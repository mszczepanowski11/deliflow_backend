
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeliflowRequests
{
    public class DeliveryRequest
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string DateOfDelivery {get;set;}
        public int CourierId {get;set;}

    }
}
