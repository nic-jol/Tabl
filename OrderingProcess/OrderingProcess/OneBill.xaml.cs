using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
    /// Interaction logic for OneBill.xaml
    /// </summary>
    public partial class OneBill : Window
    {
        int index;
        List<Timer> TimerList;

        public OneBill(int newIndex)
        {
            InitializeComponent();
            PaymentGrid.Visibility = Visibility.Hidden;
            this.index = newIndex;

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
    }
}
