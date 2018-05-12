using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ParkingLotApp.Entities;

namespace ParkingLotApp.Services
{
    class ParkingService
    {
        private Timer _logToFile;
        private Timer _withdrawMoney;

        //Services
        public FileWriter FileWriter { get; private set; }
        public FileReader FileReader { get; private set; }

        public ParkingService()
        {
            FileWriter = new FileWriter();
            FileReader = new FileReader();

            _logToFile = new Timer(new TimerCallback(FileWriter.LogTransactionToFile), null, Settings.intervalForLoggingToFile, Settings.intervalForLoggingToFile);
            _withdrawMoney = new Timer(new TimerCallback(Settings.Parking.WithdrawMoneyForCars), null, Settings.intervalForWithdrawMoney, Settings.intervalForWithdrawMoney);
        }
    }
}
