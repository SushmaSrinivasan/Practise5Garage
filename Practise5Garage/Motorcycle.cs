using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class Motorcycle : Vehicle
    {
        private static new int counter;
        private static readonly int numberOfWheels;

        public string Power { get; set; }

        public Motorcycle(string model, string registrationNumber, string color, int numberofWheels, string power) : base(model, registrationNumber, color, numberOfWheels)
        {
            counter++;
            base.counter = counter;
            Power= power;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Power: {Power}";
        }
        public static Motorcycle UpdateValuesToMotorcycle()
        {
            return new Motorcycle("Cresent", "PPF 772", "Black", 2, "120");
        }
    }
}
