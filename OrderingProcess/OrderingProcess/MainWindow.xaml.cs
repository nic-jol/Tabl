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
using System.Timers;

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
            //SeatsGrid.Visibility = Visibility.Hidden;
            CategoriesGrid.Visibility = Visibility.Hidden;
            FoodGrid.Visibility = Visibility.Hidden;
            DrinksGrid.Visibility = Visibility.Hidden;
            SidesGrid.Visibility = Visibility.Hidden;
            ItemAddedGrid.Visibility = Visibility.Hidden;
            OrderSentGrid.Visibility = Visibility.Hidden;
            ViewOrderGrid.Visibility = Visibility.Hidden;
            ConfirmationGrid.Visibility = Visibility.Hidden;

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

            // THen it will probably go back to table view...
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
    }
}
