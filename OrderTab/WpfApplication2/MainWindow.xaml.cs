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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Table1_O.tableNum.Text = "20";
            Table2_O.tableNum.Text = "21";
            Table3_O.tableNum.Text = "22";
            Table4_O.tableNum.Text = "23";

            Table1_O.seatsFilled.Text = "0/4";
            Table2_O.seatsFilled.Text = "0/4";
            Table3_O.seatsFilled.Text = "0/4";
            Table4_O.seatsFilled.Text = "0/4";
        }
    }
}
