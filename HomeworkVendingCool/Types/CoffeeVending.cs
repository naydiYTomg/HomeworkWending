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
        }

        public void Buy(int index, bool isNeedSugar)
        {
            if (index >= CoffeeReceipts.Count) { 
                Console.WriteLine("Такого кофе не существует!"); 
                return;
            }
            CoffeeReceipt current = CoffeeReceipts[index];
            if (current.WaterConsumption > WaterAmount || current.MilkConsumption > MilkAmount || current.CoffeeConsumption > CoffeeAmount) { 
                Console.WriteLine($"В автомате не хватает ингредиентов чтобы сделать {current.Name}");
                return; 
            }
            if (isNeedSugar)
            {
                if (current.SugarConsumption > SugarAmount)
                {
                    Console.WriteLine($"Не хватает сахара чтобы сделать {current.Name}");
                    throw new Exception("");
                }
                SugarAmount -= current.SugarConsumption;
            }
            if (current.Price > _userInsertedAmount)
            {
                Console.WriteLine($"Вы внесли недостаточно денег! Вам не хватает {current.Price - _userInsertedAmount} рублей!");
                return;
            }
            _userInsertedAmount -= current.Price;
            TotalSales += current.Price;
            WaterAmount -= current.WaterConsumption;
            MilkAmount -= current.MilkConsumption;
            CoffeeAmount -= current.CoffeeConsumption;
            Console.WriteLine($"Вот ваш {current.Name}");
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
    }
}
