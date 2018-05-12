using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotApp.Entities;
using ParkingLotApp.Exceptions;

namespace ParkingLotApp
{
    class Menu
    {

        public void StartApp()
        {
            AppCommands();
        }
        private void AppCommands()
        {
            Console.WriteLine("App commands:\n" +
                              "1. 'pfree' - Show number of free places\n" +
                              "2. 'pbusy' - Show number of busy places\n" +
                              "3. 'addcar' - Add car into parking\n" +
                              "4. 'delcar' - Remove car from parking (by id)\n" +
                              "5. 'addbal' - Refill car balance (by id)\n" +
                              "6. 'carbal' - Show car balance (by id)\n" +
                              "7. 'trhist' - Show last minute transaction history\n" +
                              "8. 'prof' - Show parking profit\n" +
                              "9. 'profmin' - Show parking profit for last minute\n" +
                              "10. 'trlog' - Output Transaction.log\n" +
                              "11. 'exit' - Exit from app\n" +
                              "Enter command:");

            string command = Console.ReadLine();

            Console.Clear();

            switch (command)
            {
                case "1":
                    NumberAvailableParkingSpaces();
                    break;
                case "pfree":
                    NumberAvailableParkingSpaces();
                    break;
                case "2":
                    NumberBusyParkingSpaces();
                    break;
                case "pbusy":
                    NumberBusyParkingSpaces();
                    break;
                case "3":
                    AddCar();
                    break;
                case "addcar":
                    AddCar();
                    break;
                case "4":
                    RemoveCar();
                    break;
                case "delcar":
                    RemoveCar();
                    break;
                case "5":
                    RefillCarBalance();
                    break;
                case "addbal":
                    RefillCarBalance();
                    break;
                case "6":
                    CarBalance();
                    break;
                case "carbal":
                    CarBalance();
                    break;
                case "7":
                    TransactionHistory();
                    break;
                case "trhist":
                    TransactionHistory();
                    break;
                case "8":
                    ParkingProfit();
                    break;
                case "prof":
                    ParkingProfit();
                    break;
                case "9":
                    ParkingProfit();
                    break;
                case "profmin":
                    ParkingProfit();
                    break;
                case "10":
                    DisplayTransactionLogFile();
                    break;
                case "trlog":
                    DisplayTransactionLogFile();
                    break;
                case "11":
                    return;
                case "exit":
                    return;
                default:
                    throw new Exception(); // todo
            }

            BackToMenu();
        }

        private void BackToMenu()
        {
            int command = -1;
            while (command != 0)
            {
                Console.WriteLine("Enter '0' to return to the main menu:");

                try
                {
                    string input = Console.ReadLine();

                    if (input.Length !=1)
                    {
                        throw new CommandErrorException("Incorrent entered command");
                    }

                    command = Int32.Parse(input);
                }
                catch (CommandErrorException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
            }

            Console.Clear();
            AppCommands();
        }

        private void NumberAvailableParkingSpaces()
        {
            uint numberAvailableParkingSpaces = Settings.Parking.GetNumberAvailableParkingSpaces();
            Console.WriteLine("Number of available parking spaces: {0}", numberAvailableParkingSpaces);
        }

        private void NumberBusyParkingSpaces()
        {
            uint numberBusyParkingSpaces = Settings.Parking.GetNumberBusyParkingSpaces();
            Console.WriteLine("Number of available parking spaces: {0}", numberBusyParkingSpaces);
        }

        private void AddCar()
        {
            Console.WriteLine("Adding the new car to the parking.");
            Console.WriteLine("Enter carId number: ");
            try
            {
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
                                  "4. 'bus'");
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
                        throw new EnterDataErrorException("Incorrent entered data");
                }

                Console.WriteLine("Enter balance for car: ");
                decimal carBalance = UInt32.Parse(Console.ReadLine());

                Settings.Parking.AddCar(new Car(carId, carType, carBalance));
            }
            catch (EnterDataErrorException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void RemoveCar()
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
        private void RefillCarBalance()
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
        private void CarBalance()
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
        private void TransactionHistory()
        {
            IEnumerable<Transaction> transactions = Settings.Parking.GetLastTransactions(1);

            Console.WriteLine("Last minute transaction history: ");
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        //Display parking profit
        private void ParkingProfit()
        {
            Console.WriteLine("Parking profit: {0}", Settings.Parking.GetEarnedMoney());
        }

        //Display parking profit for last minute
        private void LastMinParkingProfit()
        {
            Console.WriteLine("Parking profit for last minute: {0}", Settings.Parking.GetEarnedMoney(1));
        }

        //Display Transction.log file
        private void DisplayTransactionLogFile()
        {
            Console.WriteLine("Transction.log file:\n {0}", Settings.ParkingService.FileReader.ReadTransactionFromFile());
        }
    }
}


