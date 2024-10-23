using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types.Errors
{
    class NotEnoughMilkException : Exception
    {
        public double NotEnough { get; private set;  }
        public string? Provider { get; private set; }

        public NotEnoughMilkException(double message, string? provider)
        {
            NotEnough = message;
            Provider = provider;
        }
        public NotEnoughMilkException()
        {
            NotEnough = 0;
            Provider = null;
        }

    }
}
