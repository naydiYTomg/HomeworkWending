using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types
{
    static class CoffeeVendingOptions
    {
        const double MaxAmountOfWater = 5;
        const double MaxAmountOfMilk = 4;
        const double MaxAmountOfCoffee = 4;
        const double MaxAmountOfSugar = 1;
        public const double MaxCupCapacity = .2;

        static List<CoffeeReceipt> GetDefaultReceipts()
        {
            return new List<CoffeeReceipt>
            {
                new CoffeeReceipt(
                    "Americano",
                    199,
                    .14,
                    0,
                    .06,
                    .0025
                    ),
                new CoffeeReceipt(
                    "Cappucino",
                    239,
                    .045,
                    .1,
                    .055,
                    .0025
                    ),
                new CoffeeReceipt(
                    "Latte",
                    289,
                    .02,
                    .125,
                    .055,
                    .0025
                    )
            };
        }
    }
}
