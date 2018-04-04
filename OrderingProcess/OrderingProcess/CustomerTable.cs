using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrderingProcess
{
    public class CustomerTable
    {
        int tableNumber;
        int currentCount;
        int capacity;
        String state;

        //add list for orders


        public CustomerTable()
        {
            this.currentCount = 0;
            this.capacity = 10;
            this.tableNumber = 0;
            this.state = "Empty";
        }

        public CustomerTable(String newState, int newTableNum, int newCurrentCount, int newCapacity)
        {
            this.currentCount = newCurrentCount;
            this.capacity = newCapacity;
            this.tableNumber = newTableNum;
            this.state = newState;
        }


        //Set and get methods for instance variables 

        public void setTableNumber(int newTableNumber)
        {
            this.tableNumber = newTableNumber;
        }

        public int getTableNumber()
        {
            return this.tableNumber;
        }


        public void setCurrentCount(int newCurrentCount)
        {
            if (newCurrentCount <= capacity)
            {
                this.currentCount = newCurrentCount;
            }
            else
            {
                MessageBox.Show("Table count must be less or equal to capacity");
            }
        }

        public int getCurrentCount()
        {
            return this.currentCount;
        }


        public void setCapacity(int newCapacity)
        {
            this.capacity = newCapacity;
        }

        public int getCapacity()
        {
            return this.capacity;
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
