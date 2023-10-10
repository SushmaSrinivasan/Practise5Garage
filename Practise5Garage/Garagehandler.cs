using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class Garagehandler : IHandler
    {
        private Garage<Vehicle> garage = default!;
        private readonly IUI ui;

        public Garagehandler(IUI ui)
        {
            this.ui = ui;
        }
        public void Create(int garageSize)
        {
            garage = new Garage<Vehicle>(garageSize);
            var airPlane = AirPlane.UpdateValuesToAirPlane();
            var boat = Boat.UpdateValuesToBoat();
            var bus= Bus.UpdateValuesToBus();
            var car=Car.UpdateValuesToCar();
            var motorCycle = Motorcycle.UpdateValuesToMotorcycle();
            var availableParkingSpace = AvailableParkingSpace.CreateParkingSpace();

            garage.ParkVehicle(airPlane);
            garage.ParkVehicle(boat);
            garage.ParkVehicle(bus);
            garage.ParkVehicle(car);
            garage.ParkVehicle(motorCycle);

            AddAvailableParkingSpace(availableParkingSpace);
        }

        public void AddAvailableParkingSpace(Vehicle v)
        {
            foreach(var items in garage)
            {
                if (items == null)
                    garage.ParkVehicle(v);
            }
        }

        public IEnumerable<string> DisplayVehicleByType()
        {
            var vehicleType = garage
            .GroupBy(vehicle => vehicle.GetType().Name)
            .Select(group => new
            {
                TypeName = group.Key,
                Count = group.Count()
            })
            .ToList();
            foreach (var count in vehicleType)
            {
                yield return $"{count.TypeName}: {count.Count}";
            }
        }

        public IEnumerable<string> DisplayVehicleDetails()
        {
            return from item in garage where item.Model != "Available" select $"{item}";
        }

        public void AddVehicle()
        {
            ui.ConsoleWriteLine("Enter the type of vehicle to be added:" +
                "\n 1. AirPlane" +
                "\n 2. Boat" +
                "\n 3. Bus" +
                "\n 4. Car" +
                "\n 5.Motorcycle");
            ui.ConsoleWrite("Enter any number:");
            string number = ui.ConsoleRead();

            AddVehicleProperties();
        }
        public void AddVehicleProperties()
        {
            ui.ConsoleWriteLine("Enter the vehicle model:");
            var model = Validation.CheckModelName(ui);
            ui.ConsoleWriteLine("Enter vehicle registration number:");
            var registrationNumber = Validation.CheckRegistrationNumber(ui);
            ui.ConsoleWriteLine("Enter the color of the vehicle:");
            var color = Validation.CheckColor(ui);
            ui.ConsoleWriteLine("Enter the number of wheels the vehicle has:");
            var numberOfWheels = Validation.CheckNumberOfWheels(ui);
        }

        public void RemoveVehicle()
        {
            DisplayParkedVehiclesWithIndex();
            ui.ConsoleWrite("Enter the index of the vehicle which needs to be removed:");
            int slot = int.TryParse(ui.ConsoleRead(), out var index) ? index : 0;
            RemoveVehicleFromGarage(slot);
        }
        public void DisplayParkedVehiclesWithIndex()
        {
            int vehicleIndex = 0;

            foreach (var vehicle in garage)
            {
                vehicleIndex++;
                ui.ConsoleWriteLine($"{vehicleIndex}. {vehicle}");
            }
        }

        public void RemoveVehicleFromGarage(int slot)
        {
            int index = slot - 1;
            if(index >= 0 && index<garage.ToArray().Length) 
            {
                var availableParkingSpace = AvailableParkingSpace.CreateParkingSpace();
                var removeVehicle = garage. Where((vehicle, index)=>index == slot).FirstOrDefault()!;
                if(removeVehicle.GetType().Name == "AvailableParkingSpace")
                {
                    ui.ConsoleWrite("No vehicle is parked to be removed");
                    return;
                }
                garage.RemoveVehicle(availableParkingSpace, index);
                ui.ConsoleWriteLine($"The vehicle has been removed, {removeVehicle}");
            }
            else
            {
                ui.ConsoleWrite("Invalid parking slot index");
            }
        }

        public void SearchByRegistrationNumber(string registrationNumber)
        {
            var validRegistrationNumber = garage
            .Where(vehicle => vehicle != null &&
                              vehicle.RegistrationNumber.ToLower().Replace(" ", "") == registrationNumber.ToLower().Replace(" ", ""));

            if (validRegistrationNumber.Any())
            {
                ui.ConsoleWriteLine("Registration Number Found In The Garage!");

                foreach (var vehicle in validRegistrationNumber)
                {
                    ui.ConsoleWriteLine(vehicle);
                }
            }
            else
            {
                ui.ConsoleWriteLine($"The Registration Number ({registrationNumber}) Isn't Found In The Garage.");
            }
        }

        public void SearchByProperties(string[] properties)
        {
            var match = GetVehicles(properties);
            if(match.Count > 0)
            {
                foreach(var vehicleMatch in match)
                {
                    if(vehicleMatch.GetType().Name == "AvailableParkingSpace")
                    {
                        ui.ConsoleWriteLine($"You have not entered any value and thus : {vehicleMatch}");
                    }
                    else
                    {
                        ui.ConsoleWriteLine(vehicleMatch);
                    }
                }
            }
        }

        public List<Vehicle> GetVehicles(string[] properties)
        {
            List<Vehicle> match = new List<Vehicle>();
            foreach (var vehicle in garage)
            {
                if (properties.Any(property =>
                    string.IsNullOrEmpty(property) && vehicle.NumberOfWheels == 0 ||
                    vehicle.GetType().Name.Equals(property.Trim(), StringComparison.OrdinalIgnoreCase) ||
                    vehicle.Model.Equals(property.Trim(), StringComparison.OrdinalIgnoreCase) ||
                    vehicle.RegistrationNumber.Equals(property.Trim(), StringComparison.OrdinalIgnoreCase) ||
                    vehicle.Color.Equals(property.Trim(), StringComparison.OrdinalIgnoreCase) ||
                    int.TryParse(property, out int parsedValue) &&
                    (vehicle.NumberOfWheels == parsedValue)))
                {
                    match.Add(vehicle);
                }

            }
            return match;

        }
    }
}
