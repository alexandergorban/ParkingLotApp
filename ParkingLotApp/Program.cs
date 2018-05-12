using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotApp.Entities;

namespace ParkingLotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Added mock data
            List<Car> cars = new List<Car>();
            cars.Add(new Car(1, CarType.Motorcycle, 50));
            cars.Add(new Car(2, CarType.Passenger, 90));
            cars.Add(new Car(3, CarType.Bus, 200));
            cars.Add(new Car(4, CarType.Truck, 300));
            cars.Add(new Car(5, CarType.Motorcycle, 100));
            cars.Add(new Car(6, CarType.Passenger, 200));
            cars.Add(new Car(7, CarType.Passenger, 150));

            foreach (Car car in cars)
            {
                Settings.Parking.AddCar(car);
            }


            Console.WriteLine("Start App");
            Menu menu = new Menu();
            menu.AppCommands();
        }
    }
}
