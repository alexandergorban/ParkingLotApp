using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Entities
{
    class Transaction
    {
        public ulong Id { get; set; }
        public DateTime Time { get; set; }
        public decimal WithdrawMoney { get; set; }
    }
}
