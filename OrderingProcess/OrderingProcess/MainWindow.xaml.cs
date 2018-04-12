using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Forms;

namespace OrderingProcess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml 
    /// </summary>
    public partial class MainWindow : Window
    {
        public static CustomerTable[] tables = new CustomerTable[4];
        public static char userType = 'm';
        public TableOIcon curTable;
        private String foodName;  // For transfering food name to side function
        private String sideName;
        private int itemSize;
        private int seatOrder = -1;   // Keep track of what seat and order is for
        //private 
        
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
                tabControl_Manager.Visibility = Visibility.Hidden;

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
            PickUpGrid.Visibility = Visibility.Hidden;
            UnassignGrid.Visibility = Visibility.Hidden;
            AssignGrid.Visibility = Visibility.Hidden;

            // Hide parts of Header
            backArrow.Visibility = Visibility.Hidden;
            backToTables.Visibility = Visibility.Hidden;
            InfoButton.Visibility = Visibility.Hidden;
            LogoutButton.Visibility = Visibility.Hidden;

            // Logout controls
            ServerInfoGrid.MouseDown += new MouseButtonEventHandler(menuAppear);
            tabControl.MouseDown += new MouseButtonEventHandler(menu_ClickAway);
            tabControl_Manager.MouseDown += new MouseButtonEventHandler(menu_ClickAway);
            LogoutButton.Click += logout_Click;

            //###TABLES###//
            //String newState, int newTableNum, int newCurrentCount, int newCapacity
            tables[0] = new CustomerTable("Empty", 20, 0, 4);
            tables[1] = new CustomerTable("Reserved", 21, 0, 4);
            tables[2] = new CustomerTable("Full", 22, 2, 4);
            tables[3] = new CustomerTable("Pick Up", 23, 4, 4);

            // Server tables
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


            // Manager tables
            Table0_O1.updateIndex(0);
            Table0_O1.MouseDown += new MouseButtonEventHandler(tableClick);
            Table0_P1.updateIndex(0);

            Table1_O1.updateIndex(1);
            Table1_O1.MouseDown += new MouseButtonEventHandler(tableClick);
            Table1_P1.updateIndex(1);

            Table2_O1.updateIndex(2);
            Table2_O1.MouseDown += new MouseButtonEventHandler(tableClick);
            Table2_P1.updateIndex(2);

            Table3_O1.updateIndex(3);
            Table3_O1.MouseDown += new MouseButtonEventHandler(tableClick);
            Table3_P1.updateIndex(3);


            //###SEATS###//
            //Seat1Button.Click += seatButton_Click;
            //Seat2Button.Click += seatButton_Click;
            //Seat3Button.Click += seatButton_Click;
            //Seat4Button.Click += seatButton_Click;

            foodButton.Click += foodButton_Click;
            drinkButton.Click += drinkButton_Click;

            // TODO: Move button clicks to XAML? -> Maybe move all of these things there, even in function
            // Food clicks (maybe add to xaml?)
            rotiButton.Click += addFood_Click;
            tunaButton.Click += addFood_Click;
            steakButton.Click += addFood_Click;
            burgerButton.Click += addFood_Click;
            pizzaButton.Click += addFood_Click;
            cancelFButton.Click += orderFull_Click;

            // These are temporary
            regFriesButton.Click += sideAddedButton_Click;
            yamFriesButton.Click += sideAddedButton_Click;
            gardenButton.Click += sideAddedButton_Click;
            caesarButton.Click += sideAddedButton_Click;
            closeSidesButton.Click += closeSides_Click;

            // These are temporary
            cokeButton.Click += addDrink_Click;
            orangeButton.Click += addDrink_Click;
            spriteButton.Click += addDrink_Click;
            milkButton.Click += addDrink_Click;
            coffeeButton.Click += addDrink_Click;
            cancelDButton.Click += orderFull_Click;

            KitchenButton.Click += viewOrder_Click;   // from order screen
            kitchenButton.Click += orderSent_Click;   // from kitchen screen
            moreItemsButton.Click += backToMain_Click;

            // Confirmation Buttons
            yesButton.Click += addItem_Click;
            noButton.Click += closeSides_Click;

            ItemAddedGrid.MouseDown += new MouseButtonEventHandler(itemAddedMouse);
            backArrow.MouseDown += new MouseButtonEventHandler(goBack);
            OrderSentGrid.MouseDown += new MouseButtonEventHandler(goBack);
        }

        //This function decides which method to call depending on the state of the table objects state
        private void tableClick(object sender, MouseButtonEventArgs e)
        {
            if (tables[(((TableOIcon)sender).getIndex())].getState() == "Empty")
            {
                curTable = (TableOIcon)sender;
                AssignGrid.Visibility = Visibility.Visible;
                // Assign only
                /*
                AssignTable assign = new AssignTable((((TableOIcon)sender).getIndex()), ((TableOIcon)sender));
                assign.Show();
                */
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
                /*
                PickUpOrder pickUp = new PickUpOrder((((TableOIcon)sender).getIndex()));
                pickUp.Show();
                */
            }
            ((TableOIcon)sender).updateFormWithTable();
        }


        //###Reserved Table Functions###//    
        private void assignRes_Click(object sender, RoutedEventArgs e)
        {
            //TODO: pass curTable (see Unassign below)
            AssignGrid.Visibility = Visibility.Visible;

            /*
            AssignTable assign = new AssignTable(curTable.getIndex(), curTable);
            assign.Show();
            */

            ReserveClickGrid.Visibility = Visibility.Hidden;
        }
        private void unassignRes_Click(object sender, RoutedEventArgs e)
        {
            /*
            UnassignTable assign = new UnassignTable(curTable.getIndex(), curTable);
            assign.Show();
            */
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
            //CategoriesGrid.Visibility = Visibility.Visible;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;
            FullClickGrid.Visibility = Visibility.Hidden;

            // Show parts of Header
            backArrow.Visibility = Visibility.Visible;
            backToTables.Visibility = Visibility.Visible;

            //Show Table Number
            tableNumTitle.Text = "Table " + tables[curTable.getIndex()].getTableNumber();

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
                button.Click += seatButton_Click;
                RadialGradientBrush radialGradient = new RadialGradientBrush();
                radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(36, 51, 48), 1.0));
                radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(76, 88, 86), 0.0));
                
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
            /*
            UnassignTable assign = new UnassignTable(curTable.getIndex(), curTable);
            assign.Show();
            */

            FullClickGrid.Visibility = Visibility.Hidden;
        }
        private void hide_fullOptions(object sender, RoutedEventArgs e)
        {
            FullClickGrid.Visibility = Visibility.Hidden;
        }





        //#### Ordering Process ####//
        private void seatButton_Click(object sender, RoutedEventArgs e)
        {
            if (seatOrder == -1)
            {
                CategoriesGrid.Visibility = Visibility.Visible;
                FoodGrid.Visibility = Visibility.Hidden;
                DrinksGrid.Visibility = Visibility.Hidden;
                SidesGrid.Visibility = Visibility.Hidden;
                ItemAddedGrid.Visibility = Visibility.Hidden;
                OrderSentGrid.Visibility = Visibility.Hidden;
                ViewOrderGrid.Visibility = Visibility.Hidden;
                ConfirmationGrid.Visibility = Visibility.Hidden;

                tableNumTitle.Text = "Table " + tables[curTable.getIndex()].getTableNumber();

                // Highlight seat
                ((Button)sender).Background = new SolidColorBrush(Color.FromRgb(181, 255, 240));
                //radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(181, 255, 240), 1.0));
                //radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(181, 255, 240), 0.0));
                
                // Update variable
                seatOrder = Convert.ToInt32(((Button)sender).Name.Substring(4));
            }
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

        private void addFood_Click(object sender, RoutedEventArgs e)
        {
            foodName = ((Button)sender).Content.ToString();
            itemSize = -1;

            SidesGrid.Visibility = Visibility.Visible;
        }

        private void sideAddedButton_Click(object sender, RoutedEventArgs e)
        {
            // Create Menu Item for that seat
            // Might change around with drag
            sideName = ((Button)sender).Content.ToString();

            //MenuItem foodItem = new MenuItem(foodName, itemSize, sideName);

            SidesGrid.Visibility = Visibility.Hidden;
            //ItemAddedGrid.Visibility = Visibility.Visible;
            //CategoriesGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Visible;
            //DrinksGrid.Visibility = Visibility.Hidden;
            //FoodGrid.Visibility = Visibility.Hidden;
        }

        private void addDrink_Click(object sender, RoutedEventArgs e)
        {
            foodName = ((Button)sender).Content.ToString();
            sideName = null;
            itemSize = -1;

            //MenuItem drinkItem = new MenuItem(drinkName, -1, null);

            SidesGrid.Visibility = Visibility.Hidden;
            //ItemAddedGrid.Visibility = Visibility.Visible;
            //CategoriesGrid.Visibility = Visibility.Visible;
            ConfirmationGrid.Visibility = Visibility.Visible;
            //DrinksGrid.Visibility = Visibility.Hidden;
            //FoodGrid.Visibility = Visibility.Hidden;
        }

        private void addItem_Click(object sender, RoutedEventArgs e)
        {
            // Create Menu Item for that seat
            // TODO: Might change around with drag
            MenuItem orderItem = new MenuItem(foodName, itemSize, sideName);

            //errors.Text = "" + foodName + itemSize + sideName;
            //errors.Text = orderItem.ToString();
            //errors.Text = "" + curTable.getIndex();

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

            //SeatsGrid.Children.Count
            //button.Background = radialGradient;

            // Reset seat variable
            seatOrder = -1;

            ConfirmationGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;

            //ToolTip added = new ToolTip();
            //added.Show("Item Added", this, 512, 384, 1000);
            ItemAddedGrid.Visibility = Visibility.Visible;
        }

        private void closeSides_Click(object sender, RoutedEventArgs e)
        {
            ConfirmationGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
        }

        // TODO: timed popup or popup on seat
        private void itemAddedMouse(object e, MouseButtonEventArgs a)
        {
            ItemAddedGrid.Visibility = Visibility.Hidden;
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
            ItemAddedGrid.Visibility = Visibility.Hidden;
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
                    //.Text += "" + item.getName();

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
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Visible;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;
        }

        private void backToMain_Click(object e, RoutedEventArgs a)
        {
            SeatsGrid.Visibility = Visibility.Visible;
            //CategoriesGrid.Visibility = Visibility.Visible;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
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

        private void menu_ClickAway(object sender, RoutedEventArgs e)
        {
            if (LogoutButton.Visibility == Visibility.Visible)
            {
                LogoutButton.Visibility = Visibility.Hidden;
                InfoButton.Visibility = Visibility.Hidden;
            }
        }

    //#### TODO: Pick Up Order PopUP ####//
    private void buttonOkClick(object sender, RoutedEventArgs e)
        {
            PickUpGrid.Visibility = Visibility.Hidden;
        }

        private void buttonCancelClick(object sender, RoutedEventArgs e)
        {
            PickUpGrid.Visibility = Visibility.Hidden;
        }

        //#### TODO: Unassign PopUP ####//
        
        private void okUnassignClick(object sender, RoutedEventArgs e)
        {
            //code for updating
            tables[curTable.getIndex()].setState("Empty");
            tables[curTable.getIndex()].setCurrentCount(0);
            curTable.updateFormWithTable();

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

            AssignGrid.Visibility = Visibility.Hidden;
        }

        private void cancelAssignClick(object sender, RoutedEventArgs e)
        {
            AssignGrid.Visibility = Visibility.Hidden;
        }

        //#### Drag and Drop ####//
        // Idea: drag food item over to seat; once over seat, side option will popup
        // source: https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/drag-and-drop-overview#drag-and-drop-support-in-wpf

        // Sender
        private void item_MouseMove(object sender, MouseEventArgs e)
        {
            Button foodBtn = sender as Button;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject dragData = new DataObject(foodBtn.Content.ToString());

                DragDrop.DoDragDrop(foodBtn,
                                    foodBtn.Content.ToString(),
                                    DragDropEffects.All);
            }
        }

        // Receiver
        private void item_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.All;
            /*
            Button btn = sender as Button;

            if (btn != null)
            {
                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    foodName = dataString;
                    itemSize = -1;
                    // Side menu pop up
                    SidesGrid.Visibility = Visibility.Visible;
                    //private String sideName;
                }
            }
            */
        }

        private void item_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                foodName = dataString;
                itemSize = -1;
                // Side menu pop up
                SidesGrid.Visibility = Visibility.Visible;
                //private String sideName;
            }
        }

        private void item_DragLeave(object sender, DragEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Hide sides grid
                SidesGrid.Visibility = Visibility.Hidden;
            }
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

                    foodName = dataString;
                    itemSize = -1;
                    // Side menu pop up
                    SidesGrid.Visibility = Visibility.Visible;
                    //private String sideName;
                }
            }
        }
    }
}
