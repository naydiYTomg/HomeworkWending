using HomeworkWending.Types.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

const double neededAmountOfWaterForAmericano = 0.09;
const double neededAmountOfWaterForCappucin = 0.08;
const double neededAmountOfWaterForLatte = 0.05;
const double neededAmountOfCoffeeForAmericano = 0.02;
const double neededAmountOfCoffeeForCappucin = 0.03;
const double neededAmountOfCoffeeForLatte = 0.03;
const double neededAmountOfMilkForCappucin = 0.2;
const double neededAmountOfMilkForLatte = 0.18;
const double neededAmountOfSugarForAmericano = 0.05;
const double neededAmountOfSugarForCappucin = 0.09;
const double neededAmountOfSugarForLatte = 0.06;




namespace HomeworkWending.Types.Interfaces
{
    class CoffeeVending : ICoffeeVending
    {
        public double RemainingWater { get; private set; } = 100;

        public double RemainingCoffee { get; private set; } = 50;

        public double RemainingMilk { get; private set; } = 50;

        public double RemainingSugar { get; private set; } = 30;

        public int RemainingCash { get; private set; } = 300;

        public int TotalSolds { get; private set; } = 0;

        public string Name { get; set; }

        private int _userInsertedAmountOfMoney = 0;
        private int _currentPurchaseAmount = 0;

        public CoffeeVending(string name)
        {
            Name = name;
        }

        public void BuyAmericano(bool isNeedSugar)
        {
            ErrorsCheck();
            
        }

        public void BuyCappucin(bool isNeedSugar)
        {
            throw new NotImplementedException();
        }

        public void BuyLatte(bool isNeedSugar)
        {
            throw new NotImplementedException();
        }

        public int DropChange(int amount)
        {
            throw new NotImplementedException();
        }

        public bool ErrorsCheck(ErrorCheckProvider provider)
        {
            switch (provider)
            {

            }
        }

        public void Repair()
        {
            RemainingCoffee = 50;
            RemainingMilk = 50;
            RemainingSugar = 30;
            RemainingWater = 100;
        }

        public void TakeBanknote(BanknoteType banknote)
        {
            ErrorsCheck();
            switch (banknote)
            {
                case BanknoteType.FiftyRubles:          _userInsertedAmountOfMoney += 50; break;
                case BanknoteType.HundredRubles:        _userInsertedAmountOfMoney += 100; break;
                case BanknoteType.TwoHundredRubles:     _userInsertedAmountOfMoney += 200; break;
                case BanknoteType.FiveHundredRubles:    _userInsertedAmountOfMoney += 500; break;
                case BanknoteType.OneThousandRubles:    _userInsertedAmountOfMoney += 1000; break;
                case BanknoteType.TwoThousandRubles:    _userInsertedAmountOfMoney += 2000; break;
                case BanknoteType.FiveThousandRubles:   _userInsertedAmountOfMoney += 5000; break;
            }
        }

        public void TakeCoin(CoinType coin)
        {
            ErrorsCheck();
            switch (coin)
            {
                case CoinType.OneRuble:     _userInsertedAmountOfMoney += 1; break;
                case CoinType.TwoRubles:    _userInsertedAmountOfMoney += 2; break;
                case CoinType.FiveRubles:   _userInsertedAmountOfMoney += 5; break;
                case CoinType.TenRubles:    _userInsertedAmountOfMoney += 10; break;
            }
        }
    }
}
