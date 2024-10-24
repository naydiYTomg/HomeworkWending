using HomeworkVendingCool.Types;
using HomeworkVendingCool.Types.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool
{
    class CLI
    {
        private CoffeeVending? _current;
        private bool _isWorking = false;

        public void SetEnvironment(List<CoffeeReceipt> receipts)
        {
            if (_current == null)
            {
                _current = new CoffeeVending(receipts);

            }
            else
            {
                throw new Exception("Окружение уже установлено!");
            }
        }
        public void Stop()
        {
            _isWorking = false;
        }

        private void HandleBuy()
        {
            Console.Clear();
            Console.WriteLine($"Текущий баланс: {_current.GetBalance()}");
            _current!.PrintReceipts();
            Console.WriteLine("Введите номер кофе и нужен ли сахар (например: 1 y (если хотите 1 кофе с сахаром); 3 n (если хотите 3 кофе без сахара))");
            string _userInputResult = Console.ReadLine()!;
            string[] split = _userInputResult.Split(' ');
            if (split.Length != 2) throw new Exception();
            if (!int.TryParse(split[0], out int index)) throw new Exception();
            if (split[1] != "n" && split[1] != "y") throw new Exception();
            try
            {
                _current.Buy(index, split[1] == "y");
            } catch(Exception ex)
            {
                if (ex is NotEnoughCoffeeException)
                {
                    Console.WriteLine($"В автомате не хватает {((NotEnoughCoffeeException)ex).NotEnough} кофе!");
                }else if (ex is NotEnoughMilkException)
                {
                    Console.WriteLine($"В автомате не хватает {((NotEnoughMilkException)ex).NotEnough} молока!");
                }else if (ex is NotEnoughWaterException)
                {
                    Console.WriteLine($"В автомате не хватает {((NotEnoughWaterException)ex).NotEnough} воды!");
                }else if (ex is NotEnoughSugarException)
                {
                    Console.WriteLine($"В автомате не хватает {((NotEnoughSugarException)ex).NotEnough} сахара!");
                }else if (ex is NotEnoughMoneyException)
                {
                    Console.WriteLine($"Вы внесли недостаточно денег! Внесите ещё {((NotEnoughMoneyException)ex).NotEnough}");
                }else if (ex is ReceiptDoesNotExistsException)
                {
                    Console.WriteLine(ex.Message);
                    HandleBuy();
                }

            }
        }
        private void HandleMoney()
        {
            Console.Clear();
            Console.WriteLine($"Текущий баланс: {_current.GetBalance()}");
            Console.WriteLine("Внесите деньги (50/100/200/500/1000/2000/5000)");
            int[] _desiredInput = [50, 100, 200, 500, 1000, 2000, 5000];
            bool _result = int.TryParse(Console.ReadLine(), out int _gotInput);
            if (!_desiredInput.Contains(_gotInput)) { Console.WriteLine("Автомат не может принять такую банкноту!"); return; }
            switch (_gotInput)
            {
                case 50: _current.ConsumeBanknote(BanknoteType.FiftyRubles); break;
                case 100: _current.ConsumeBanknote(BanknoteType.HundredRubles); break;
                case 200: _current.ConsumeBanknote(BanknoteType.TwoHundredRubles); break;
                case 500: _current.ConsumeBanknote(BanknoteType.FiveHundredRubles); break;
                case 1000: _current.ConsumeBanknote(BanknoteType.ThousandRubles); break;
                case 2000: _current.ConsumeBanknote(BanknoteType.TwoThousandRubles); break;
                case 5000: _current.ConsumeBanknote(BanknoteType.FiveThousandRubles); break;
            }
        }

        public void Run()
        {
            if (_current == null) throw new Exception("Окружение не установлено!");
            _isWorking = true;
            while (_isWorking)
            {
                Console.WriteLine("Press enter");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Текущий баланс: {_current.GetBalance()}");
                Console.WriteLine("b/buy - купить кофе\nr/repair - починить автомат\na/addmoney - внести деньги\ne/exit - выйти");
                Console.Write("::|");
                string userInputResult = Console.ReadLine();
                if (userInputResult.Equals("b", StringComparison.OrdinalIgnoreCase) || userInputResult.Equals("buy", StringComparison.OrdinalIgnoreCase))
                {
                    HandleBuy();
                }
                else if (userInputResult.Equals("r", StringComparison.OrdinalIgnoreCase) || userInputResult.Equals("repair", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear();
                    _current.Refill();
                    Console.WriteLine("Ингредиенты успешно пополнены!");
                }else if (userInputResult.Equals("a", StringComparison.OrdinalIgnoreCase) || userInputResult.Equals("addmoney", StringComparison.OrdinalIgnoreCase))
                {
                    HandleMoney();
                }
                else if (userInputResult.Equals("e", StringComparison.OrdinalIgnoreCase) || userInputResult.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Stop();
                }
                else if (userInputResult == null) Console.WriteLine("Пустой ввод");
                else Console.WriteLine("Неверная или не существующая команда!");
                
            }
        }
    }
}
