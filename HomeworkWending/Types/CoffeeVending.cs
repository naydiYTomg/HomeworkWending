using HomeworkWending.Types.Enums;
using HomeworkWending.Types.Interfaces;






namespace HomeworkWending.Types
{

    class CoffeeVending : ICoffeeVending
    {

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


        const int americanoPrice = 199;
        const int cappucinPrice = 149;
        const int lattePrice = 219;

        public double RemainingWater { get; private set; }  // = 100;

        public double RemainingCoffee { get; private set; } // = 50;

        public double RemainingMilk { get; private set; }   // = 50;

        public double RemainingSugar { get; private set; }  // = 30;

        public int RemainingCash { get; private set; }      // = 300;

        public int TotalSolds { get; private set; } = 0;

        public string Name { get; set; }

        private int _userInsertedAmountOfMoney = 0;
        //private int _currentPurchaseAmount = 0;

        public CoffeeVending(string name, int water, int coffee, int milk, int sugar, int cash)
        {
            Name = name;
            RemainingWater = water;
            RemainingCoffee = coffee;
            RemainingMilk = milk;
            RemainingSugar = sugar;
            RemainingCash = cash;
        }

        public void BuyAmericano(bool isNeedSugar)
        {
            if (ErrorsCheck(ErrorCheckProvider.Americano))
            {
                if (isNeedSugar)
                {
                    MakeAmericanoWithSugar();
                    DropChange(_userInsertedAmountOfMoney - americanoPrice);
                }
                else
                {
                    MakeAmericano();
                    DropChange(_userInsertedAmountOfMoney - americanoPrice);
                }
            }

        }

        private void MakeAmericanoWithSugar()
        {
            RemainingWater -= neededAmountOfWaterForAmericano;
            RemainingCoffee -= neededAmountOfCoffeeForAmericano;
            RemainingSugar -= neededAmountOfSugarForAmericano;
            Console.WriteLine("\nHere's your americano with sugar!\n");
        }
        private void MakeAmericano()
        {
            RemainingWater -= neededAmountOfWaterForAmericano;
            RemainingCoffee -= neededAmountOfCoffeeForAmericano;
            Console.WriteLine("\nHere's your americano!\n");
        }


        public void BuyCappucin(bool isNeedSugar)
        {
            if (ErrorsCheck(ErrorCheckProvider.Cappucin))
            {
                if (isNeedSugar)
                {
                    MakeCappucinWithSugar();
                    DropChange(_userInsertedAmountOfMoney - cappucinPrice);
                }
                else
                {
                    MakeCappucin();
                    DropChange(_userInsertedAmountOfMoney - cappucinPrice);
                }
            }
        }
        private void MakeCappucinWithSugar()
        {
            RemainingWater -= neededAmountOfWaterForCappucin;
            RemainingCoffee -= neededAmountOfCoffeeForCappucin;
            RemainingSugar -= neededAmountOfSugarForCappucin;
            Console.WriteLine("\nHere's your cappucin with sugar!\n");
        }
        private void MakeCappucin()
        {
            RemainingWater -= neededAmountOfWaterForCappucin;
            RemainingCoffee -= neededAmountOfCoffeeForCappucin;
            Console.WriteLine("\nHere's your cappucin!\n");
        }

        public void BuyLatte(bool isNeedSugar)
        {
            if (ErrorsCheck(ErrorCheckProvider.Latte))
            {
                if (isNeedSugar)
                {
                    MakeLatteWithSugar();
                    DropChange(_userInsertedAmountOfMoney - lattePrice);
                }
                else
                {
                    MakeLatte();
                    DropChange(_userInsertedAmountOfMoney - lattePrice);
                }
            }
        }
        private void MakeLatteWithSugar()
        {
            RemainingWater -= neededAmountOfWaterForLatte;
            RemainingCoffee -= neededAmountOfCoffeeForLatte;
            RemainingSugar -= neededAmountOfSugarForLatte;
            Console.WriteLine("\nHere's your latte with sugar!\n");
        }
        private void MakeLatte()
        {
            RemainingWater -= neededAmountOfWaterForLatte;
            RemainingCoffee -= neededAmountOfCoffeeForLatte;
            Console.WriteLine("\nHere's your latte\n");
        }

        public void DropChange(int amount)
        {
            _userInsertedAmountOfMoney -= amount;
            RemainingCash += _userInsertedAmountOfMoney;
            TotalSolds += _userInsertedAmountOfMoney;
            _userInsertedAmountOfMoney = 0;
        }
        public double[] GetRepairData() { return new double[] { RemainingWater, RemainingCoffee, RemainingMilk, RemainingSugar }; }

        public bool ErrorsCheck(ErrorCheckProvider provider)
        {
            switch (provider)
            {
                case ErrorCheckProvider.Americano:
                    if (RemainingWater < neededAmountOfWaterForAmericano)
                    {
                        Console.WriteLine("Error! Not enough water for this action! Please call masters");
                        return false;
                    }
                    if (RemainingCoffee < neededAmountOfCoffeeForAmericano)
                    {
                        Console.WriteLine("Error! Not enough coffee for this action! Please call masters");
                        return false;
                    }
                    if (_userInsertedAmountOfMoney < americanoPrice)
                    {
                        Console.WriteLine($"Error! You didn't insert enough money! Please insert another {americanoPrice - _userInsertedAmountOfMoney}$");
                        return false;
                    }
                    return true;
                case ErrorCheckProvider.Cappucin:
                    if (RemainingWater < neededAmountOfWaterForCappucin)
                    {
                        Console.WriteLine("Error! Not enough water for this action! Please call masters");
                        return false;
                    }
                    if (RemainingCoffee < neededAmountOfCoffeeForCappucin)
                    {
                        Console.WriteLine("Error! Not enough coffee for this action! Please call masters");
                        return false;
                    }
                    if (RemainingMilk < neededAmountOfMilkForCappucin)
                    {
                        Console.WriteLine("Error! Not enough milk for this action! Please call masters");
                        return false;
                    }
                    if (_userInsertedAmountOfMoney < cappucinPrice)
                    {
                        Console.WriteLine($"Error! You didn't insert enough money! Please insert another {cappucinPrice - _userInsertedAmountOfMoney}$");
                        return false;
                    }
                    return true;
                case ErrorCheckProvider.Latte:
                    if (RemainingWater < neededAmountOfWaterForLatte)
                    {
                        Console.WriteLine("Error! Not enough water for this action! Please call masters");
                        return false;
                    }
                    if (RemainingCoffee < neededAmountOfCoffeeForLatte)
                    {
                        Console.WriteLine("Error! Not enough coffee for this action! Please call masters");
                        return false;
                    }
                    if (RemainingMilk < neededAmountOfMilkForLatte)
                    {
                        Console.WriteLine("Error! Not enough milk for this action! Please call masters");
                        return false;
                    }
                    if (_userInsertedAmountOfMoney < lattePrice)
                    {
                        Console.WriteLine($"Error! You didn't insert enough money! Please insert another {lattePrice - _userInsertedAmountOfMoney}$");
                        return false;
                    }
                    return true;
                default: return true;

            }
        }

        public void Repair(int coffee, int milk, int sugar, int water)
        {
            RemainingCoffee = coffee;
            RemainingMilk = milk;
            RemainingSugar = sugar;
            RemainingWater = water;
        }

        public void TakeBanknote(BanknoteType banknote)
        {
            if (ErrorsCheck(ErrorCheckProvider.Banknote))
            {
                switch (banknote)
                {
                    case BanknoteType.FiftyRubles: _userInsertedAmountOfMoney += 50; break;
                    case BanknoteType.HundredRubles: _userInsertedAmountOfMoney += 100; break;
                    case BanknoteType.TwoHundredRubles: _userInsertedAmountOfMoney += 200; break;
                    case BanknoteType.FiveHundredRubles: _userInsertedAmountOfMoney += 500; break;
                    case BanknoteType.OneThousandRubles: _userInsertedAmountOfMoney += 1000; break;
                    case BanknoteType.TwoThousandRubles: _userInsertedAmountOfMoney += 2000; break;
                    case BanknoteType.FiveThousandRubles: _userInsertedAmountOfMoney += 5000; break;
                }
            }

        }

        public void TakeCoin(CoinType coin)
        {
            if (ErrorsCheck(ErrorCheckProvider.Coin))
            {
                switch (coin)
                {
                    case CoinType.OneRuble: _userInsertedAmountOfMoney += 1; break;
                    case CoinType.TwoRubles: _userInsertedAmountOfMoney += 2; break;
                    case CoinType.FiveRubles: _userInsertedAmountOfMoney += 5; break;
                    case CoinType.TenRubles: _userInsertedAmountOfMoney += 10; break;
                }
            }

        }
        public int ShowBalance() { return _userInsertedAmountOfMoney; }
    }
}
