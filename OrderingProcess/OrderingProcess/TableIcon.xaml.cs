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
    public partial class TableIcon : UserControl
    {
        CustomerTable currentTable= new CustomerTable();
 
        public TableIcon()
        {
            InitializeComponent();
        }

        public void updateFormWithTable()
        {
            if (currentTable.getState() == "Empty")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(196, 190, 179));
            }
            else if (currentTable.getState() == "Reserved")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(45, 71, 90));
            }
            else if (currentTable.getState() == "Ready")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(33, 46, 44));
            }
            else if (currentTable.getState() == "Full")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(86, 63, 57));
            }

        }
        public void setTable(String newStatus)
        {
            currentTable.setState(newStatus);
            updateFormWithTable();
        }

        //This function decides which method to call depending on the state of the table objects state
        private void TableClick(object sender, MouseButtonEventArgs e)
        {
            if (currentTable.getState() == "Empty")
            {
                emptyClick();
            }
            else if (currentTable.getState() == "Reserved")
            {
                reservedClick();
            }
            else if (currentTable.getState() == "Full")
            {
                fullClick();
            }
            else if (currentTable.getState() == "Ready")
            {
                readyClick();
            }
            updateFormWithTable();
        }

        private void reservedClick()
        {
            UnassignTable assign = new UnassignTable(currentTable);
            assign.Show();
        }

        private void emptyClick()
        {
            UnassignTable assign = new UnassignTable(currentTable);
            assign.Show();
        }
        private void readyClick()
        {
            PickUpOrder pickUp = new PickUpOrder(currentTable);
            pickUp.Show();
        }
        private void fullClick()
        {
            UnassignTable assign = new UnassignTable(currentTable);
            assign.Show();
        }
    }
}
