using HomeworkWending.Types.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkWending.Types.Interfaces
{
    interface ICoffeeVending : IVendingMachine
    {
        double RemainingWater {  get; }
        double RemainingCoffee { get; }
        double RemainingMilk { get; }
        double RemainingSugar { get; }

        void BuyAmericano(bool isNeedSugar);
        void BuyCappucin(bool isNeedSugar);
        void BuyLatte(bool isNeedSugar);
        bool ErrorsCheck(ErrorCheckProvider provider);
    }
}
