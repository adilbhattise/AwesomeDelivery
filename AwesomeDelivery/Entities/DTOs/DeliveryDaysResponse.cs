using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Entities.DTOs
{
    public class DeliveryDaysResponse
    {
        public string PostalCode { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
