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

namespace WpfApplication2
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
            if (canLogin(AddressBox.Text, PasswordBox.Text))
            {
                //this.Close();
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Username or password do not match, please try again");
            }
        }

        private Boolean canLogin(String login, String pass)
        {
            return true;
        }
    }
}
