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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderingProcess
{
    /// <summary>
    /// Interaction logic for TableIcon.xaml
    /// </summary>
    public partial class TablePIcon : UserControl
    {
        public TablePIcon()
        {
            InitializeComponent();
        }

        private void oneBillProcess(object sender, RoutedEventArgs e)
        {
            OneBill one = new OneBill();
            one.Show();
           // this.Close();
           
        }
        private void splitBillProcess(object sender, RoutedEventArgs e)
        {
            SplitBill split = new SplitBill();
            split.Show();
            // this.Close();

        }
    }
}
