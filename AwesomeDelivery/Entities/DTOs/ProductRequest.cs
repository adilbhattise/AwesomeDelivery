using AwesomeDelivery.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Entities.DTOs
{
    public class ProductRequest
    {
        public string PostalCode { get; set; }
        public List<Product> Products { get; set; }
    }
}
