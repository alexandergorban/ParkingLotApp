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
        public CarType Type { get; }

        public Car(uint id, CarType type, decimal balance = 0)
        {
            Id = id;
            Balance = balance;
            Type = type;
        }

        public decimal IncreaseBalance(decimal value)
        {
            Balance += value;
            return Balance;
        }

        public decimal DecreaseBalance(decimal value)
        {
            Balance -= value;
            return Balance;
        }
    }
}
