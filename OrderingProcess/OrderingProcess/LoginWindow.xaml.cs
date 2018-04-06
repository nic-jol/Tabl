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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void checkCredentials(object sender, RoutedEventArgs e)
        {
            if (MockSecurity.canLogin(AddressBox.Text, PasswordBox.Text).Equals("s"))
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();

            }
            else if ((MockSecurity.canLogin(AddressBox.Text, PasswordBox.Text).Equals("m"))) {
                ManagerWindow main = new ManagerWindow();
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or password do not match, please try again");
                invalidUser.Visibility = Visibility.Visible;
            }
        }

        private void orderNotification(object sender, RoutedEventArgs e)
        {
            OrderNotification order = new OrderNotification();
            order.Show();
        }
    }
}