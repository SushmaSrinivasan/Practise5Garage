using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public interface IVehicle
    {
        public string? Model { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? Color { get; set; }
        public int NumberOfWheels { get; set; }
        public int counter { get; set; }
    }
}
