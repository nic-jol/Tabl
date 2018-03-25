using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingProcess
{
    public class CustomerTable
    {
        String tableNumber;
        int currentCount;
        int capacity;
        String status;

        public CustomerTable()
        {
            currentCount = 0;
            capacity = 10;
            status = "Empty";
        }

    }
}
