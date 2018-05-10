using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLotApp.Entities;

namespace ParkingLotApp
{
    static class Settings
    {
        public static DateTime Timeout { get; set; }
        public static Dictionary<CarType, decimal> Dictionary { get; set; }
        public static UInt16 ParkingSpace { get; set; }
        public static decimal Fine { get; set; }
    }
}
