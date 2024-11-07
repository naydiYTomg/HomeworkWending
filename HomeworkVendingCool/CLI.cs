using HomeworkVendingCool.Types;
using HomeworkVendingCool.Types.Coffee;
using HomeworkVendingCool.Types.Errors;
using HomeworkVendingCool.Types.Soda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool
{
    
    class CLI<T> where T : AbstractVendingMachine<IReceipt>
    {
        private T? _current;
        private bool _isWorking = false;
        private Dictionary<string, T> _machines = new();

        public void SetEnvironment()
        {

            Console.WriteLine("Первичная настройка. Выберите автомат чтобы добавить: \n1 - Кофейный автомат\n2 - Автомат с газировкой\nвведите q чтобы завершить насстройку");
            string userInput = Console.ReadLine()!;
            while (userInput != "q")
            {
                if (userInput == "1")
                {
                    Console.WriteLine("Введите название автомата");
                    string nameOfMachine = Console.ReadLine()!;
                    //List<CoffeeReceipt> coffeeReceipts = new List<CoffeeReceipt>();
                    //foreach (var receipt in receipts)
                    //{
                    //    coffeeReceipts.Add(receipt.ConvertTo<CoffeeReceipt>());
                    //}
                    _machines.Add(nameOfMachine, (new CoffeeVending(CoffeeVendingOptions.GetDefaultReceipts()) as T));
                    Console.WriteLine($"Автомат {nameOfMachine} успешно добавлен");
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Введите название автомата");

                    string nameOfMachine = Console.ReadLine()!;
                    //List<SodaReceipt> sodaReceipts = new List<SodaReceipt>();
                    //foreach (var receipt in receipts)
                    //{
                    //    sodaReceipts.Add(receipt.ConvertTo<SodaReceipt>());
                    //}
                    _machines.Add(nameOfMachine, (new SodaVending(SodaVendingOptions.GetDefaultReceipts()) as T));
                    Console.WriteLine($"Автомат {nameOfMachine} успешно добавлен");
                }
                else
                {
                    Console.WriteLine($"Автомата {userInput} не существует!");
                }
                userInput = Console.ReadLine()!;
            }

            AdminEnvironment();
            


            //if (_current == null)
            //{
            //    _current = new CoffeeVending(receipts);

            //}
            //else
            //{
                
            //    throw new Exception("Окружение уже установлено!");
            //}
        }
        public void Stop()
        {
            _isWorking = false;
        }
        private void AdminEnvironment()
        {
            Console.WriteLine("Выберите команду:\n!c - выбрать автомат\n!r - починить все автоматы\n!g - получить выручку\n!e - выйти");
            string userInputCommand = Console.ReadLine()!;
            if (userInputCommand.ToLower() == "!c")
            {
                Console.WriteLine("Выберите автомат");
                foreach (string machine in _machines.Keys)
                {
                    Console.WriteLine($"{machine} - {_machines[machine]}");
                }

                while (true)
                {
                    string userInputtedMachineName = Console.ReadLine()!;
                    try
                    {
                        _current = _machines[userInputtedMachineName];
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Такого автомата не существует!");
                    }
                }
            }
            else if (userInputCommand.ToLower() == "!r")
            {
                List<T> _needRepairMachines = new List<T>();
                foreach (var m in _machines)
                {
                    Console.WriteLine($"{m.Key}::{m.Value}");
                }
                foreach (var machine in _machines.Values)
                {
                    if (machine.IsNeedRepair()) _needRepairMachines.Add(machine);
                }
                if (_needRepairMachines.Count != 0)
                {
                    Console.WriteLine("Вот эти автоматы будут починены");
                    foreach (T machine in _needRepairMachines)
                    {
                        Console.WriteLine(machine.ToString());
                        machine.Refill();
                    }
                }
                else
                {
                    Console.WriteLine("Все автоматы починены");
                }

            }
            else if (userInputCommand.ToLower() == "!g")
            {
                int sales = 0;

                foreach (var machine in _machines.Values)
                {
                    sales += machine.GetTotalSales();
                }
                Console.WriteLine($"Всего продаж - {sales}");
            }
            else if (userInputCommand.ToLower() == "!e")
            {
                Stop();
            }
        }

        public void Run()
        {
            if (_current == null) throw new Exception("Окружение не установлено!");
            _isWorking = true;
            if (_current is CoffeeVending)
            {
                Handle(VendingTypes.Coffee);
            }else if (_current is SodaVending)
            {
                Handle(VendingTypes.Soda);
            }
            else
            {
                throw new Exception("Неизвестный автомат");
            }
        }

        private void Handle(VendingTypes type)
        {
            while(_isWorking)
            {
                Console.WriteLine("Press enter");
                Console.ReadLine();
                Console.Clear();
                switch (type)
                {
                    case VendingTypes.Coffee:
                        Console.WriteLine($"Текущий баланс: {(_current as CoffeeVending)!.GetBalance()}");
                        Console.WriteLine("b/buy - купить кофе\nr/repair - починить автомат\na/addmoney - внести деньги\ne/exit - выйти");
                        Console.Write("::|");
                        string userInputResult = Console.ReadLine()!;
                        if (userInputResult.Equals("b", StringComparison.OrdinalIgnoreCase) || userInputResult.Equals("buy", StringComparison.OrdinalIgnoreCase))
                        {
                            HandleBuy(VendingTypes.Coffee);
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
                            AdminEnvironment();
                        }
                        else if (userInputResult == null) Console.WriteLine("Пустой ввод");
                        else Console.WriteLine("Неверная или не существующая команда!");
                        break;
                    case VendingTypes.Soda:
                        Console.WriteLine($"Текущий баланс: {(_current as SodaVending)!.GetBalance()}");
                        Console.WriteLine("b/buy - купить газировку\nr/repair - починить автомат\na/addmoney - внести деньги\ne/exit - выйти");
                        Console.Write("::|");
                        string userInputResultSoda = Console.ReadLine()!;
                        if (userInputResultSoda.Equals("b", StringComparison.OrdinalIgnoreCase) || userInputResultSoda.Equals("buy", StringComparison.OrdinalIgnoreCase))
                        {
                            HandleBuy(VendingTypes.Soda);
                        }
                        else if (userInputResultSoda.Equals("r", StringComparison.OrdinalIgnoreCase) || userInputResultSoda.Equals("repair", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.Clear();
                            _current.Refill();
                            Console.WriteLine("Газировки успешно пополнены!");
                        }
                        else if (userInputResultSoda.Equals("a", StringComparison.OrdinalIgnoreCase) || userInputResultSoda.Equals("addmoney", StringComparison.OrdinalIgnoreCase))
                        {
                            HandleMoney();
                        }
                        else if (userInputResultSoda.Equals("e", StringComparison.OrdinalIgnoreCase) || userInputResultSoda.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        {
                            AdminEnvironment();
                        }
                        else if (userInputResultSoda == null) Console.WriteLine("Пустой ввод");
                        else Console.WriteLine("Неверная или не существующая команда!");
                        break;
                }
            }
        }

        private void HandleBuy(VendingTypes type)
        {
            string _userInputResult;
            Console.Clear();
            Console.WriteLine($"Текущий баланс: {_current!.GetBalance()}");
            _current!.PrintReceipts();
            switch (type)
            {
                case VendingTypes.Coffee:
                    Console.WriteLine("Введите номер кофе и нужен ли сахар (например: 1 y (если хотите 1 кофе с сахаром); 3 n (если хотите 3 кофе без сахара))");
                    _userInputResult = Console.ReadLine()!;
                    string[] split = _userInputResult.Split(' ');
                    if (split.Length != 2) throw new Exception();
                    if (!int.TryParse(split[0], out int indexCoffee)) throw new Exception();
                    if (split[1] != "n" && split[1] != "y") throw new Exception();
                    try
                    {
                        _current.Buy(indexCoffee, split[1] == "y");
                    }
                    catch (Exception ex)
                    {
                        if (ex is NotEnoughCoffeeException)
                        {
                            Console.WriteLine($"В автомате не хватает {((NotEnoughCoffeeException)ex).NotEnough} кофе!");
                        }
                        else if (ex is NotEnoughMilkException)
                        {
                            Console.WriteLine($"В автомате не хватает {((NotEnoughMilkException)ex).NotEnough} молока!");
                        }
                        else if (ex is NotEnoughWaterException)
                        {
                            Console.WriteLine($"В автомате не хватает {((NotEnoughWaterException)ex).NotEnough} воды!");
                        }
                        else if (ex is NotEnoughSugarException)
                        {
                            Console.WriteLine($"В автомате не хватает {((NotEnoughSugarException)ex).NotEnough} сахара!");
                        }
                        else if (ex is NotEnoughMoneyException)
                        {
                            Console.WriteLine($"Вы внесли недостаточно денег! Внесите ещё {((NotEnoughMoneyException)ex).NotEnough}");
                        }
                        else if (ex is ReceiptDoesNotExistsException)
                        {
                            Console.WriteLine(ex.Message);
                            HandleBuy(VendingTypes.Coffee);
                        }

                    }
                    break;
                case VendingTypes.Soda:
                    Console.WriteLine("Введите номер газировки");
                    _userInputResult = Console.ReadLine()!;
                    string[] trySplit = _userInputResult.Split(' ');
                    if (!int.TryParse(_userInputResult, out int indexSoda)) throw new Exception();
                    if (trySplit.Length != 1) throw new Exception();
                    try
                    {
                        _current.Buy(indexSoda, null);
                    }
                    catch (Exception ex)
                    {
                        if (ex is NotEnoughMoneyException) { Console.WriteLine($"Вы внесли недостаточно денег! Внесите ещё {((NotEnoughMoneyException)ex).NotEnough}"); }
                        else if (ex is ReceiptDoesNotExistsException)
                        {
                            Console.WriteLine(ex.Message);
                            HandleBuy(VendingTypes.Soda);
                        }
                    }
                    break;
            }
        }
        private void HandleMoney()
        {
            Console.Clear();
            Console.WriteLine($"Текущий баланс: {_current!.GetBalance()}");
            Console.WriteLine("Внесите деньги (50/100/200/500/1000/2000/5000)");
            int[] _desiredInput = [50, 100, 200, 500, 1000, 2000, 5000];
            bool _result = int.TryParse(Console.ReadLine(), out int _gotInput);
            if (!_desiredInput.Contains(_gotInput)) { Console.WriteLine("Автомат не может принять такую банкноту!"); return; }
            switch (_gotInput)
            {
                case 50: _current.TakeBanknote(BanknoteType.FiftyRubles); break;
                case 100: _current.TakeBanknote(BanknoteType.HundredRubles); break;
                case 200: _current.TakeBanknote(BanknoteType.TwoHundredRubles); break;
                case 500: _current.TakeBanknote(BanknoteType.FiveHundredRubles); break;
                case 1000: _current.TakeBanknote(BanknoteType.ThousandRubles); break;
                case 2000: _current.TakeBanknote(BanknoteType.TwoThousandRubles); break;
                case 5000: _current.TakeBanknote(BanknoteType.FiveThousandRubles); break;
            }
        }

        //public void Run()
        //{
        //    if (_current == null) throw new Exception("Окружение не установлено!");
        //    _isWorking = true;
        //    while (_isWorking)
        //    {
        //        Console.WriteLine("Press enter");
        //        Console.ReadLine();
        //        Console.Clear();
        //        Console.WriteLine($"Текущий баланс: {_current.GetBalance()}");
        //        Console.WriteLine("b/buy - купить кофе\nr/repair - починить автомат\na/addmoney - внести деньги\ne/exit - выйти");
        //        Console.Write("::|");
        //        string userInputResult = Console.ReadLine();
        //        if (userInputResult.Equals("b", StringComparison.OrdinalIgnoreCase) || userInputResult.Equals("buy", StringComparison.OrdinalIgnoreCase))
        //        {
        //            HandleBuy();
        //        }
        //        else if (userInputResult.Equals("r", StringComparison.OrdinalIgnoreCase) || userInputResult.Equals("repair", StringComparison.OrdinalIgnoreCase))
        //        {
        //            Console.Clear();
        //            _current.Refill();
        //            Console.WriteLine("Ингредиенты успешно пополнены!");
        //        }else if (userInputResult.Equals("a", StringComparison.OrdinalIgnoreCase) || userInputResult.Equals("addmoney", StringComparison.OrdinalIgnoreCase))
        //        {
        //            HandleMoney();
        //        }
        //        else if (userInputResult.Equals("e", StringComparison.OrdinalIgnoreCase) || userInputResult.Equals("exit", StringComparison.OrdinalIgnoreCase))
        //        {
        //            Stop();
        //        }
        //        else if (userInputResult == null) Console.WriteLine("Пустой ввод");
        //        else Console.WriteLine("Неверная или не существующая команда!");
                
        //    }
        //}
    }
}
