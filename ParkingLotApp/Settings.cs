using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ParkingLotApp.Entities;

namespace ParkingLotApp
{
    static class Settings
    {
        private static Timer withdrawMoneyInterval;
        private static Timer logToFile;

        public static DateTime Timeout { get; set; }

        //Initialize prices for Parking Lot by Car Type
        public static Dictionary<CarType, decimal> Dictionary { get; set; } = new Dictionary<CarType, decimal>()
        {
            { CarType.Motorcycle, 2 },
            { CarType.Passenger, 5},
            { CarType.Truck, 10},
            { CarType.Bus, 12}
        };

        //Initialize Parking Size
        public static UInt16 ParkingSpace { get; set; } = 100;

        //Coefficient of Penalty
        public static double Fine { get; set; } = 0.20;

        public static Parking Parking { get; set; } = Parking.Instance;

        static Settings()
        {
            
        }
    }
}
