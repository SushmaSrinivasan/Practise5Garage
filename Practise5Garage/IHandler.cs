using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    internal interface IHandler
    {
        void AddAvailableParkingSpace(Vehicle v);
        IEnumerable<string> DisplayVehicleDetails();
        List<string> DisplayVehicleByType();

        void AddVehicle();

        void RemoveVehicle();

        void SearchByRegistrationNumber(string registrationNumber);

        void SearchByProperties(string[] properties);
        List<Vehicle> GetVehicles(string[] properties);
    }
}
