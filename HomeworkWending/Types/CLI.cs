using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkWending.Types
{
    public class CLI
    {
        private CoffeeVending? current;
        private bool _isWorking = false;
        public void SetEnvironment(string name, int water, int coffee, int milk, int sugar, int cash)
        {
            if (current == null)
            {
                current = new CoffeeVending(name, water, coffee, milk, sugar, cash);
            }
            else throw new Exception("Environment already set!");
        }
        public void Stop()
        {
            _isWorking = false;
        }
        private void HandleMoney()
        {
            Console.WriteLine("Please insert money (50/100/200/500/1000/2000/5000)");
            int[] _desiredInput = [50, 100, 200, 500, 1000, 2000, 5000];
            bool _result = int.TryParse(Console.ReadLine(), out int _gotInput);
            if (!_desiredInput.Contains(_gotInput)) { Console.WriteLine("Machine cannot take this banknote!"); return; }
            switch (_gotInput)
            {
                case 50: current.TakeBanknote(Enums.BanknoteType.FiftyRubles); break;
                case 100: current.TakeBanknote(Enums.BanknoteType.HundredRubles); break;
                case 200: current.TakeBanknote(Enums.BanknoteType.TwoHundredRubles); break;
                case 500: current.TakeBanknote(Enums.BanknoteType.FiveHundredRubles); break;
                case 1000: current.TakeBanknote(Enums.BanknoteType.OneThousandRubles); break;
                case 2000: current.TakeBanknote(Enums.BanknoteType.TwoThousandRubles); break;
                case 5000: current.TakeBanknote(Enums.BanknoteType.FiveThousandRubles); break;
            }
        }
        public void Run()
        {
            if (current == null) throw new Exception("Enviroment is null!"); 
            _isWorking = true;
            Console.WriteLine("Welcome to Coffee vending machine interface!");
            while (_isWorking)
            {
                Console.WriteLine("Press enter");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Choose option: \nb/buy - buy some coffee\nr/repair - repair the machine\ne/exit - exit");
                Console.Write("::|");
                string _userInputResult = Console.ReadLine();
                if (_userInputResult.Equals("b", StringComparison.CurrentCultureIgnoreCase) || _userInputResult.Equals("buy", StringComparison.CurrentCultureIgnoreCase))
                {
                    //HandleMoney();
                    Console.WriteLine("Choose option: \namericano\ncappucin\nlatte\ni/insert - insert money\ns/showbalance - shows your balance");
                    _userInputResult = Console.ReadLine();
                    if (_userInputResult.Equals("i", StringComparison.CurrentCultureIgnoreCase) || _userInputResult.Equals("insert", StringComparison.CurrentCultureIgnoreCase))
                    {
                        HandleMoney();
                    }else if ( _userInputResult.ToLower() == "americano")
                    {
                        Console.WriteLine("Would you like it with sugar or without? (y/yes for yes, all another - no");
                        _userInputResult = Console.ReadLine();
                        if (_userInputResult.Equals("y", StringComparison.CurrentCultureIgnoreCase) || _userInputResult.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                        {
                            current.BuyAmericano(true);
                        }else
                        {
                            current.BuyAmericano(false);
                        }
                    }else if (_userInputResult.Equals("cappucin", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine("Would you like it with sugar or without? (y/yes for yes, all another - no");
                        _userInputResult = Console.ReadLine();
                        if (_userInputResult.Equals("y", StringComparison.CurrentCultureIgnoreCase) || _userInputResult.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                        {
                            current.BuyCappucin(true);
                        }
                        else
                        {
                            current.BuyCappucin(false);
                        }
                    }
                    else if (_userInputResult.Equals("latte", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine("Would you like it with sugar or without? (y/yes for yes, all another - no");
                        _userInputResult = Console.ReadLine();
                        if (_userInputResult.Equals("y", StringComparison.CurrentCultureIgnoreCase) || _userInputResult.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
                        {
                            current.BuyLatte(true);
                        }
                        else
                        {
                            current.BuyLatte(false);
                        }
                    }else if (_userInputResult.Equals("s", StringComparison.CurrentCultureIgnoreCase) || _userInputResult.Equals("showbalance", StringComparison.CurrentCultureIgnoreCase))
                    {
                        Console.WriteLine(current.ShowBalance());
                    }
                    else
                    {
                        Console.WriteLine("Unexpected command");
                        continue;
                    }
                    

                }else if (_userInputResult.Equals("r", StringComparison.CurrentCultureIgnoreCase) || _userInputResult.Equals("repair", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Write 4 integer values separated by commas");
                    _userInputResult = Console.ReadLine();
                    string[] repairValuesString = _userInputResult.Split(",");
                    int[] repairValues = new int[4];
                    int i = 0;
                    foreach (string value in repairValuesString)
                    {
                        bool temp = int.TryParse(value, out repairValues[i]);
                        if (temp)
                        {
                            i++;
                        }else
                        {
                            Console.WriteLine("One of values is not integer!");
                            break;
                        }
                    }
                    current.Repair(repairValues[0], repairValues[1], repairValues[2], repairValues[3]);
                }else if (_userInputResult.Equals("e", StringComparison.CurrentCultureIgnoreCase) || _userInputResult.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                {
                    Stop();
                }else if (_userInputResult.Equals("grv", StringComparison.CurrentCultureIgnoreCase) || _userInputResult.Equals("getrepairvalues", StringComparison.CurrentCultureIgnoreCase))
                {
                    foreach (var item in current.GetRepairData())
                    {
                        Console.Write($"{item}, ");
                    }
                }
                else
                {
                    Console.WriteLine("Unexpected command");
                    continue;
                }
            }
        }
    }
}
