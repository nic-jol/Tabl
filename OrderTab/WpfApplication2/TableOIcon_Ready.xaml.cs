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
    /// Interaction logic for TableIcon.xaml
    /// </summary>
    public partial class TableOIcon_Ready : UserControl
    {
        CustomerTable tabl = new CustomerTable();

        public TableOIcon_Ready()
        {
            InitializeComponent();
        }

        public TableOIcon_Ready(CustomerTable passedTable)
        {
            InitializeComponent();
            tabl = passedTable;
        }

        private void UnnasignTable(object sender, MouseButtonEventArgs e)
        {
            UnassignTable assign = new UnassignTable(tabl);
            assign.Show();
        }

        private void pickUpOrder(object sender, MouseButtonEventArgs e)
        {
            PickUpOrder pickUp = new PickUpOrder();
            pickUp.Show();
        }
    }
}
