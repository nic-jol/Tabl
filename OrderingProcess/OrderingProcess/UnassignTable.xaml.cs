﻿using System;
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
        CustomerTable tabl;
        public UnassignTable()
        {
            InitializeComponent();
        }
        public UnassignTable(CustomerTable passedTable)
        {
            InitializeComponent();
            tabl = passedTable;

        }

        private void buttonOkClick(object sender, RoutedEventArgs e)
        {
            //tabl.
            this.Close();
        }

        private void buttonCancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
