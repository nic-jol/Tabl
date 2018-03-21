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
    public partial class TableOIcon : UserControl
    {
        Table tabl = new Table();

        public TableOIcon()
        {
            InitializeComponent();
        }

        public TableOIcon(Table passedTable)
        {
            InitializeComponent();
            this.tabl = passedTable;
        }

        private void AssignTable(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Assign Table");
        }
    }
}
