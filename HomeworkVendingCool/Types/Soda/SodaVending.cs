using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeworkVendingCool.Types.Coffee;
using HomeworkVendingCool.Types.Errors;

namespace HomeworkVendingCool.Types.Soda
{
    class SodaVending : AbstractVendingMachine<SodaReceipt>
    {
        protected override List<SodaReceipt> _receipts { get; }
        public override int TotalSales { get; protected set; } = 0;

        private int _userInsertedAmount = 0;

        public SodaVending(List<SodaReceipt> sodaReceipts) : base(sodaReceipts)
        {
            int tempCountOfCans = 0;
            foreach(SodaReceipt receipt in sodaReceipts)
            {
                tempCountOfCans += receipt.RemainsOfThisReceipt;
            }
            if (tempCountOfCans > SodaVendingOptions.MaxAmountOfSodaCans) throw new Exception("В автомат столько не помещается!");
            _receipts = sodaReceipts;
            Refill();
        }

        public override void Buy(int index, params object[]? args)
        {
            if (index > _receipts.Count) throw new ReceiptDoesNotExistsException($"Рецепта под номером {index} не существует!");

            SodaReceipt current = _receipts[index];
            if (current.Price > _userInsertedAmount) throw new NotEnoughMoneyException(current.Price - _userInsertedAmount, current.Name);
            _userInsertedAmount -= current.Price;
            Console.WriteLine($"Вот ваш {current.Name}");
            CalculateChange();
        }

        public void CalculateChange()
        {
            Console.WriteLine($"Вот ваша сдача: {_userInsertedAmount}");
            _userInsertedAmount = 0;

        }



   
        public override void PrintReceipts()
        {
            int i = 1;
            foreach (SodaReceipt receipt in _receipts)
            {
                Console.WriteLine($"[{i}]:: {receipt}");
            }
        }
        public override void Refill()
        {
            foreach(SodaReceipt receipt in _receipts)
            {
                receipt.Refill();
            }
        }
        public override int GetBalance()
        {
            return _userInsertedAmount;
        }
        public override void TakeBanknote(BanknoteType banknote)
        {
            switch (banknote)
            {
                case BanknoteType.FiftyRubles:
                    _userInsertedAmount += 50; break;
                case BanknoteType.HundredRubles:
                    _userInsertedAmount += 100; break;
                case BanknoteType.TwoHundredRubles:
                    _userInsertedAmount += 200; break;
                case BanknoteType.FiveHundredRubles:
                    _userInsertedAmount += 500; break;
                case BanknoteType.ThousandRubles:
                    _userInsertedAmount += 1000; break;
                case BanknoteType.TwoThousandRubles:
                    _userInsertedAmount += 2000; break;
                case BanknoteType.FiveThousandRubles:
                    _userInsertedAmount += 5000; break;
            }
        }
        public override string ToString()
        {
            return "Автомат для газировки";
        }
        public override bool IsNeedRepair()
        {
            bool returnValue = false;
            foreach(SodaReceipt receipt in _receipts)
            {
                if (receipt.RemainsOfThisReceipt != SodaVendingOptions.MaxAmountOfSodaCans) returnValue = true;
            }
            return returnValue;
        }
    }
}
