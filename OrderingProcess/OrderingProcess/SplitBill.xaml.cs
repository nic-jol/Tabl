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
    public partial class SplitBill : Window
    {
        public SplitBill()
        {
            InitializeComponent();
            ChangeSplitGrid.Visibility = Visibility.Hidden;
            backArrow.Visibility = Visibility.Hidden;
        }

        private void changeSplitScreen(object sender, RoutedEventArgs e)
        {
            ChangeSplitGrid.Visibility = Visibility.Visible;
            AllFourGrid.Visibility = Visibility.Hidden;
            backArrow.Visibility = Visibility.Visible;

            backArrow.MouseDown += new MouseButtonEventHandler(notChange);
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
            backArrow.Visibility = Visibility.Hidden;
            AllFourGrid.Visibility = Visibility.Visible;
        }

    }
}
