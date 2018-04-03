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
        String state;

        public CustomerTable()
        {
            currentCount = 0;
            capacity = 10;
            state = "Empty";
        }

        public CustomerTable(String state)
        {
            currentCount = 0;
            capacity = 10;
            state = state;
        }

        //Nothing is done if an invalid state is passed
        public void setState(String newState)
        {
            List<string> validStates = new List<string>();
            validStates.Add("Empty");
            validStates.Add("Reserved");
            validStates.Add("Full");
            validStates.Add("Ready");

            if (validStates.Contains(newState)){
                this.state = newState;
            }
        }
        public String getState()
        {
            return this.state;
        }
    }
}
