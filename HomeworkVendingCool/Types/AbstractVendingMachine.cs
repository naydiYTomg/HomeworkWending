using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types
{
    abstract class AbstractVendingMachine<T> where T : IReceipt
    {
        protected virtual List<T> _receipts { get; }

        public virtual int TotalSales { get; protected set; }

        protected AbstractVendingMachine(List<T> receipts)
        {
            _receipts = receipts;
        }
        
        public virtual void PrintReceipts()
        {
            foreach(var receipt in _receipts)
            {
                Console.WriteLine(receipt.ToString());
            }
        }
        public abstract void Buy(int index, params object[] args);
        public abstract void TakeBanknote(BanknoteType banknote);
        public abstract void Refill();
        public virtual int GetTotalSales() { return TotalSales; }
    }
}
