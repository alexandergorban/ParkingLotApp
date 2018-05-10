using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Entities
{
    class Parking
    {
        public List<Car> Cars { get; }
        public List<Transaction> Transactions { get; }
        public decimal Balance { get; set; }

        private static Parking instance;
        private Parking()
        {
            Cars = new List<Car>();
            Transactions = new List<Transaction>();
        }

        public static Parking Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Parking();
                }

                return instance;
            }
        }

        public void AddCar(Car car)
        {
            if (Cars.Count < 100) // todo
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
    }
}
