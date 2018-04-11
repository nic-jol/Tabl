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
    public partial class TableOIcon : UserControl
    {
        int index;
 
        public TableOIcon()
        {
            InitializeComponent();
        }

        public void updateIndex(int newIndex)
        {
            this.index = newIndex;
            updateFormWithTable();
        }

        public int getIndex()
        {
            return index;
        }

        public void updateFormWithTable()
        {
            if (MainWindow.tables[index].getState() == "Empty")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(153, 153, 153));
            }
            else if (MainWindow.tables[index].getState() == "Reserved")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(45, 71, 90));
            }
            else if (MainWindow.tables[index].getState() == "Pick Up")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(110, 94, 123));
            }
            else if (MainWindow.tables[index].getState() == "Full")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(49, 48, 49));
            }

            tableNum.Text = MainWindow.tables[index].getTableNumber().ToString();
            seatsFilled.Text = MainWindow.tables[index].getCurrentCount().ToString() + "/" + MainWindow.tables[index].getCapacity().ToString();
            tableState.Text = MainWindow.tables[index].getState().ToString();
        }
        /*
        //This function decides which method to call depending on the state of the table objects state
        private void TableClick(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.tables[index].getState() == "Empty")
            {
                emptyClick();
            }
            else if (MainWindow.tables[index].getState() == "Reserved")
            {
                reservedClick();
            }
            
            else if (MainWindow.tables[index].getState() == "Full")
            {
                MainWindow.
            }
            else if (MainWindow.tables[index].getState() == "Ready")
            {
                readyClick();
            }
            updateFormWithTable();
        }

        private void reservedClick()
        {
            UnassignTable assign = new UnassignTable(index, this);
            assign.Show();
        }

        private void emptyClick()
        {
            UnassignTable assign = new UnassignTable(index, this);
            assign.Show();
        }
        private void readyClick()
        {
            PickUpOrder pickUp = new PickUpOrder(index);
            pickUp.Show();
        }
        private void fullClick()
        {
            UnassignTable assign = new UnassignTable(index, this);
            assign.Show();
        }
        */
    }
}
