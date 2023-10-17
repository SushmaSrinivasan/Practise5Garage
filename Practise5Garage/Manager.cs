using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public class Manager
    {
        public Garagehandler garageHandler;
        public IUI ui;
        private bool isRunning;

        public Manager(Garagehandler handler, IUI ui)
        {
            garageHandler = handler;
            this.ui = ui;
        }


        public void Run()
        {
            CreateGarage();
            MenuOptions();
        }

        private void CreateGarage()
        {
            //  ui.ConsoleWriteLine("Enter capacity of Garge");
            //if (int.TryParse(ui.ConsoleRead(), out int capcity))
            //{
            var capacity = 20;
            garageHandler.Create(capacity);

            //}
        }

        public void MenuOptions()
        {
            do
            {
                isRunning = true;
                ui.ConsoleClear();
                ui.ConsoleWriteLine("Welcome to Garage! Enter any of the options below: " +
                    "\n 1. List all parked vehicles" +
                    "\n 2. List Vehicle type and how many vehicles of that type is parked" +
                    "\n 3. Add Vehicle" +
                    "\n 4. Remove Vehicle" +
                    "\n 5. Search Vehicle by Registration Number" +
                    "\n 6. Search Vehicle by properties" +
                    "\n 0. Exit the main menu");
                ui.ConsoleWrite("Enter any option:");
                string option = ui.ConsoleRead();
                switch (option)
                {
                    case "1":
                        ui.ConsoleWrite("List of Parked Vehicles Details:\n");
                        var result = garageHandler.DisplayVehicleDetails();
                        foreach (var vehicleString in result)
                        {
                            ui.ConsoleWrite(vehicleString);
                        }
                        break;
                    case "2":
                        ui.ConsoleWriteLine("List of Vehicles parked based on Type:\n");
                        garageHandler.DisplayVehicleByType().ForEach(groupString => ui.ConsoleWriteLine(groupString));
                        break;
                    case "3":
                        if (garageHandler.IsFull())
                        {
                            ui.ConsoleWriteLine("Garage is full");
                            break;
                        }
                        garageHandler.AddVehicle();
                        break;
                    case "4":
                        garageHandler.RemoveVehicle();
                        break;
                    case "5":
                        ui.ConsoleWrite("Enter the registration number to search:");
                        var registrationNumber = Validation.CheckRegistrationNumber(ui);
                        garageHandler.SearchByRegistrationNumber(registrationNumber);
                        break;
                    case "6":
                        ui.ConsoleWrite("Enter the properties of vehicle to search:");
                        garageHandler.SearchByProperties(ui.UserSelection().Split(' '));
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        ui.ConsoleWriteLine("Invalid entry.. Try again!");
                        break;
                }

                ui.ConsoleRead();

            } while (isRunning);
        }
    }
}
