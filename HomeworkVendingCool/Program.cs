using HomeworkVendingCool.Types;
using HomeworkVendingCool.Types.Coffee;

namespace HomeworkVendingCool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CLI<AbstractVendingMachine<IReceipt>> cli = new();
            cli.SetEnvironment();
            cli.Run();
        }
    }
}
