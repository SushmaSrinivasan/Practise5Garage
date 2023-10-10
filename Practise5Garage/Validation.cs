using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Practise5Garage
{
    public static class Validation
    {
        public static string CheckModelName(IUI ui)
        {
            string modelName;

            do
            {
                modelName = ui.UserSelection();
                if (!IsValidModelName(modelName))
                {
                    ui.ConsoleWrite("Model name must be atleast 3 characters");
                }
            } while (IsValidModelName(modelName));
            return modelName;
        }
        public static string CheckRegistrationNumber(IUI ui) 
        { 
        
            string registrationNumber;

            do
            {
                registrationNumber = ui.UserSelection();
                if (!IsValidRegistrationNumber(registrationNumber))
                {
                    ui.ConsoleWrite("Enter a valid registration number where first 3 letters are alphabets and last 3 letters are numbers:");
                }
            } while (IsValidRegistrationNumber(registrationNumber));
            return registrationNumber;
        
        }
        public static string CheckColor(IUI ui)
        {
            string color;
            do
            {
                color = ui.UserSelection();
                if (!IsValidColor(color))
                {
                    ui.ConsoleWrite("Color name should have atleast 3 characters and less than 15 characters");
                }
            } while (IsValidColor(color));
            return color;
        }
        public static int CheckNumberOfWheels(IUI ui)
        {
            int numberOfWheels;

            do
            {
                numberOfWheels = ui.ReturnValidNumber();
                if (!IsValidNumberOfWheels(numberOfWheels))
                {
                    ui.ConsoleWrite("The number of wheels should not be more than 15");
                }
            } while (IsValidNumberOfWheels(numberOfWheels));
            return numberOfWheels;
        }

        public static bool IsValidModelName(string modelName)
        {
            bool IsValidModelName = modelName.Length >= 3;
            return IsValidModelName;
        }

        public static bool IsValidRegistrationNumber(string number)
        { 
           bool isFirstThreeLetters = number
            .Take(3)
            .All(char.IsLetter);
        bool isLastThreeNumbers = number
            .TakeLast(3)
            .All(char.IsDigit);
        return isFirstThreeLetters && isLastThreeNumbers;
        }

        public static bool IsValidColor(string color)
        {
            bool isValidColor = color.Length >= 3;
            return isValidColor;
        }

        public static bool IsValidNumberOfWheels(int numberOfWheels)
        {
            bool IsValidNumberOfWheels = numberOfWheels <= 15;
            return IsValidNumberOfWheels;
        }
    }
}
