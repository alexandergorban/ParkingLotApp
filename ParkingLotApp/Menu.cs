﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotApp.Entities;

namespace ParkingLotApp
{
    class Menu
    {

        public void BasicMenu()
        {

        }
        public void AppCommands()
        {
            Console.WriteLine("App commands:\n" +
                              "1. 'menu' - Show allowed commands for app\n" +
                              "2. 'setting' - Setting app\n" +
                              "3. 'pfree' - Show number of free places\n" +
                              "4. 'pbusy' - Show number of busy places\n" +
                              "5. 'addcar' - Add car into parking\n" +
                              "6. 'delcar' - Remove car from parking (by id)\n" +
                              "7. 'addbal' - Refill car balance (by id)\n" +
                              "8. 'carbal' - Show car balance (by id)\n" +
                              "9. 'trhist' - Show last minute transaction history\n" +
                              "10. 'prof' - Show parking profit for last minute\n" +
                              "11. 'trlog' - Output Transaction.log\n" +
                              "12. 'exit' - Exit from app");
        }

        public void SettingApp()
        {

        }

        public void NumberAvailableParkingSpaces()
        {
            uint numberAvailableParkingSpaces = Settings.Parking.GetNumberAvailableParkingSpaces();
            Console.WriteLine("Number of available parking spaces: {0}", numberAvailableParkingSpaces);
        }

        public void NumberBusyParkingSpaces()
        {
            uint numberBusyParkingSpaces = Settings.Parking.GetNumberBusyParkingSpaces();
            Console.WriteLine("Number of available parking spaces: {0}", numberBusyParkingSpaces);
        }

        public void AddCar()
        {
            Console.WriteLine("Adding the new car to the parking.");
            Console.WriteLine("Enter carId number: ");
            uint carId = UInt32.Parse(Console.ReadLine());

            while (Settings.Parking.IsCarExist(carId))
            {
                Console.WriteLine("A car with this number is already parked.");
                Console.WriteLine("Enter carId number: ");
                carId = UInt32.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter type of car (leter or number):\n" +
                              "1. 'motorcycle'\n" +
                              "2. 'passenger'\n" +
                              "3. 'truck'\n" +
                              "4. 'bus'\n");
            string enteredType = Console.ReadLine();
            CarType carType;

            switch (enteredType)
            {
                case "1":
                    carType = CarType.Motorcycle;
                    break;
                case "motorcycle":
                    carType = CarType.Motorcycle;
                    break;
                case "2":
                    carType = CarType.Passenger;
                    break;
                case "passenger":
                    carType = CarType.Passenger;
                    break;
                case "3":
                    carType = CarType.Truck;
                    break;
                case "truck":
                    carType = CarType.Truck;
                    break;
                case "4":
                    carType = CarType.Bus;
                    break;
                case "bus":
                    carType = CarType.Bus;
                    break;
                default:
                    throw new Exception(); // todo
            }

            Console.WriteLine("Enter balance for car: ");
            decimal carBalance = UInt32.Parse(Console.ReadLine());

            Settings.Parking.AddCar(new Car(carId, carType, carBalance));
        }

        public void RemoveCar()
        {
            Console.WriteLine("To remove a car from the parking lot,");
            Console.WriteLine("enter carId number: ");
            uint carId = UInt32.Parse(Console.ReadLine());

            if (Settings.Parking.IsCarExist(carId))
            {
                Console.WriteLine(Settings.Parking.RemoveCar(carId)
                    ? "The car is removed from parking."
                    : "The car can not be removed from the parking lot, you have a debt for parking.");
            }
            else
            {
                Console.WriteLine("The car is not parked.");
            }
        }

        //Refill car balance
        public void RefillCarBalance()
        {
            Console.WriteLine("To refill car balance, enter carId number: ");
            uint carId = UInt32.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount: ");
            decimal sum = Decimal.Parse(Console.ReadLine());

            if (Settings.Parking.IsCarExist(carId))
            {
                Settings.Parking.IncreaseCarBalance(carId, sum);
                Console.WriteLine("The car balance has refilled.");
            }
            else
            {
                Console.WriteLine("The car is not parked.");
            }
        }

        //Display car balance
        public void CarBalance()
        {
            Console.WriteLine("To display car balance, enter carId number: ");
            uint carId = UInt32.Parse(Console.ReadLine());

            if (Settings.Parking.IsCarExist(carId))
            {
                Console.WriteLine("The car balance: {0}", Settings.Parking.GetCarBalance(carId));
            }
            else
            {
                Console.WriteLine("The car is not parked.");
            }
        }

        //Display last minute transaction history
        public void TransactionHistory()
        {
            IEnumerable<Transaction> transactions = Settings.Parking.GetLastTransactions(1);

            Console.WriteLine("Last minute transaction history: ");
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        //Display parking profit
        public void ParkingProfit()
        {
            Console.WriteLine("Parking profit: {0}", Settings.Parking.GetEarnedMoney());
        }

        //Display parking profit for last minute
        public void LastMinParkingProfit()
        {
            Console.WriteLine("Parking profit for last minute: {0}", Settings.Parking.GetEarnedMoney(1));
        }

        //Display Transction.log file
        public void DisplayTransactionLogFile()
        {
            Console.WriteLine("Transction.log file:\n {0}", Settings.FileReader.ReadTransactionFromFile());
        }
    }
}
