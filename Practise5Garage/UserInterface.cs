using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class UserInterface : IUI
    {
        public void ConsoleWrite(string message)=>Console.Write(message);
        public string ConsoleRead()=>(Console.ReadLine() ?? throw new ArgumentException("Cannot be null or whitespace")).Trim();

        public void ConsoleWriteLine(string message)=>Console.WriteLine(message);

        public void ConsoleClear()=>Console.Clear();

        public void ConsoleWriteLine(Vehicle vehicle)=> Console.WriteLine(vehicle);

        public string UserSelection() => (Console.ReadLine() ?? throw new NullReferenceException("Can't Be Null Or Whitespace")).Trim();

        public int ReturnValidNumber()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
