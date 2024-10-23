using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types.Errors
{
    class NotEnoughWaterException : Exception
    {
        public double NotEnough { get; private set;  }
        public string? Provider { get; private set; }

        public NotEnoughWaterException(double message, string? provider)
        {
            NotEnough = message;
            Provider = provider;
        }
        public NotEnoughWaterException()
        {
            NotEnough = 0;
            Provider = null;
        }

    }
}
