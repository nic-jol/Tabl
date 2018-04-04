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
    public partial class UnassignTable : Window
    {
        int index;
        TableOIcon tableIcon;

        public UnassignTable()
        {
            InitializeComponent();
        }
        public UnassignTable(int newIndex, TableOIcon newTableIcon)
        {
            InitializeComponent();
            index = newIndex;
            tableIcon = newTableIcon;

        }

        private void buttonOkClick(object sender, RoutedEventArgs e)
        {

            //code for updating
            MainWindow.tables[index].setState("Empty");
            MainWindow.tables[index].setCurrentCount(0);
            tableIcon.updateFormWithTable();
            this.Close();
        }

        private void buttonCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
