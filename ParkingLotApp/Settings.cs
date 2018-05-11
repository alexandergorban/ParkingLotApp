using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ParkingLotApp.Entities;
using ParkingLotApp.Services;

namespace ParkingLotApp
{
    static class Settings
    {
        private static uint intervalForLoggingToFile = 60000;
        private static uint intervalForWithdrawMoney = 2000;

        private static Timer logToFile;
        private static Timer withdrawMoney;

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

        //Parking Instance
        public static Parking Parking { get; set; } = Parking.Instance;

        public static FileWriter FileWriter { get; private set; }

        static Settings()
        {
            FileWriter = new FileWriter();
            logToFile = new Timer(new TimerCallback(FileWriter.LogTransactionToFile), null, intervalForLoggingToFile, intervalForLoggingToFile);
            withdrawMoney = new Timer(new TimerCallback(Parking.WithdrawMoneyForCars), null, intervalForWithdrawMoney, intervalForWithdrawMoney);
        }

        public static void DisplayTransactionHistory()
        {

        }
    }
}
