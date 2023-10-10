using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class AvailableParkingSpace : Vehicle
    {
        private static new int counter;
        private static readonly int numberOfWheels;

        public double Length { get; set; }

        public AvailableParkingSpace(string model, string registrationNumber, string color, int numberofWheels) : base(model, registrationNumber, color, numberOfWheels)
        {
            counter++;
            base.counter = counter;
            
        }

        public override string ToString()
        {
            return $"Parking space is available";
        }
        public static AvailableParkingSpace CreateParkingSpace()
        {
            return new AvailableParkingSpace("Available","Available","Available",0) ;
        }
    }
}
