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

namespace ZakladkiAdoNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void GotFocusLogIn(object sender, RoutedEventArgs e)
        {
            txtLogIn.Text = "";
        }

        private void GotFocusPassword(object sender, RoutedEventArgs e)
        {
            txtPassword.Text = "";
        }

        private void LogInProgramm(object sender, RoutedEventArgs e)
        {

        }

        private void RegisterProgramm(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}
