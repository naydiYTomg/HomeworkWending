using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types.Soda
{
    class SodaReceipt : IReceipt
    {
        public string? Name { get; private set; }
        public int Price { get; private set; }
        
        public int RemainsOfThisReceipt { get; private set; }
        private int _revertAmountOfReceipt;

        public SodaReceipt(string? name, int price, int remainsOfThisReceipt)
        {
            Name = name;
            Price = price;
            RemainsOfThisReceipt = remainsOfThisReceipt;
            _revertAmountOfReceipt = remainsOfThisReceipt;
        }

        public void Refill()
        {
            RemainsOfThisReceipt = _revertAmountOfReceipt;
        }

        public override string ToString()
        {
            return Name!;
        }
    }
}
