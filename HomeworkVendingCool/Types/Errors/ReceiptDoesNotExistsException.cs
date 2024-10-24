using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types.Errors
{
    class ReceiptDoesNotExistsException : Exception
    {
        public ReceiptDoesNotExistsException(string? message) : base(message)
        {
        }

        public override string Message => base.Message;

        //public ReceiptDoesNotExistsException(string message)
        //{
        //    Message = message;
        //}

    }
}
