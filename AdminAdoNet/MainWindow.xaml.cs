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

namespace AdminAdoNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void OpenListOfUsers(object sender, RoutedEventArgs e)
        {
            ListOfUsers listOfUsers = new ListOfUsers();
            listOfUsers.Show();
        }

        private void OpenListOfPOrders(object sender, RoutedEventArgs e)
        {
            ListOfOrders listOfOrders = new ListOfOrders();
            listOfOrders.Show();
        }
    }
}
