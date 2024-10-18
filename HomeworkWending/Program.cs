using HomeworkWending.Types;

namespace HomeworkWending
{
    class Program
    {
        static void Main(string[] args)
        {
            CLI cli = new CLI();
            cli.SetEnvironment("Super coffee vending", 100, 50, 50, 30, 300);
            cli.Run();
        }
    }
}
