using HomeworkVendingCool.Types.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types
{
    class CoffeeVending
    {
        public double WaterAmount { get; private set; }
        public double MilkAmount { get; private set; }
        public double CoffeeAmount { get; private set; }
        public double SugarAmount { get; private set; }
        public int TotalSales { get; private set; } = 0;
        private List<CoffeeReceipt> CoffeeReceipts { get; set; }

        private int _userInsertedAmount = 0;

        public CoffeeVending(List<CoffeeReceipt> coffeeReceipts)
        {
            CoffeeReceipts = coffeeReceipts;
            Refill();
        }
        public void PrintReceipts()
        {
            int i = 1;
            foreach (CoffeeReceipt receipt in CoffeeReceipts)
            {
                Console.WriteLine($"[{i}]:: {receipt}");
            }
        }

        public void Buy(int index, bool isNeedSugar)
        {
            index--;
            if (index >= CoffeeReceipts.Count) { 
                throw new ReceiptDoesNotExistsException($"Рецепта с индексом {index} не существует!");
            }
            CoffeeReceipt current = CoffeeReceipts[index];

            if (current.WaterConsumption > WaterAmount) { 
                throw new NotEnoughWaterException(current.WaterConsumption - WaterAmount, current.Name);
            }
            if (current.MilkConsumption > MilkAmount)
            {
                throw new NotEnoughMilkException(current.MilkConsumption - MilkAmount, current.Name);
            }
            if (current.CoffeeConsumption > CoffeeAmount)
            {
                throw new NotEnoughCoffeeException(current.CoffeeConsumption - CoffeeAmount, current.Name);
            }


            if (isNeedSugar)
            {
                if (current.SugarConsumption > SugarAmount)
                {
                    throw new NotEnoughSugarException(current.SugarConsumption - SugarAmount, current.Name);
                }
                SugarAmount -= current.SugarConsumption;
            }
            if (current.Price > _userInsertedAmount)
            {
                throw new NotEnoughMoneyException(current.Price - _userInsertedAmount, current.Name);
            }
            _userInsertedAmount -= current.Price;
            TotalSales += current.Price;
            WaterAmount -= current.WaterConsumption;
            MilkAmount -= current.MilkConsumption;
            CoffeeAmount -= current.CoffeeConsumption;
            Console.WriteLine($"Вот ваш {current.Name}");
            CalculateChange();
        }

        public void CalculateChange()
        {
            Console.WriteLine($"Вот ваша сдача: {_userInsertedAmount}");
            _userInsertedAmount = 0;
            
        }

        public void ConsumeBanknote(BanknoteType banknote)
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
        public void Refill()
        {
            WaterAmount = CoffeeVendingOptions.MaxAmountOfWater;
            SugarAmount = CoffeeVendingOptions.MaxAmountOfSugar;
            MilkAmount = CoffeeVendingOptions.MaxAmountOfMilk;
            CoffeeAmount = CoffeeVendingOptions.MaxAmountOfCoffee;
        }
        public int GetBalance()
        {
            return _userInsertedAmount;
        }
    }
}
