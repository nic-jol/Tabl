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

        //Attributes
        string name;
        int size;
        string side;
        List<string> validMenuItem = new List<string>();
        List<string> validSide = new List<string>();

        public MenuItem()
        {
            name = null;
            size = -1;
            side = null;
            buildValidMenu();
            buildValidSides();
        }

        public MenuItem(string newName)
        {
            if (validMenuItem.Contains(newName))
            {
                name = newName;
            }
            else
            {
                name = null;
            }
            size = -1;
            side = null;
            buildValidMenu();
            buildValidSides();
        }

        public MenuItem(string newName, int newSize, string newSide)
        {
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
    }
}
