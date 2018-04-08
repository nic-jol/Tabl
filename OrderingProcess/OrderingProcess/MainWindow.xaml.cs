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
using System.Timers;

namespace OrderingProcess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static CustomerTable[] tables = new CustomerTable[4];
        public TableOIcon curTable;

        public MainWindow()
        {
            InitializeComponent();
            SeatsGrid.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;
            ReserveClickGrid.Visibility = Visibility.Hidden;
            FullClickGrid.Visibility = Visibility.Hidden;

            // Hide parts of Header
            backArrow.Visibility = Visibility.Hidden;
            backToTables.Visibility = Visibility.Hidden;


            //###TABLES###//
            //String newState, int newTableNum, int newCurrentCount, int newCapacity
            tables[0] = new CustomerTable("Empty", 20, 0, 4);
            tables[1] = new CustomerTable("Reserved", 21, 0, 4);
            tables[2] = new CustomerTable("Full", 22, 2, 4);
            tables[3] = new CustomerTable("Ready", 23, 4, 4);
            
            Table0_O.updateIndex(0);
            Table0_O.MouseDown += new MouseButtonEventHandler(tableClick);
            Table0_P.updateIndex(0);

            Table1_O.updateIndex(1);
            Table1_O.MouseDown += new MouseButtonEventHandler(tableClick);
            Table1_P.updateIndex(1);

            Table2_O.updateIndex(2);
            Table2_O.MouseDown += new MouseButtonEventHandler(tableClick);
            Table2_P.updateIndex(2);

            Table3_O.updateIndex(3);
            Table3_O.MouseDown += new MouseButtonEventHandler(tableClick);
            Table3_P.updateIndex(3);
            

            //###SEATS###//
            Seat1Button.Click += seatButton_Click;
            Seat2Button.Click += seatButton_Click;
            Seat3Button.Click += seatButton_Click;
            Seat4Button.Click += seatButton_Click;

            foodButton.Click += foodButton_Click;
            drinkButton.Click += drinkButton_Click;

            // These are temporary
            rotiButton.Click += tempFoodButton_Click;
            tunaButton.Click += tempFoodButton_Click;
            steakButton.Click += tempFoodButton_Click;
            burgerButton.Click += tempFoodButton_Click;
            pizzaButton.Click += tempFoodButton_Click;
            cancelFButton.Click += seatButton_Click;

            // These are temporary
            regFriesButton.Click += tempSideAddedButton_Click;
            yamFriesButton.Click += tempSideAddedButton_Click;
            gardenButton.Click += tempSideAddedButton_Click;
            caesarButton.Click += tempSideAddedButton_Click;
            closeSidesButton.Click += tempCloseSides_Click;

            // These are temporary
            cokeButton.Click += tempSideAddedButton_Click;
            orangeButton.Click += tempSideAddedButton_Click;
            spriteButton.Click += tempSideAddedButton_Click;
            milkButton.Click += tempSideAddedButton_Click;
            coffeeButton.Click += tempSideAddedButton_Click;
            cancelDButton.Click += seatButton_Click;

            KitchenButton.Click += viewOrder_Click;
            kitchenButton.Click += orderSent_Click;
            moreItemsButton.Click += backToMain_Click;

            ItemAddedGrid.MouseDown += new MouseButtonEventHandler(itemAddedMouse);
        }
/*
        private void tableClick(object e, MouseButtonEventArgs a)
        {
            SeatsGrid.Visibility = Visibility.Visible;
            tabControl.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;

            // Show parts of Header
            backArrow.Visibility = Visibility.Visible;
            backToTables.Visibility = Visibility.Visible;

            // Setup Back Arrow
            backArrow.MouseDown += new MouseButtonEventHandler(goBack);
        }
*/
        //This function decides which method to call depending on the state of the table objects state
        private void tableClick(object sender, MouseButtonEventArgs e)
        {
            if (tables[(((TableOIcon)sender).getIndex())].getState() == "Empty")
            {
                // Assign only
                //AssignTable assign = new AssignTable((((TableOIcon)sender).getIndex()), ((TableOIcon)sender));
                AssignTable assign = new AssignTable();
                assign.Show();

                //emptyClick();
            }
            else if (tables[(((TableOIcon)sender).getIndex())].getState() == "Reserved")
            {
                // Assign or Unassign Option popup
                ReserveClickGrid.Visibility = Visibility.Visible;
                // Add in table number to it
                reserveTitle.Text = "Reserved: Table " + tables[(((TableOIcon)sender).getIndex())].getTableNumber();

                // Button click functions
                curTable = (TableOIcon)sender;   // use this as index in assign and unassign
                assignButtonR.Click += assignRes_Click;
                unassignButtonR.Click += unassignRes_Click;
                cancelButtonR.Click += hide_resOptions;
            }

            else if (tables[(((TableOIcon)sender).getIndex())].getState() == "Full")
            {
                // Order or unassign
                FullClickGrid.Visibility = Visibility.Visible;
                // Add table number to it
                reserveTitle.Text = "Full: Table " + tables[(((TableOIcon)sender).getIndex())].getTableNumber();

                // Button click functions
                curTable = (TableOIcon)sender;   // use this as index in assign and unassign
                orderButtonF.Click += orderFull_Click;
                unassignButtonF.Click += unassignFull_Click;
                cancelButtonF.Click += hide_fullOptions;
            }
            else if (tables[(((TableOIcon)sender).getIndex())].getState() == "Ready")
            {
                PickUpOrder pickUp = new PickUpOrder((((TableOIcon)sender).getIndex()));
                pickUp.Show();
            }
            ((TableOIcon)sender).updateFormWithTable();
        }
       
        
        //###Reserved Table Functions###//    
        private void assignRes_Click(object sender, RoutedEventArgs e)
        {
            //TODO: pass curTable (see Unassign below)
            AssignTable assign = new AssignTable();
            assign.Show();

            ReserveClickGrid.Visibility = Visibility.Hidden;
        }
        private void unassignRes_Click(object sender, RoutedEventArgs e)
        {
            UnassignTable assign = new UnassignTable(curTable.getIndex(), curTable);
            assign.Show();

            ReserveClickGrid.Visibility = Visibility.Hidden;
        }
        private void hide_resOptions(object sender, RoutedEventArgs e)
        {
            ReserveClickGrid.Visibility = Visibility.Hidden;
        }

        //###Full Table Functions###//    
        private void orderFull_Click(object sender, RoutedEventArgs e)
        {
            // Show Ordering
            SeatsGrid.Visibility = Visibility.Visible;
            tabControl.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;

            // Show parts of Header
            backArrow.Visibility = Visibility.Visible;
            backToTables.Visibility = Visibility.Visible;

            // Setup Back Arrow
            backArrow.MouseDown += new MouseButtonEventHandler(goBack);

            FullClickGrid.Visibility = Visibility.Hidden;
        }
        private void unassignFull_Click(object sender, RoutedEventArgs e)
        {
            UnassignTable assign = new UnassignTable(curTable.getIndex(), curTable);
            assign.Show();

            FullClickGrid.Visibility = Visibility.Hidden;
        }
        private void hide_fullOptions(object sender, RoutedEventArgs e)
        {
            FullClickGrid.Visibility = Visibility.Hidden;
        }


        private void seatButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesGrid.Visibility = Visibility.Visible;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;
        }

        private void foodButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Visible;
        }

        private void drinkButton_Click(object sender, RoutedEventArgs e)
        {
            CategoriesGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Visible;
        }

        private void tempFoodButton_Click(object sender, RoutedEventArgs e)
        {
            SidesGrid.Visibility = Visibility.Visible;
        }

        private void tempSideAddedButton_Click(object sender, RoutedEventArgs e)
        {
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Visible;
            CategoriesGrid.Visibility = Visibility.Visible;
            DrinksGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
        }
        
        private void tempCloseSides_Click(object sender, RoutedEventArgs e)
        {
            SidesGrid.Visibility = Visibility.Hidden;
        }

        private void itemAddedMouse(object e, MouseButtonEventArgs a)
        {
            ItemAddedGrid.Visibility = Visibility.Hidden;
        }

        private void viewOrder_Click(object e, RoutedEventArgs a)
        {
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Visible;
            ConfirmationGrid.Visibility = Visibility.Hidden;
        }

        private void orderSent_Click (object sender, RoutedEventArgs e)
        {
            SeatsGrid.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Visible;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;

            // Then it will probably go back to table view...
            OrderSentGrid.MouseDown += new MouseButtonEventHandler(goBack);
        }

        private void backToMain_Click(object e, RoutedEventArgs a)
        {
            SeatsGrid.Visibility = Visibility.Visible;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;
        }
        
        private void goBack(object e, MouseButtonEventArgs a)
        {
            tabControl.Visibility = Visibility.Visible;
            SeatsGrid.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;

            // Hide parts of Header
            backArrow.Visibility = Visibility.Hidden;
            backToTables.Visibility = Visibility.Hidden;
        }
    }
}
