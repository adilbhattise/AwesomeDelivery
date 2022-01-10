using AwesomeDelivery.Entities.DTOs;
using AwesomeDelivery.Entities.Enums;
using AwesomeDelivery.Entities.Models;
using AwesomeDelivery.Entities.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Controllers
{
    [Route("api/Awesome")]
    [ApiController]
    public class AwesomeAPIController : Controller
    {
        string GlobalValidation = "";
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Everything is Fine");
        }
        [HttpPost]
        [Route("GetDeliveryDates")]
        public IActionResult DeliveryDates([FromBody] ProductRequest request)
        {
            try
            {
                List<DeliveryDaysResponse> responseList = new List<DeliveryDaysResponse>();
                string postalCode = request.PostalCode;
                foreach (Product pr in request.Products)
                {
                    if (Validate(pr))
                    {
                        foreach (DayOfWeek dw in pr.DeliveryDays)
                        {
                            DateTime dateByDayName = dw.GetNextWeekDayDate(pr.DaysInAdvance);
                            if (!responseList.Any(x => x.DeliveryDate == dateByDayName))
                            {
                                DeliveryDaysResponse ddr = new DeliveryDaysResponse();
                                ddr.PostalCode = postalCode;
                                ddr.DeliveryDate = dateByDayName;
                                responseList.Add(ddr);
                            }
                        }
                    }
                    else
                    {
                        return Json(GlobalValidation);
                    }
                }

                return Ok(responseList.OrderBy(x => x.DeliveryDate));
            }
            catch(Exception ex)
            {
                return Json("Something Went Wrong!");
            }
        }

        public bool Validate(Product pr)
        {
            bool result = true;
            switch (pr.ProductType)
            {
                case ProductType.External:
                    if (pr.DaysInAdvance < 5)
                    {
                        GlobalValidation = Errors.External;
                        result = false;
                    }
                    break;
                case ProductType.Normal:
                    break;
                case ProductType.Temporary:
                    int currentDay = (int)DateTime.Today.DayOfWeek;
                    foreach (DayOfWeek dw in pr.DeliveryDays)
                    {
                        int deliveryDay = (int)dw;
                        if (deliveryDay > currentDay)
                        {
                         if(!(pr.DaysInAdvance <= (deliveryDay - currentDay)))
                            {
                                result = false;
                                GlobalValidation = Errors.Temporary;
                                break;
                            }
                        }
                        else
                        {
                            result = false;
                            GlobalValidation = Errors.Temporary;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }

   
}
