using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingProcess
{
    public class MenuItem
    {
        public const int menuSize = 10;
        public static Boolean isFood(string itemCheck)
        {
            List<string> foodItems = new List<string>();

            foodItems.Add("Rotisserie Chicken");
            foodItems.Add("Tuna Sandwich");
            foodItems.Add("Steak");
            foodItems.Add("Margherita Pizza");
            foodItems.Add("Classic Burger");

            if (foodItems.Contains(itemCheck))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean isDrink(string itemCheck)
        {
            List<string> drinkItems = new List<string>();
            
            drinkItems.Add("Coke");
            drinkItems.Add("Orange Crush");
            drinkItems.Add("Sprite");
            drinkItems.Add("Milk");
            drinkItems.Add("Coffee");

            if (drinkItems.Contains(itemCheck))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Attributes
        string name;
        int size;
        string side;
        string status;
        List<string> validMenuItem = new List<string>();
        List<string> validSide = new List<string>();
        List<string> validStatus = new List<string>();

        public MenuItem()
        {
            name = null;
            size = -1;
            side = null;
            status = "Incomplete";
            buildValidMenu();
            buildValidSides();
        }

        public MenuItem(string newName)
        {
            //if (validMenuItem.Contains(newName))
            //{
                name = newName;
            //}
//else
            //{
           //     name = null;
            //}
            size = -1;
            side = null;
            status = "Incomplete";
            buildValidMenu();
            buildValidSides();
        }

        public MenuItem(string newName, int newSize, string newSide)
        {
            status = "Incomplete";
            buildValidMenu();
            buildValidSides();
            if (validMenuItem.Contains(newName))
            {
                name = newName;
            }
            else
            {
                name = null;
            }
            
            size = newSize;

            if (validSide.Contains(newSide))
            {
                side = newSide;
            }
            else
            {
                side = null;
            }
        }

        private void buildValidMenu()
        {
            // Food
            validMenuItem.Add("Rotisserie Chicken");
            validMenuItem.Add("Tuna Sandwich");
            validMenuItem.Add("Steak");
            validMenuItem.Add("Margherita Pizza");
            validMenuItem.Add("Classic Burger");

            // Drinks
            validMenuItem.Add("Coke");
            validMenuItem.Add("Orange Crush");
            validMenuItem.Add("Sprite");
            validMenuItem.Add("Milk");
            validMenuItem.Add("Coffee");
        }

        private void buildValidSides()
        {
            validSide.Add("Regular Fries");
            validSide.Add("Sweet Potato Fries");
            validSide.Add("Garden Salad");
            validSide.Add("Caesar Salad");
            validSide.Add(null);
        }

        private void buildValidStatuses()
        {
            validStatus.Add("Complete");
            validStatus.Add("Pickup Ready");
            validStatus.Add("Payment Required");
            validStatus.Add("Incomplete");
        }



        public void setName(string newName)
        {
            if (validMenuItem.Contains(newName))
            {
                name = newName;
            }
        }

        public string getName()
        {
            return name;
        }

        public void setSide(string newSide)
        {
            if (validSide.Contains(newSide))
            {
                side = newSide;
            }
        }

        public string getSide()
        {
            return side;
        }

        public void setSize(int newSize)
        {
            if ((newSize >= 0) && (newSize < 3))
            {
                size = newSize;
            }
        }

        public int getSize()
        {
            return size;
        }

        public int getMenuSize()
        {
            return menuSize;
        }

        public override String ToString()
        {
            return "" + name + side + size;
        }

        public void setStatus(string newStatus)
        {
            if (validStatus.Contains(newStatus))
            {
                status = newStatus;
            }
        }

        public string getStatus()
        {
            return status;
        }
    }
}
