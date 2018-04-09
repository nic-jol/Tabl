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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AssignTable : Window
    {
        //CustomerTable tabl = new CustomerTable();
        int index;
        TableOIcon tableIcon;

        public AssignTable()
        {
            InitializeComponent();
        }

        //public AssignTable(CustomerTable passedTable)
        public AssignTable(int newIndex, TableOIcon newTableIcon)
        {
            InitializeComponent();
            //tabl = passedTable;
            index = newIndex;
            tableIcon = newTableIcon;
        }

        private void updateCount(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            selectedCount.Text = slider.Value.ToString();
        }

        private void buttonOkClick(object sender, RoutedEventArgs e)
        {
            MainWindow.tables[index].setState("Full");
            MainWindow.tables[index].setCurrentCount((int)slider.Value);
            tableIcon.updateFormWithTable();
            this.Close();
        }

        private void buttonCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
