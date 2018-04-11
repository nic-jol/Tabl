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
    /// Interaction logic for OneBill.xaml
    /// </summary>
    public partial class OneBill : Window
    {
        int index;

        public OneBill(int newIndex)
        {
            InitializeComponent();
            this.index = newIndex;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
