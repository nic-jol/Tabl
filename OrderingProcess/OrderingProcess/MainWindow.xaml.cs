using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Forms;

namespace OrderingProcess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        public static CustomerTable[] tables = new CustomerTable[4];
        public TableOIcon curTable;
        private String foodName;  // For transfering food name to side function
        private String sideName;
        private int itemSize;
        private int seatOrder = -1;   // Keep track of what seat and order is for
        public static char userType = 'n';

        public MainWindow()
        {
            InitializeComponent();

            // *** Determines if manager tabs or server tabs displayed depending on static variable userType ***
            if (userType == 'm')
            {
                tabControl.Visibility = Visibility.Hidden;
                ServerName.Text = "Mike";

                ServerPic.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Mike.jpg"))
                };
            }
            else
            {
                tabControl_Manager.Visibility = Visibility.Hidden;
            }
                

            InfoGrid.Visibility = Visibility.Hidden;
            OrderHistoryGrid.Visibility = Visibility.Hidden;
            SeatsGrid.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;
            ReserveClickGrid.Visibility = Visibility.Hidden;
            FullClickGrid.Visibility = Visibility.Hidden;
            PickUpGrid.Visibility = Visibility.Hidden;
            UnassignGrid.Visibility = Visibility.Hidden;
            AssignGrid.Visibility = Visibility.Hidden;
            helpOrderingMsg.Visibility = Visibility.Hidden;


            // Hide parts of Header
            backArrow.Visibility = Visibility.Hidden;
            backToTables.Visibility = Visibility.Hidden;
            InfoButton.Visibility = Visibility.Hidden;
            LogoutButton.Visibility = Visibility.Hidden;

            //  // Dropdown menu controls
            ServerInfoGrid.MouseDown += new MouseButtonEventHandler(menuAppear);
            tabControl.MouseDown += new MouseButtonEventHandler(menu_ClickAway);
            tabControl_Manager.MouseDown += new MouseButtonEventHandler(menu_ClickAway);
            ToSeeOrderHistory.MouseDown += new MouseButtonEventHandler(orderHistory_Click);
            LogoutButton.Click += logout_Click;
            InfoButton.Click += info_Click;
            InfoClose.Click += info_Close;

            //###TABLES###//
            //String newState, int newTableNum, int newCurrentCount, int newCapacity
            tables[0] = new CustomerTable("Empty", 20, 0, 4);
            tables[1] = new CustomerTable("Reserved", 21, 0, 4);
            tables[2] = new CustomerTable("Full", 22, 2, 4);
            tables[3] = new CustomerTable("Pick Up", 23, 4, 4);

            Table0_O.updateIndex(0);
            Table0_O.MouseDown += new MouseButtonEventHandler(tableClick);
            Table0_O.setPayTableReference(Table0_P);
            Table0_P.updateIndex(0);

            Table1_O.updateIndex(1);
            Table1_O.MouseDown += new MouseButtonEventHandler(tableClick);
            Table1_O.setPayTableReference(Table1_P);
            Table1_P.updateIndex(1);

            Table2_O.updateIndex(2);
            Table2_O.MouseDown += new MouseButtonEventHandler(tableClick);
            Table2_O.setPayTableReference(Table2_P);
            Table2_P.updateIndex(2);

            Table3_O.updateIndex(3);
            Table3_O.MouseDown += new MouseButtonEventHandler(tableClick);
            Table3_O.setPayTableReference(Table3_P);
            Table3_P.updateIndex(3);

            //manager tables
            Table0_O1.updateIndex(0);
            Table0_O1.MouseDown += new MouseButtonEventHandler(tableClick);
            Table0_O1.setPayTableReference(Table0_P);
            Table0_P1.updateIndex(0);
            
            Table1_O1.updateIndex(1);
            Table1_O1.MouseDown += new MouseButtonEventHandler(tableClick);
            Table1_O1.setPayTableReference(Table1_P);
            Table1_P1.updateIndex(1);
            
            Table2_O1.updateIndex(2);
            Table2_O1.MouseDown += new MouseButtonEventHandler(tableClick);
            Table2_O1.setPayTableReference(Table2_P);
            Table2_P1.updateIndex(2);
            
            Table3_O1.updateIndex(3);
            Table3_O1.MouseDown += new MouseButtonEventHandler(tableClick);
            Table3_O1.setPayTableReference(Table3_P);
            Table3_P1.updateIndex(3);

            // Selecting a category
            foodButton.Click += foodButton_Click;
            drinkButton.Click += drinkButton_Click;

            // Make food text boxes drag and drop
            rotiText.MouseMove += food_MouseMove;
            tunaText.MouseMove += food_MouseMove;
            steakText.MouseMove += food_MouseMove;
            pizzaText.MouseMove += food_MouseMove;
            burgerText.MouseMove += food_MouseMove;
            cancelFButton.Click += orderFull_Click;


            // Add side
            regFriesButton.Click += sideAddedButton_Click;
            yamFriesButton.Click += sideAddedButton_Click;
            gardenButton.Click += sideAddedButton_Click;
            caesarButton.Click += sideAddedButton_Click;

            closeSidesButton.Click += closeSides_Click;

            // Make drink text boxes drag and drop
            cokeText.MouseMove += food_MouseMove;
            orangeText.MouseMove += food_MouseMove;
            spriteText.MouseMove += food_MouseMove;
            milkText.MouseMove += food_MouseMove;
            coffeeText.MouseMove += food_MouseMove;
            cancelDButton.Click += orderFull_Click;

            KitchenButton.Click += viewOrder_Click;   // from order screen
            kitchenButton.Click += orderSent_Click;   // from kitchen screen
            moreItemsButton.Click += backToMain_Click;

            // Confirmation Buttons
            yesButton.Click += addItem_Click;
            noButton.Click += closeSides_Click;

            backArrow.MouseDown += new MouseButtonEventHandler(goBack);
            OrderSentGrid.MouseDown += new MouseButtonEventHandler(goBack);
            helpOrderingMsg.MouseDown += new MouseButtonEventHandler(closeHelp);
        }
        
        //This function decides which method to call depending on the state of the table objects state
        private void tableClick(object sender, MouseButtonEventArgs e)
        {
            if (tables[(((TableOIcon)sender).getIndex())].getState() == "Empty")
            {
                curTable = (TableOIcon)sender;
                AssignGrid.Visibility = Visibility.Visible;
                sliderMin.Text = "" + slider.Minimum;
                sliderMax.Text = "" + slider.Maximum;
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
                fullTitle.Text = "Full: Table " + tables[(((TableOIcon)sender).getIndex())].getTableNumber();

                // Button click functions
                curTable = (TableOIcon)sender;   // use this as index in assign and unassign
                orderButtonF.Click += orderFull_Click;
                unassignButtonF.Click += unassignFull_Click;
                cancelButtonF.Click += hide_fullOptions;

                
            }
            else if (tables[(((TableOIcon)sender).getIndex())].getState() == "Pick Up")
            {
                PickUpGrid.Visibility = Visibility.Visible;
                curTable = (TableOIcon)sender;
            }
            ((TableOIcon)sender).updateFormWithTable();
        }


        //###Reserved Table Functions###//    
        private void assignRes_Click(object sender, RoutedEventArgs e)
        {
            //TODO: pass curTable (see Unassign below)
            AssignGrid.Visibility = Visibility.Visible;
            sliderMin.Text = "" + slider.Minimum;
            sliderMax.Text = "" + slider.Maximum;

            ReserveClickGrid.Visibility = Visibility.Hidden;
        }
        private void unassignRes_Click(object sender, RoutedEventArgs e)
        {
            UnassignGrid.Visibility = Visibility.Visible;
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
            tabControl_Manager.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Visible;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;
            FullClickGrid.Visibility = Visibility.Hidden;

            // Show parts of Header
            backArrow.Visibility = Visibility.Visible;
            backToTables.Visibility = Visibility.Visible;

            //Show Table Number
            tableNumTitle.Text = "Table " + tables[curTable.getIndex()].getTableNumber();

            // Allow ordering for any seat again
            seatOrder = -1;

            // Setup Back Arrow
            SeatButtonsGrid.Children.Clear();

            // Display Correct number of seats
            int curCount = MainWindow.tables[curTable.getIndex()].getCurrentCount();
            int seatCount = 1;

            // Loop through and create an item for each seat
            for (int i = 0; i < curCount; ++i)
            {
                Button button = new Button();
                button.Content = "Seat " + seatCount;
                button.Name = "Seat" + seatCount;   //Use later for ordering
                //button.Click += seatButton_Click;
                RadialGradientBrush radialGradient = new RadialGradientBrush();
                radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(36, 51, 48), 1.0));
                radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(76, 88, 86), 0.0));
                
                button.AllowDrop = true;
                button.Drop += item_Drop;
                button.DragEnter += item_DragEnter;


                button.Background = radialGradient;
                button.Foreground = new SolidColorBrush(Color.FromRgb(239, 244, 239));
                button.FontSize = 36;
                button.BorderThickness = new Thickness(0);
                button.Margin = new Thickness(2);

                SeatButtonsGrid.Children.Add(button);

                ++seatCount;
            }
        }
        private void unassignFull_Click(object sender, RoutedEventArgs e)
        {
            UnassignGrid.Visibility = Visibility.Visible;

            FullClickGrid.Visibility = Visibility.Hidden;
        }
        private void hide_fullOptions(object sender, RoutedEventArgs e)
        {
            FullClickGrid.Visibility = Visibility.Hidden;
        }

        

        //#### Ordering Process ####//
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

        private void addFood_Click(object sender, RoutedEventArgs e)
        {
            foodName = ((Button)sender).Content.ToString();
            itemSize = -1;

            SidesGrid.Visibility = Visibility.Visible;
        }

        private void sideAddedButton_Click(object sender, RoutedEventArgs e)
        {
            // Create Menu Item for that seat
            sideName = ((Button)sender).Content.ToString();
            
            SidesGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Visible;
        }

        private void addDrink_Click(object sender, RoutedEventArgs e)
        {
            foodName = ((Button)sender).Content.ToString();
            sideName = null;
            itemSize = -1;

            SidesGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Visible;
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            // Create Menu Item for that seat
            MenuItem orderItem = new MenuItem(foodName, itemSize, sideName);

            // Add to appropriate list in tables array
            tables[curTable.getIndex()].setSeatOrder(seatOrder, orderItem);

            //Change button color back
            RadialGradientBrush radialGradient = new RadialGradientBrush();
            radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(36, 51, 48), 1.0));
            radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(76, 88, 86), 0.0));
            
            foreach (Button child in SeatButtonsGrid.Children)
            {
                if (child.Name.Equals("Seat"+seatOrder))
                {
                    child.Background = radialGradient;
                }
            }

            // Reset seat variable
            seatOrder = -1;
            
            ConfirmationGrid.Visibility = Visibility.Hidden;
        }

        private void closeSides_Click(object sender, RoutedEventArgs e)
        {
            ConfirmationGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
        }

        private void viewOrder_Click(object e, RoutedEventArgs a)
        {
            OrderScrollerGrid.Children.Clear();

            // Change seat color back
            RadialGradientBrush radialGradient = new RadialGradientBrush();
            radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(36, 51, 48), 1.0));
            radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(76, 88, 86), 0.0));

            foreach (Button child in SeatButtonsGrid.Children)
            {
                if (child.Name.Equals("Seat" + seatOrder))
                {
                    child.Background = radialGradient;
                }
            }

            // Reset seat variable
            seatOrder = -1;

            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Visible;
            ConfirmationGrid.Visibility = Visibility.Hidden;

            // Loop through each seat and add to uniform grid
            int numSeats = tables[curTable.getIndex()].getCurrentCount();
            for (int i=0; i<numSeats; ++i)
            {
                // Create new menu for seat
                SeatMenuDisplayControl seat = new SeatMenuDisplayControl();
                seat.seatLabel.Text = "Seat " + (i + 1);

                int itemCount = 0;   // count how many items were ordered for that seat

                // Loop through each menu item for that seat and add to its uniform grid
                List<MenuItem>[] orderForAll = tables[curTable.getIndex()].getSeatOrder();
                List<MenuItem > orderForSeat = orderForAll[i];
                errors.Text = "" + orderForSeat.Count;
                foreach (MenuItem item in orderForSeat)
                {
                    // change title
                    MenuItemWithDelete itemDisplay = new MenuItemWithDelete();
                    
                    string title = item.getName();

                    if (item.getSide() != null)
                    {
                        title += "\n    " + item.getSide();
                    }

                    itemDisplay.itemName.Text = title;
                    
                    // Add each item to uniform grid
                    seat.orderItemsGrid.Children.Add(itemDisplay);

                    ++itemCount;
                }

                // Adjust height based on number of items
                seat.Height = 90+70 * itemCount;

                if( ( (90 + 70 * itemCount) * (Math.Ceiling(((double)numSeats)/2))) > OrderScrollerGrid.Height)
                {
                    OrderScrollerGrid.Height = (90 + 70 * itemCount) * (Math.Ceiling(((double)numSeats) / 2));
                }

                // Actually add to uniform grid
                OrderScrollerGrid.Children.Add(seat);
            }
        }

        // TODO: ordering after this? 
        private void orderSent_Click(object sender, RoutedEventArgs e)
        {
            SeatsGrid.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Visible;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;
        }

        private void backToMain_Click(object e, RoutedEventArgs a)
        {
            SeatsGrid.Visibility = Visibility.Visible;
            CategoriesGrid.Visibility = Visibility.Visible;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;
        }

        private void goBack(object e, MouseButtonEventArgs a)
        {
            seatOrder = -1;
            List<Button> remove = new List<Button>();
            foreach (var children in SeatButtonsGrid.Children)
            {
                if ((children.GetType() == typeof(Button)))
                {
                    remove.Add(children as Button);
                }
            }
            foreach (var ch in remove)
            {
                SeatButtonsGrid.Children.Remove(ch as Button);
            }

            if (userType == 'm')
            {
                tabControl_Manager.Visibility = Visibility.Visible;
            }
            else
            {
                tabControl.Visibility = Visibility.Visible;
            }
            
            SeatsGrid.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;

            // Hide parts of Header
            backArrow.Visibility = Visibility.Hidden;
            backToTables.Visibility = Visibility.Hidden;
        }

        //#### Logout Controls ####//
        private void menuAppear(object sender, MouseButtonEventArgs e)
        {
            if (LogoutButton.Visibility == Visibility.Hidden)
            {
                LogoutButton.Visibility = Visibility.Visible;
                InfoButton.Visibility = Visibility.Visible;
            }
            else
            {
                LogoutButton.Visibility = Visibility.Hidden;
                InfoButton.Visibility = Visibility.Hidden;
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            InfoGrid.Visibility = Visibility.Visible;
        }

        private void info_Close(object sender, RoutedEventArgs e)
        {
            InfoGrid.Visibility = Visibility.Hidden;
        }

        private void menu_ClickAway(object sender, RoutedEventArgs e)
        {
            if (LogoutButton.Visibility == Visibility.Visible)
            {
                LogoutButton.Visibility = Visibility.Hidden;
                InfoButton.Visibility = Visibility.Hidden;
            }
                
        }

        //#### Pick Up Order PopUP ####//
        private void buttonOkClick(object sender, RoutedEventArgs e)
        {
            tables[curTable.getIndex()].setState("Full");
            curTable.updateFormWithTable();
            curTable.getPayTableReference().updateFormWithTable();

            PickUpGrid.Visibility = Visibility.Hidden;
        }

        private void buttonCancelClick(object sender, RoutedEventArgs e)
        {
            PickUpGrid.Visibility = Visibility.Hidden;
        }

        //#### Unassign PopUP ####//
        private void okUnassignClick(object sender, RoutedEventArgs e)
        {
            //code for updating
            tables[curTable.getIndex()].setState("Empty");
            tables[curTable.getIndex()].setCurrentCount(0);
            curTable.updateFormWithTable();
            curTable.getPayTableReference().updateFormWithTable();

            // TODO: clear previous orders

            UnassignGrid.Visibility = Visibility.Hidden;
        }

        private void cancelUnassignClick(object sender, RoutedEventArgs e)
        {
            UnassignGrid.Visibility = Visibility.Hidden;
        }

        //#### Assign Popup ####//
        // For slider - updates number display on popup when slider changes
        private void updateCount(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider != null && selectedCount != null)  // they are both null when window opens
            {
                selectedCount.Text = slider.Value.ToString();
            }
        }
        private void okAssignClick(object sender, RoutedEventArgs e)
        {
            //code for updating
            tables[curTable.getIndex()].setState("Full");
            tables[curTable.getIndex()].setCurrentCount((int)slider.Value);
            curTable.updateFormWithTable();
            curTable.getPayTableReference().updateFormWithTable();

            AssignGrid.Visibility = Visibility.Hidden;
        }

        private void cancelAssignClick(object sender, RoutedEventArgs e)
        {
            AssignGrid.Visibility = Visibility.Hidden;
        }


        // Help Message
        private void helpOrdering_Click(object sender, RoutedEventArgs e)
        {
            helpOrderingMsg.Visibility = Visibility.Visible;
        }

        private void closeHelp(object sender, MouseButtonEventArgs e)
        {
            helpOrderingMsg.Visibility = Visibility.Hidden;
        }


        // Order History
        private void orderHistory_Click(object sender, MouseButtonEventArgs e)
        {
            //InfoGrid.Visibility = Visibility.Hidden;
            OrderHistoryGrid.Visibility = Visibility.Visible;
            
            AllOrderGrid.Children.Clear(); // Clear before adding more
            foreach (CustomerTable table in tables)
            {
                // Loop through each seat
                for (int i=0; i<table.getCurrentCount(); ++i)
                {
                    // Loop through all orders for a seat
                    foreach (MenuItem item in table.getSeatOrder()[i])
                    {
                        TextBox entry = new TextBox();

                        entry.Text = item.getName();

                        if (item.getName().Length > 8)
                        {
                            entry.Text += "\t";
                        }
                        else
                        {
                            entry.Text += "\t\t";
                        }

                        entry.Text += table.getTableNumber() + "\t\t" + item.getStatus();

                        entry.FontSize = 18;

                        entry.Background = new SolidColorBrush(Color.FromRgb(11, 11, 11));
                        entry.Foreground = new SolidColorBrush(Color.FromRgb(239, 244, 239));
                        entry.BorderBrush = new SolidColorBrush(Color.FromRgb(11, 11, 11));

                        AllOrderGrid.Children.Add(entry);
                    }
                }
            }
        }

        private void closeOrderHistory_Click(object sender, RoutedEventArgs e)
        {
            OrderHistoryGrid.Visibility = Visibility.Hidden;
        }


        


        //#### Drag and Drop ####//
        // Idea: drag food item over to seat; once over seat, side option will popup
        // source: https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/drag-and-drop-overview#drag-and-drop-support-in-wpf

        // Sender
        private void food_MouseMove(object sender, MouseEventArgs e)
        {
            TextBlock foodBtn = sender as TextBlock;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject dragData = new DataObject(foodBtn.Text.ToString());

                DragDrop.DoDragDrop(foodBtn,
                                    dragData,
                                    DragDropEffects.Copy);
            }
        }

        // Receiver
        private void item_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

        private void item_Drop(object sender, DragEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    seatOrder = Convert.ToInt32(((Button)sender).Name.Substring(4));

                    foodName = dataString;
                    itemSize = -1;

                    if (MenuItem.isFood(foodName))
                    {
                        // Side menu pop up
                        SidesGrid.Visibility = Visibility.Visible;
                    }
                    else {
                        sideName = null;
                        itemSize = -1;

                        SidesGrid.Visibility = Visibility.Hidden;
                        ConfirmationGrid.Visibility = Visibility.Visible;
                    }
                    
                }
            }
        }
    }
}
