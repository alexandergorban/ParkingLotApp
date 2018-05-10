using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Entities
{
    class Transaction
    {
        private readonly ulong id;

        public ulong GetId()
        {
            return id;
        }

        private readonly DateTime time;

        public DateTime GetTime()
        {
            return time;
        }

        private readonly uint carId;

        public uint GetCarId()
        {
            return carId;
        }

        private readonly decimal withdrawMoney;

        public decimal GetWithdrawMoney()
        {
            return withdrawMoney;
        }

        public Transaction(ulong id, uint carId, decimal withdrawMoney)
        {
            id = id;
            time = DateTime.Now;
            carId = carId;
            withdrawMoney = withdrawMoney;
        }
    }
}
