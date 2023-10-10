using System.Drawing;

namespace Practise5Garage
{
    public class Vehicle : IVehicle
    {
        public string? Model { get; set; } = string.Empty;
        public string? RegistrationNumber { get; set; } = string.Empty;
        public string? Color { get; set; } = string.Empty;
        public int NumberOfWheels { get; set; }
        public int counter { get; set; }

        public Vehicle()
        { }
        public Vehicle(string model, string registrationNumber, string color, int numberOfWheels)
        { 
            Model = model;
            RegistrationNumber = registrationNumber;
            Color = color;
            NumberOfWheels = numberOfWheels;

        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Model:{Model}, RegistrationNumber:{RegistrationNumber}, Color:{Color},NumberOfWheels:{NumberOfWheels}";
        }


    }





}

    
