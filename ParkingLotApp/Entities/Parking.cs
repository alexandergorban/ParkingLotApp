using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ParkingLotApp.Exceptions;

namespace ParkingLotApp.Entities
{
    class Parking
    {
        private static readonly Lazy<Parking> LazyParking = new Lazy<Parking>(() => new Parking());
        public static Parking Instance => LazyParking.Value;

        public uint NumberParkingSpaces { get; set; } = Settings.ParkingSpace;
        public List<Car> Cars { get; }
        public List<Transaction> Transactions { get; }
        public decimal Balance { get; set; }

        private Parking()
        {
            Cars = new List<Car>();
            Transactions = new List<Transaction>();
        }

        public void AddCar(Car car)
        {
            try
            {
                if (Cars.Count < NumberParkingSpaces)
                {
                    Cars.Add(car);
                }
                else
                {
                    throw new ParkingSpacesException("Parking is full");
                }
            }
            catch (ParkingSpacesException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public bool RemoveCar(uint carId)
        {
            Car car = Cars.First<Car>(c => c.Id == carId);

            if (car.Balance >= 0)
            {
                Cars.Remove(car);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool IsCarExist(uint carId)
        {
            Car car = Cars.FirstOrDefault<Car>(c => c.Id == carId);
            return car != null;
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        private void IncreaseBalance(decimal value)
        {
            Balance += value;
        }

        private void DecreaseBalance(decimal value)
        {
            Balance -= value;
        }

        //Withdraw Money
        public void WithdrawMoneyForCars(object obj)
        {
            foreach (Car car in Cars)
            {
                decimal sum = Settings.Dictionary[car.Type];

                if (car.Balance > 0 && (car.Balance - sum) > 0)
                {
                    car.DecreaseBalance(sum);
                    IncreaseBalance(sum);
                    AddTransaction(new Transaction(car.Id, sum));
                }
                else
                {
                    sum *= Convert.ToDecimal(Settings.Fine); //todo
                    car.DecreaseBalance(sum);
                }
            }
        }

        //Refill car balance
        public void IncreaseCarBalance(uint carId, decimal sum)
        {
            Car car = Cars.First<Car>(c => c.Id == carId);
            car.IncreaseBalance(sum);
        }

        //Get car balance
        public decimal GetCarBalance(uint carId)
        {
            Car car = Cars.First<Car>(c => c.Id == carId);
            return car.Balance;
        }

        //The number of available parking spaces
        public uint GetNumberAvailableParkingSpaces()
        {
            return Convert.ToUInt32(NumberParkingSpaces - Cars.Count);
        }

        //The number of busy parking spaces
        public uint GetNumberBusyParkingSpaces()
        {
            return Convert.ToUInt32(Cars.Count);
        }

        //Transaction history
        public IEnumerable<Transaction> GetLastTransactions(int minutes)
        {
            if (minutes == 0)
            {
                return Transactions;
            }
            else
            {
                TimeSpan interval = new TimeSpan(0, minutes, 0);
                var lastTransactions = Transactions.Where<Transaction>(t => DateTime.Now - t.Time < interval);

                return lastTransactions;
            }
        }

        //The amount of earned money
        public decimal GetEarnedMoney(int minutes = 0)
        {
            IEnumerable <Transaction> lastTransactions = GetLastTransactions(minutes);

            decimal sum = 0;
            foreach (Transaction transaction in lastTransactions)
            {
                sum += transaction.WithdrawMoney;
            }

            return sum;
        }
    }
}
