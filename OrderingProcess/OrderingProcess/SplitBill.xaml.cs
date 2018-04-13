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
    /// Interaction logic for SplitBill.xaml
    /// </summary>
    /// 
    public partial class SplitBill : Window
    {
        private int index;
        private string splittingItem;
        //private int tableNum;
        //private int curCapacity;

        public SplitBill(int newIndex)
        {
            InitializeComponent();
            if (MainWindow.userType == 'm')
            {
                ServerName.Text = "Mike";
                
                ServerPic.Fill = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"pack://application:,,,/Resources/Mike.jpg"))
                };
            }

            index = newIndex;

            int tableNum = MainWindow.tables[index].getTableNumber();
            int curCount = MainWindow.tables[index].getCurrentCount();

            splitSlider.Maximum = curCount;

            titleText.Text = "Table " + tableNum + " Current Split ";
            multiTitle.Text = "Table " + tableNum + ": Outstanding Bills";

            int seatCount = 1;
            // Loop through and create an item for each
            for (int i=0; i<curCount; ++i)
            {
                OneSeatBill bill = new OneSeatBill();
                bill.seatTitle.Text = "Seat " + seatCount;

                eachSeatGrid.Children.Add(bill);

                // Loop through each menu item for that seat and add to its uniform grid
                List<MenuItem>[] orderForAll = MainWindow.tables[index].getSeatOrder();
                List<MenuItem> orderForSeat = orderForAll[i];
                //errors.Text = "" + orderForSeat.Count;
                foreach (MenuItem item in orderForSeat)
                {
                    // change title
                    TextBlock itemDisplay = new TextBlock();

                    string title = item.getName();

                    if (item.getSide() != null)
                    {
                        title += "\n" + item.getSide();
                    }

                    itemDisplay.Text = title;
                    RadialGradientBrush radialGradient = new RadialGradientBrush();
                    radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(89, 124, 119), 1.0));
                    radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(144, 168, 164), 0.0));

                    itemDisplay.Background = radialGradient;
                    itemDisplay.Foreground = new SolidColorBrush(Color.FromRgb(239, 244, 239));
                    itemDisplay.Height = 70;
                    itemDisplay.Width = 300;
                    itemDisplay.TextAlignment = TextAlignment.Center;
                    itemDisplay.FontSize = 24;

                    // Add each item to uniform grid
                    bill.seatScrollerGrid.Children.Add(itemDisplay);
                    //.Text += "" + item.getName();

                    //++itemCount;
                }

                ++seatCount;
            }

            eachSeatGrid.Height = (int) Math.Ceiling((double) curCount / 2) * 400;

            ChangeSplitGrid.Visibility = Visibility.Hidden;
            SplitSliderGrid.Visibility = Visibility.Hidden;
            SplitWarningGrid.Visibility = Visibility.Hidden;
            MultipleBills.Visibility = Visibility.Hidden;
            InfoButton.Visibility = Visibility.Hidden;
            LogoutButton.Visibility = Visibility.Hidden;
            InfoGrid.Visibility = Visibility.Hidden;
            helpMsg.Visibility = Visibility.Hidden;

            backTables.Visibility = Visibility.Visible;
            backOriginal.Visibility = Visibility.Hidden;

            // Arrows Ready
            backToTableArrow.MouseDown += new MouseButtonEventHandler(backArrowTable);
            backArrowOriginal.MouseDown += new MouseButtonEventHandler(backArrowOriginal_Click);

            //  // Dropdown menu controls
            ServerInfoGrid.MouseDown += new MouseButtonEventHandler(menuAppear);
            MainGrid.MouseDown += new MouseButtonEventHandler(menu_ClickAway);
            LogoutButton.Click += logout_Click;
            InfoButton.Click += info_Click;
            InfoClose.Click += info_Close;
        }

        private void changeSplitScreen(object sender, RoutedEventArgs e)
        {
            ChangeSplitGrid.Visibility = Visibility.Visible;
            AllFourGrid.Visibility = Visibility.Hidden;

            backTables.Visibility = Visibility.Hidden;
            backOriginal.Visibility = Visibility.Visible;

            tableTitle.Text = "Table " + MainWindow.tables[index].getTableNumber();

            // Set up splits
            int seatCount = 0;

            int tableNum = MainWindow.tables[index].getTableNumber();
            int curCount = MainWindow.tables[index].getCurrentCount();

            //TODO: remove this
            //curCount = 2;

            //SplitsGrid.Rows = (int)Math.Ceiling((double)curCount / 2);
            SplitsGrid.Children.Clear();
            // Loop through and create an item for each seat
            for (int i = 0; i < curCount; ++i)
            {
                OneSeatBill bill = new OneSeatBill();
                bill.seatTitle.Text = "" + (seatCount + 1);

                //bill.seatTitle.FontSize = 16;
                //bill.seatTitle.Height = 20;

                bill.AllowDrop = true;
                bill.Drop += text_Drop;
                bill.DragEnter += text_DragEnter;

                SplitsGrid.Children.Add(bill);

                // TODO: Add items on bill to item scroller
                // bill.seatScrollerGrid

                ++seatCount;
            }

            // Loop and add all menu items to top of screen
            ItemsGrid.Children.Clear();
            int numSeats = MainWindow.tables[index].getCurrentCount();
            for (int i = 0; i < numSeats; ++i)
            {
                // Loop through each menu item for that seat and add to its uniform grid
                List<MenuItem>[] orderForAll = MainWindow.tables[index].getSeatOrder();
                List<MenuItem> orderForSeat = orderForAll[i];
                //errors.Text = "" + orderForSeat.Count;
                foreach (MenuItem item in orderForSeat)
                {
                    TextBlock itemDisplay = new TextBlock();

                    string title = item.getName();

                    if (item.getSide() != null)
                    {
                        title += "\n" + item.getSide();
                    }

                    itemDisplay.Text = title;

                    RadialGradientBrush radialGradient = new RadialGradientBrush();
                    radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(89, 124, 119), 1.0));
                    radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(144, 168, 164), 0.0));

                    itemDisplay.Background = radialGradient;
                    itemDisplay.Foreground = new SolidColorBrush(Color.FromRgb(239, 244, 239));
                    itemDisplay.Height = 70;
                    itemDisplay.Width = 300;
                    itemDisplay.TextAlignment = TextAlignment.Center;
                    itemDisplay.FontSize = 24;

                    itemDisplay.MouseMove += text_MouseMove;  // Get drag and drop ready
                    itemDisplay.MouseDown += new MouseButtonEventHandler(itemToSplit_Click);
                    
                    ItemsGrid.Children.Add(itemDisplay);
                }
            }
        }


        private void keepSplitScreen(object sender, RoutedEventArgs e)
        {
            MultipleBills.Visibility = Visibility.Visible;
            AllFourGrid.Visibility = Visibility.Hidden;

            backTables.Visibility = Visibility.Hidden;
            backOriginal.Visibility = Visibility.Visible;

            foreach (OneSeatBill bill in eachSeatGrid.Children)
            {
                // If they actually have items to pay for
                if (bill.seatScrollerGrid.Children.Count > 0)
                {
                    Button payingBill = new Button();

                    payingBill.Content = " " + bill.seatTitle.Text + " Bill          $27.00";

                    payingBill.Width = 800;
                    payingBill.Height = 100;
                    payingBill.FontSize = 48;
                    //payingBill.BorderBrush = new SolidColorBrush(Color.FromRgb(89, 124, 119));
                    //payingBill.Background = new SolidColorBrush(Color.FromRgb(144, 168, 164));

                    RadialGradientBrush radialGradient = new RadialGradientBrush();
                    radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(89, 124, 119), 1.0));
                    radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(144, 168, 164), 0.0));

                    payingBill.Background = radialGradient;
                    payingBill.Foreground = new SolidColorBrush(Color.FromRgb(239, 244, 239));
                    // 89 124 119
                    // 144 168 164

                    // click function- open one bill, delete itself
                    payingBill.Click += payingBill_Click;

                    BillListGrid.Children.Add(payingBill);
                }
            }
        }
        

        private void payingBill_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Visibility = Visibility.Hidden;

            OneBill one = new OneBill(index);
            one.Show();
            //this.Close();
        }

        private void backArrowTable(object e, MouseButtonEventArgs a)
        {
            this.Close();
        }

        private void backArrowOriginal_Click(object e, MouseButtonEventArgs a)
        {
            ChangeSplitGrid.Visibility = Visibility.Hidden;
            AllFourGrid.Visibility = Visibility.Visible;
            MultipleBills.Visibility = Visibility.Hidden;

            backTables.Visibility = Visibility.Visible;
            backOriginal.Visibility = Visibility.Hidden;
        }


        // For slider - updates number display on popup when slider changes
        private void updateCount(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (splitSlider != null && splitCount != null)  // they are both null when window opens
            {
                splitCount.Text = splitSlider.Value.ToString();
            }
        }

        private void text_MouseMove(object sender, MouseEventArgs e)
        {
            TextBlock dragging = sender as TextBlock;
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject dragData = new DataObject(dragging.Text);

                DragDrop.DoDragDrop(dragging,
                                    dragData,
                                    DragDropEffects.Move);
            }
        }

        private void text_Drop(object sender, DragEventArgs e)
        {
            OneSeatBill bill = sender as OneSeatBill;
            if (bill != null)
            {
                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    TextBlock newTB = new TextBlock();

                    newTB.Text = (string)e.Data.GetData(DataFormats.StringFormat);

                    RadialGradientBrush radialGradient = new RadialGradientBrush();
                    radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(89, 124, 119), 1.0));
                    radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(144, 168, 164), 0.0));

                    newTB.Background = radialGradient;
                    newTB.Foreground = new SolidColorBrush(Color.FromRgb(239, 244, 239));
                    newTB.Height = 70;
                    newTB.Width = 300;
                    newTB.TextAlignment = TextAlignment.Center;
                    newTB.FontSize = 24;

                    bill.seatScrollerGrid.Children.Add(newTB);

                    // Remove that text block
                    foreach (TextBlock child in ItemsGrid.Children)
                    {
                        if (child.Text.Equals(newTB.Text))
                        {
                            ItemsGrid.Children.Remove(child);
                            break;
                        }
                    }
                    
                }
            }
        }

        private void text_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
        }

        private void userSplit_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsGrid.Children.Count == 0)
            {
                // Return to main split screen
                ChangeSplitGrid.Visibility = Visibility.Hidden;
                AllFourGrid.Visibility = Visibility.Visible;

                backTables.Visibility = Visibility.Visible;
                backOriginal.Visibility = Visibility.Hidden;

                // Change the lists for each seat
                // Clear it
                eachSeatGrid.Children.Clear();

                int seatCount = 1;

                // Loop through and create an item for each
                foreach (OneSeatBill oldBill in SplitsGrid.Children)
                {
                    // Loop through each menu item for that seat and add to its uniform grid
                    //List<MenuItem>[] orderForAll = MainWindow.tables[index].getSeatOrder();
                    //List<MenuItem> orderForSeat = orderForAll[i];

                    OneSeatBill newBill = new OneSeatBill();
                    newBill.seatTitle.Text = "Seat " + seatCount;

                    eachSeatGrid.Children.Add(newBill);


                    foreach (TextBlock tb in oldBill.seatScrollerGrid.Children)
                    {
                        TextBlock newTB = new TextBlock();

                        newTB.Text = tb.Text;
                        RadialGradientBrush radialGradient = new RadialGradientBrush();
                        radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(89, 124, 119), 1.0));
                        radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(144, 168, 164), 0.0));

                        newTB.Background = radialGradient;
                        newTB.Foreground = new SolidColorBrush(Color.FromRgb(239, 244, 239));
                        newTB.Height = 70;
                        newTB.Width = 300;
                        newTB.TextAlignment = TextAlignment.Center;
                        newTB.FontSize = 24;

                        // Add each item to uniform grid
                        newBill.seatScrollerGrid.Children.Add(newTB);
                    }

                    // then update like before
                    ++seatCount;
                }
            }
            else
            {
                // Show warning
                SplitWarningGrid.Visibility = Visibility.Visible;
            }
        }

        private void splitItemButton_Click(object sender, RoutedEventArgs e)
        {
            // Just close warning box
            SplitWarningGrid.Visibility = Visibility.Hidden;
        }

        private void itemToSplit_Click(object sender, MouseButtonEventArgs e)
        {
            // Double clicks only
            if (e.ClickCount == 2)
            {
                // Show slider for selecting number of splits
                SplitSliderGrid.Visibility = Visibility.Visible;
                sliderMin.Text = "" + splitSlider.Minimum;
                sliderMax.Text = "" + splitSlider.Maximum;

                splittingItem = ((TextBlock)sender).Text;
            }
                
        }

        private void okSplit_Click(object sender, RoutedEventArgs e)
        {
            // Get value from slider
            int numSplits = (int)splitSlider.Value;

            // Make that many copies and place in items grid
            for (int i=0; i<numSplits; ++i)
            {
                TextBlock copy = new TextBlock();

                copy.Text = splittingItem;

                RadialGradientBrush radialGradient = new RadialGradientBrush();
                radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(89, 124, 119), 1.0));
                radialGradient.GradientStops.Add(new GradientStop(Color.FromRgb(144, 168, 164), 0.0));

                copy.Background = radialGradient;
                copy.Foreground = new SolidColorBrush(Color.FromRgb(239, 244, 239));
                copy.Height = 70;
                copy.Width = 300;
                copy.TextAlignment = TextAlignment.Center;
                copy.FontSize = 24;

                copy.MouseMove += text_MouseMove;  // Get drag and drop ready

                ItemsGrid.Children.Add(copy);
            }

            // Delete original (or one of them)
            //TODO: When cost invovled, check price too
            foreach (TextBlock child in ItemsGrid.Children)
            {
                if (child.Text.Equals(splittingItem))
                {
                    ItemsGrid.Children.Remove(child);
                    break;
                }
            }

            // Close slider window
            SplitSliderGrid.Visibility = Visibility.Hidden;
        }

        private void cancelSplit_Click(object sender, RoutedEventArgs e)
        {
            // Just close window with split slider
            SplitSliderGrid.Visibility = Visibility.Hidden;
        }

        private void donePayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //#### Server Info Controls ####//
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

        private void menu_ClickAway(object sender, RoutedEventArgs e)
        {
            if (LogoutButton.Visibility == Visibility.Visible)
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

        // Help button
        private void helpbtn_Click(object sender, RoutedEventArgs e)
        {
            helpMsg.Visibility = Visibility.Visible;
        }

        private void closeHelpMsg(object sender, MouseButtonEventArgs e)
        {
            helpMsg.Visibility = Visibility.Hidden;
        }
    }
}
