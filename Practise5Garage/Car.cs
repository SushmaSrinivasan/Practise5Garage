using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class Car : Vehicle
    {
        private static new int counter;
        private static readonly int numberOfWheels;

        public int Speed { get; set; }

        public Car(string model, string registrationNumber, string color, int numberofWheels, int speed) : base(model, registrationNumber, color, numberOfWheels)
        { 
            counter++;
            base.counter = counter;
            Speed = speed;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Speed:{Speed}";
        }

        public static Car UpdateValuesToCar()
        {
            return new Car("Toyota", "PDZ 702", "Brown", 4, 70);
        }

    }
}
