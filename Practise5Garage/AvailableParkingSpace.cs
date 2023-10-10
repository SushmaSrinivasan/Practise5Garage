using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class AvailableParkingSpace : Vehicle
    {
        
        private static readonly int numberOfWheels;

        public AvailableParkingSpace(string model, string registrationNumber, string color, int numberofWheels) : base(model, registrationNumber, color, numberOfWheels)
        {
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
