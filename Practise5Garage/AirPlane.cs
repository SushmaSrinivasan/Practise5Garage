using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class AirPlane : Vehicle
    {
        
        private static readonly int numberOfWheels;

        public double AircraftWeight { get; set; }

        public AirPlane(string model, string registrationNumber, string color, int numberofWheels, double aircraftWeight) : base(model, registrationNumber, color, numberOfWheels)
        {
            
            AircraftWeight = aircraftWeight;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, AircraftWeight: {AircraftWeight}";
        }

        public static AirPlane UpdateValuesToAirPlane()
        {
            return new AirPlane("Boeing357", "ABC 123", "White", 4, 350.0);
        }
    }
}
