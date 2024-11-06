using HomeworkVendingCool.Types.Coffee;

namespace HomeworkVendingCool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CLI cli = new CLI();
            cli.SetEnvironment(CoffeeVendingOptions.GetDefaultReceipts());
            cli.Run();
        }
    }
}
