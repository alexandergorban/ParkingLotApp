using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Entities
{
    class Transaction
    {
        public DateTime Time { get; private set; }
        public uint CardId { get; private set; }
        public decimal WithdrawMoney { get; private set; }

        public Transaction(uint carId, decimal withdrawMoney)
        {
            Time = DateTime.Now;
            CardId = carId;
            WithdrawMoney = withdrawMoney;
        }

        public override string ToString()
        {
            return "Time: " + Time + " CardId: " + CardId + " Withdraw Money: " + WithdrawMoney;
        }
    }
}
