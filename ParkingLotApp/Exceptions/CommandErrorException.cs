using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp
{
    [Serializable]
    class CommandErrorException : Exception
    {
        public CommandErrorException()
        {
        }

        public CommandErrorException(string message)
            : base(message)
        {
        }

        public CommandErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
