using HomeworkWending.Types.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkWending.Types.Interfaces
{
    interface IVendingMachine : IMachine
    {
        int RemainingCash { get; }

        int TotalSolds { get; }

        void TakeCoin(CoinType coin);
        void TakeBanknote(BanknoteType banknote);
        void Repair();
        int DropChange(int amount);
    }
}
