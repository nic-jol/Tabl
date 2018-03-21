using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    public class CustomerTable
    {
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
