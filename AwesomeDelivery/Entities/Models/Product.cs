using AwesomeDelivery.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Entities.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public List<DayOfWeek> DeliveryDays { get; set; }
        public ProductType ProductType { get; set; }
        public int DaysInAdvance { get; set; }
    }
}
