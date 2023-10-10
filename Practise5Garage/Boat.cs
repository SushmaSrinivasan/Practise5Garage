using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class Boat : Vehicle
    {
        private static new int counter;
        private static readonly int numberOfWheels;

        public double Length { get; set; }

        public Boat(string model, string registrationNumber, string color, int numberofWheels, double length) : base(model, registrationNumber, color, numberOfWheels)
        {
            counter++;
            base.counter = counter;
            Length = length;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Length: {Length}";
        }

        public static Boat UpdateValuesToBoat()
        {
            return new Boat("SpeedBoat", "KDX 895", "Blue", 0, 65.0);
        }
    }
}
