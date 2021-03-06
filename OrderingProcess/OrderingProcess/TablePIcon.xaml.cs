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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrderingProcess
{
    /// <summary>
    /// Interaction logic for TableIcon.xaml
    /// </summary>
    public partial class TablePIcon : UserControl
    {
        private int index;

        public TablePIcon()
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
                oneBill.Visibility = Visibility.Hidden;
                splitBill.Visibility = Visibility.Hidden;
            }
            else if (MainWindow.tables[index].getState() == "Reserved")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(45, 71, 90));
                oneBill.Visibility = Visibility.Hidden;
                splitBill.Visibility = Visibility.Hidden;
            }
            else if (MainWindow.tables[index].getState() == "Pick Up")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(110, 94, 123));
                oneBill.Visibility = Visibility.Visible;
                splitBill.Visibility = Visibility.Visible;
            }
            else if (MainWindow.tables[index].getState() == "Full")
            {
                tableRectangle.Fill = new SolidColorBrush(Color.FromRgb(49, 48, 49));
                oneBill.Visibility = Visibility.Visible;
                splitBill.Visibility = Visibility.Visible;
            }

            tableNum.Text = MainWindow.tables[index].getTableNumber().ToString();
            tableState.Text = MainWindow.tables[index].getState().ToString();
        }

        private void oneBillProcess(object sender, RoutedEventArgs e)
        {
            // don't split; seat doesn't matter
            OneBill one = new OneBill(index, false, 0);
            one.Show();
           
        }
        private void splitBillProcess(object sender, RoutedEventArgs e)
        {
            SplitBill split = new SplitBill(index);
            split.Show();
        }
    }
}
