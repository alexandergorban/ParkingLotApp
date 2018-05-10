using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Entities
{
    class Parking
    {
        public uint NumberParkingSpaces { get; set; } = 100;
        public List<Car> Cars { get; }
        public List<Transaction> Transactions { get; }
        public decimal Balance { get; set; }

        private static Parking parking;
        private Parking()
        {
            Cars = new List<Car>();
            Transactions = new List<Transaction>();
        }

        public static Parking Instance
        {
            get
            {
                if (parking == null)
                {
                    parking = new Parking();
                }

                return parking;
            }
        }

        public void AddCar(Car car)
        {
            if (Cars.Count < NumberParkingSpaces)
            {
                Cars.Add(car);
            }
            else
            {
                throw new Exception(); // todo
            }
        }

        public void RemoveCar(uint carId)
        {
            Car car = Cars.First<Car>(c => c.Id == carId);
            Cars.Remove(car);
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }

        public void IncreaseBalance(decimal value)
        {
            Balance += value;
        }

        public void DecreaseBalance(decimal value)
        {
            Balance -= value;
        }

        //Withdraw Money
        public void WithdrawMoneyForCars(object obj)
        {
            foreach (Car car in Cars)
            {
                decimal sum = Settings.Dictionary[car.Type];

                if ((car.Balance - sum) > 0)
                {
                    car.DecreaseBalance(sum);
                    parking.IncreaseBalance(sum);
                    parking.AddTransaction(new Transaction(car.Id, sum));
                }
                else
                {
                    sum *= Convert.ToDecimal(Settings.Fine); //todo
                }
            }
        }

        //The number of available parking spaces
        public uint AvailableParkingSpaces()
        {
            return Convert.ToUInt32(NumberParkingSpaces - Cars.Count);
        }
    }
}
