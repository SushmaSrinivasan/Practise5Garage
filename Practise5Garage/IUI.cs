using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public interface IUI
    {
        public void ConsoleWrite(string message);
        public string ConsoleRead();

        public void ConsoleWriteLine(string message);

        public void ConsoleClear();

       public void ConsoleWriteLine(Vehicle vehicle);

        public string UserSelection();
        public int ReturnValidNumber();

    }
}
