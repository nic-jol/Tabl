using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Timers;
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
    /// Interaction logic for OneBill.xaml
    /// </summary>
    public partial class OneBill : Window
    {
        int index;
        List<Timer> TimerList;

        public OneBill(int newIndex)
        {
            InitializeComponent();
            this.index = newIndex;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            PaymentGrid.Visibility = Visibility.Hidden;
            int tableNum = MainWindow.tables[index].getTableNumber();
            TableTitle.Text = "Table " + tableNum + " Total:";

            TimerList = new List<Timer>();
            Timer timer1 = new Timer();
            Timer timer2 = new Timer();
            TimerList.Add(timer1);
            TimerList.Add(timer2);
        }

        private void showPayment(object sender, RoutedEventArgs e)
        {
            PaymentGrid.Visibility = Visibility.Visible;
            TimerList[0].Elapsed += new ElapsedEventHandler(FirstTimedEvent);
            TimerList[0].Interval = 3000;
            TimerList[0].Start();
        }

        private void FirstTimedEvent(object source, ElapsedEventArgs e)
        {
            TimerList[0].Stop();
            this.Dispatcher.Invoke(() =>
            {
                PaymentStatus.Text = "Payment Complete!";
                PaymentCancel.Visibility = Visibility.Hidden;
                //this.Close();
            });
            
            TimerList[1].Elapsed += new ElapsedEventHandler(SecondTimedEvent);
            TimerList[1].Interval = 1000;
            TimerList[1].Start();
        }

        private void SecondTimedEvent(object source, ElapsedEventArgs e)
        {
            TimerList[1].Stop();
            this.Dispatcher.Invoke(() =>
            {
                PaymentGrid.Visibility = Visibility.Hidden;
                PaymentCancel.Visibility = Visibility.Visible;
                PaymentStatus.Text = "Payment Processing";
                this.Close();
            });
        }

        private void cancelPayment(object sender, RoutedEventArgs e)
        {
            TimerList[0].Stop();
            TimerList[1].Stop();
            PaymentGrid.Visibility = Visibility.Hidden;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewFullBill(object sender, RoutedEventArgs e)
        {
            ViewOrderGrid.Visibility = Visibility.Visible;

            ItemsUniGrid.Children.Clear();

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
                    ItemsUniGrid.Children.Add(itemDisplay);
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
        }

        private void backPaymenetBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewOrderGrid.Visibility = Visibility.Hidden;
        }
    }
}
