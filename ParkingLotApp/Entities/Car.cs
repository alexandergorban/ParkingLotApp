using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Entities
{
    class Car
    {
        public uint Id { get; private set; }
        public decimal Balance { get; private set; }


        private readonly CarType type;

        public CarType GetType()
        {
            return type;
        }

        public Car(uint id, CarType type, decimal balance = 0)
        {
            Id = id;
            Balance = balance;
            type = type;
        }

        public decimal IncreaseBalance(decimal value)
        {
            Balance += value;
            return Balance;
        }

        public decimal DecreaseBalance(decimal value)
        {
            Balance += value;
            return Balance;
        }
    }
}
