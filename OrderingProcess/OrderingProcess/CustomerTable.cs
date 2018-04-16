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
        public const int maxSeats = 4;

        // Attributes
        private int tableNumber;
        private int currentCount;
        private int capacity;
        private String state;
        private List<MenuItem>[] seatOrders;

        //add list for orders


        public CustomerTable()
        {
            this.currentCount = 0;
            this.capacity = maxSeats;
            this.tableNumber = 0;
            this.state = "Empty";
            seatOrders = new List<MenuItem>[maxSeats];

            for (int i=0; i<maxSeats; ++i)
            {
                seatOrders[i] = new List<MenuItem>();
            }
        }

        public CustomerTable(String newState, int newTableNum, int newCurrentCount, int newCapacity)
        {
            this.currentCount = newCurrentCount;
            this.capacity = newCapacity;
            this.tableNumber = newTableNum;
            this.state = newState;
            seatOrders = new List<MenuItem>[maxSeats];

            for (int i = 0; i < maxSeats; ++i)
            {
                seatOrders[i] = new List<MenuItem>();
            }
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
            validStates.Add("Pick Up");

            if (validStates.Contains(newState)){
                this.state = newState;
            }
        }

        public String getState()
        {
            return this.state;
        }

        // Seats numbered 1 to max
        // Specifies a new order for a seat
        public void setSeatOrder (int seatNum, MenuItem newOrder)
        {
            // Check if it's a valid seat first
            if (seatNum<=currentCount)
            {
                seatOrders[seatNum - 1].Add(newOrder);
            }
        }

        public List<MenuItem>[] getSeatOrder()
        {
            return seatOrders;
        }

        // Seat num: 1-4
        public void clearSeatOrder (int seatNum)
        {
            seatOrders[seatNum-1].Clear();
        }
    }
}
