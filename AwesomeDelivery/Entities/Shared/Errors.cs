using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDelivery.Entities.Shared
{
    public static class Errors
    {
        public static string External = "All external products need to be ordered 5 days in advance";
        public static string Temporary = "Temporary products can only be ordered within the current week (Mon-Sun)";
    }
}
