using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkVendingCool.Types
{
    interface IReceipt
    {
        public string? Name { get; }
        public int Price { get; }

        public T ConvertTo<T>()
        {
            return (T)this;
        }
    }
}
