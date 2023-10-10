using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class Bus : Vehicle
    {
        private static new int counter;
        private static readonly int numberOfWheels;

        public int NumberOfSeats { get; set; }

        public Bus(string model, string registrationNumber, string color, int numberofWheels, int numberOfSeats) : base(model, registrationNumber, color, numberOfWheels)
        {
            counter++;
            base.counter = counter;
            NumberOfSeats = numberOfSeats;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, NumberOfSeats: {NumberOfSeats}";
        }

        public static Bus UpdateValuesToBus()
        {
            return new Bus("DoubleDecker", "LMJ 305", "Red", 6, 30);
        }
    }
}
