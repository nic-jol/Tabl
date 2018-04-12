using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrderingProcess
{
    /// <summary>
    /// Interaction logic for SplitBill.xaml
    /// </summary>
    /// 
    public partial class SplitBill : Window
    {
        private int index;
        //private int tableNum;
        //private int curCapacity;

        public SplitBill(int newIndex)
        {
            InitializeComponent();
            index = newIndex;

            int tableNum = MainWindow.tables[index].getTableNumber();
            int curCount = MainWindow.tables[index].getCurrentCount();

            //TODO: remove this
            //curCount = 6;

            titleText.Text = "Table " + tableNum + " Current Split ";

            int seatCount = 1;
            // Loop through and create an item for each
            for (int i=0; i<curCount; ++i)
            {
                OneSeatBill bill = new OneSeatBill();
                bill.seatTitle.Text = "Seat " + seatCount;

                eachSeatGrid.Children.Add(bill);

                // Loop through each menu item for that seat and add to its uniform grid
                List<MenuItem>[] orderForAll = MainWindow.tables[index].getSeatOrder();
                List<MenuItem> orderForSeat = orderForAll[i];
                //errors.Text = "" + orderForSeat.Count;
                foreach (MenuItem item in orderForSeat)
                {
                    // change title
                    MenuItemWithDelete itemDisplay = new MenuItemWithDelete();

                    string title = item.getName();

                    if (item.getSide() != null)
                    {
                        title += "\n    " + item.getSide();
                    }

                    itemDisplay.itemName.Text = title;

                    // Add each item to uniform grid
                    bill.seatScrollerGrid.Children.Add(itemDisplay);
                    //.Text += "" + item.getName();

                    //++itemCount;
                }

                ++seatCount;
            }

            eachSeatGrid.Height = (int) Math.Ceiling((double) curCount / 2) * 400;

            ChangeSplitGrid.Visibility = Visibility.Hidden;
            backToBills.Visibility = Visibility.Hidden;
            backArrowBills.Visibility = Visibility.Hidden;

            backArrowTable.MouseDown += new MouseButtonEventHandler(backArrowPressed);
        }

        private void changeSplitScreen(object sender, RoutedEventArgs e)
        {
            ChangeSplitGrid.Visibility = Visibility.Visible;
            AllFourGrid.Visibility = Visibility.Hidden;
            backArrowBills.Visibility = Visibility.Visible;
            backArrowTable.Visibility = Visibility.Visible;
            backToBills.Visibility = Visibility.Visible;
            backToTables.Visibility = Visibility.Hidden;

            tableTitle.Text = "Table " + MainWindow.tables[index].getTableNumber();

            // Set up splits
            int seatCount = 0;

            int tableNum = MainWindow.tables[index].getTableNumber();
            int curCount = MainWindow.tables[index].getCurrentCount();

            //TODO: remove this
            //curCount = 2;

            //SplitsGrid.Rows = (int)Math.Ceiling((double)curCount / 2);
            SplitsGrid.Children.Clear();
            // Loop through and create an item for each seat
            for (int i = 0; i < curCount; ++i)
            {
                OneSeatBill bill = new OneSeatBill();
                bill.seatTitle.Text = "" + (seatCount + 1);

                //bill.seatTitle.FontSize = 16;
                //bill.seatTitle.Height = 20;
                

                SplitsGrid.Children.Add(bill);

                // TODO: Add items on bill to item scroller
                // bill.seatScrollerGrid

                ++seatCount;
            }

            // Loop and add all menu items to top of screen
            ItemsGrid.Children.Clear();
            int numSeats = MainWindow.tables[index].getCurrentCount();
            for (int i = 0; i < numSeats; ++i)
            {
                int itemCount = 0;   // count how many items were ordered for that seat

                // Loop through each menu item for that seat and add to its uniform grid
                List<MenuItem>[] orderForAll = MainWindow.tables[index].getSeatOrder();
                List<MenuItem> orderForSeat = orderForAll[i];
                //errors.Text = "" + orderForSeat.Count;
                foreach (MenuItem item in orderForSeat)
                {
                    // change title
                    MenuItemWithDelete itemDisplay = new MenuItemWithDelete();

                    string title = item.getName();

                    if (item.getSide() != null)
                    {
                        title += "\n    " + item.getSide();
                    }

                    itemDisplay.itemName.Text = title;

                    // Add each item to uniform grid
                    ItemsGrid.Children.Add(itemDisplay);
                    //.Text += "" + item.getName();

                    ++itemCount;
                }

                // Adjust height based on number of items
                /*
                seat.Height = 90 + 70 * itemCount;

                if (((90 + 70 * itemCount) * (Math.Ceiling(((double)numSeats) / 2))) > OrderScrollerGrid.Height)
                {
                    OrderScrollerGrid.Height = (90 + 70 * itemCount) * (Math.Ceiling(((double)numSeats) / 2));
                }

                // Actually add to uniform grid
                OrderScrollerGrid.Children.Add(seat);
    */
            }

            backArrowBills.MouseDown += new MouseButtonEventHandler(notChange);
        }


        private void keepSplitScreen(object sender, RoutedEventArgs e)
        {
            OneBill one = new OneBill(index);
            one.Show();
            this.Close();
        }

        private void notChange(object e, MouseButtonEventArgs a)
        {
            ChangeSplitGrid.Visibility = Visibility.Hidden;
            backToBills.Visibility = Visibility.Hidden;
            AllFourGrid.Visibility = Visibility.Visible;
            backArrowBills.Visibility = Visibility.Hidden;
            backArrowTable.Visibility = Visibility.Visible;
            backToTables.Visibility = Visibility.Visible;

            // For each seat, add a split possibility

        }

        private void backArrowPressed(object e, MouseButtonEventArgs a)
        {
            this.Close();
        }

    }
}
