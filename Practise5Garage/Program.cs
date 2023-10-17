namespace Practise5Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUI ui = new UserInterface();
            Garagehandler garageHandler = new Garagehandler(ui);
            Manager manager = new Manager(garageHandler, ui);
            manager.Run();
        }
    }
}