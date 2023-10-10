using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Practise5Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        public T[] vehicleArray;

        public Garage(int garageSize)
        {
            vehicleArray = new T[garageSize];
        }

        public void ParkVehicle(T Vehicle)
        {
            //check if there is empty slot to park and add/park the vehicle to the garage
            for (int i = 0; i < vehicleArray.Length; i++)
            {
                if (vehicleArray[i] == null)
                {
                    vehicleArray[i] = Vehicle;
                    return;
                }
            }
            throw new ArgumentException("Garage is full and no space to park vehicle anymore");
        }
        public void ParkVehicle(T vehicle, int index)
        {
                        vehicleArray[index]=vehicle;
        }
        public void RemoveVehicle(T vehicle, int index)
        {
            vehicleArray[index] = vehicle;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var  vehicle in vehicleArray)
            {
                yield return vehicle;
            }
                    
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
