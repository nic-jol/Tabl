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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SeatsGrid.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            //OrderSentGrid.Visibility = Visibility.Hidden;
        }
    }
}
