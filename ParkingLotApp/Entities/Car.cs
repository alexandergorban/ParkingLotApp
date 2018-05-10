using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Entities
{
    class Car
    {
        public uint Id { get; set; }
        public float Balance { get; set; }
        public CarType Type { get; set; }
    }
}
