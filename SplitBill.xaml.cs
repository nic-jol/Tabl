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

        public SplitBill()
        {
            InitializeComponent();
            
            ChangeSplitGrid.Visibility = Visibility.Hidden;
            backToBills.Visibility = Visibility.Hidden;
            backArrowBills.Visibility = Visibility.Hidden;

            backArrowTable.MouseDown += new MouseButtonEventHandler(backArrowPressed);
        }

        public SplitBill(int newIndex)
        {
            InitializeComponent();
            index = newIndex;

            int tableNum = MainWindow.tables[index].getTableNumber();
            int curCount = MainWindow.tables[index].getCurrentCount();

            //TODO: remove this
            curCount = 6;

            titleText.Text = "Table " + tableNum + " Current Split ";

            int seatCount = 0;
            // Loop through and create an item for each
            for (int i=0; i<curCount; ++i)
            {
                OneSeatBill bill = new OneSeatBill();
                bill.seatTitle.Text = "Seat " + (seatCount+1);

                eachSeatGrid.Children.Add(bill);

                // TODO: Add items on bill to scroller
                // bill.seatScrollerGrid

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
            curCount = 2;

            SplitsGrid.Rows = (int)Math.Ceiling((double)curCount / 2);

            // Loop through and create an item for each
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

            backArrowBills.MouseDown += new MouseButtonEventHandler(notChange);
        }


        private void keepSplitScreen(object sender, RoutedEventArgs e)
        {
            OneBill one = new OneBill();
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
