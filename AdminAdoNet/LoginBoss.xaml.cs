using AdminAdoNet.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace AdminAdoNet
{
    /// <summary>
    /// Interaction logic for LoginBoss.xaml
    /// </summary>
    public partial class LoginBoss : Window
    {
        public LoginBoss()
        {
            InitializeComponent();
        }

        private void GotFocusUserName(object sender, RoutedEventArgs e)
        {
            txtUsernameOfBoss.Text = "";
        }

        private void GotFocusPassword(object sender, RoutedEventArgs e)
        {
            txtPasswordOfBoss.Text = "";
        }

        private void LogInProgramm(object sender, RoutedEventArgs e)
        {
            CheckALogin();
        }

        private void LoginKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CheckALogin();
            }
        }

        public void CheckALogin()
        {
            if (txtPasswordOfBoss.Text == "" || txtUsernameOfBoss.Text == "")
            {
                MessageBox.Show("Please fill in the empty fields!");
            }
            else
            {
                try
                {
                    HttpWebRequest request = WebRequest.CreateHttp("http://localhost:49388/api/boss/loginBoss");
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(new LoginModel()
                        {
                            Login = txtUsernameOfBoss.Text,
                            Password = txtPasswordOfBoss.Text
                        });
                        stream.Write(json);
                    }
                    WebResponse response = request.GetResponse();
                    AdminWindow admin = new AdminWindow();
                    MessageBox.Show(request.ToString());
                    admin.Show();
                    this.Close();
                }
                catch ( Exception )
                {
                    MessageBox.Show("Try again!", "Fail", MessageBoxButton.OK);
                }
            }

            /* CHECK A LOGIN */
            //AdminWindow admin = new AdminWindow();
            //admin.Show();
            //Close();
        }

        private void RegisterBoss(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void RegisterBoss(object sender, RoutedEventArgs e)
        {

        }
    }
}
