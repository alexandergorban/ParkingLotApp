using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp.Exceptions
{
    [Serializable]
    class EnterDataErrorException : Exception
    {
        public EnterDataErrorException()
        {
        }

        public EnterDataErrorException(string message)
            : base(message)
        {
        }

        public EnterDataErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
