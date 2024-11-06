using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types.Coffee
{
    class CoffeeReceipt : IReceipt
    {
        public string? Name { get; private set; }
        public int Price { get; private set; }
        public double WaterConsumption { get; private set; }
        public double MilkConsumption { get; private set; }
        public double CoffeeConsumption { get; private set; }
        public double SugarConsumption { get; private set; }

        public CoffeeReceipt(string? name, int price, double waterConsumption, double milkConsumption, double coffeeConsumption, double sugarConsumption)
        {
            if (waterConsumption + milkConsumption + coffeeConsumption > CoffeeVendingOptions.MaxCupCapacity) throw new ArgumentException($"Общий объём ингридиентов не должен превосходить {CoffeeVendingOptions.MaxCupCapacity * 1000}мл!");
            Name = name;
            Price = price;
            WaterConsumption = waterConsumption;
            MilkConsumption = milkConsumption;
            CoffeeConsumption = coffeeConsumption;
            SugarConsumption = sugarConsumption;
        }
        public override string ToString()
        {
            return Name!;
        }
    }
}
