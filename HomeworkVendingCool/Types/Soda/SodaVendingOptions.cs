using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types.Soda
{
    static class SodaVendingOptions
    {
        public static int MaxAmountOfSodaCans = 36;

        public static List<SodaReceipt> GetDefaultReceipts() { return new List<SodaReceipt>() 
        {
            new SodaReceipt("Добрый cola", 119, 12),
            new SodaReceipt("Fresh Bar", 99, 12),
            new SodaReceipt("Буратино", 129, 12)
        }; 
        }
    }
}
