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
using ZakladkiAdoNet.Models;

namespace ZakladkiAdoNet
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
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


        private void PreviewPage(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

        private void RegistrationAccount(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpWebRequest request = HttpWebRequest.CreateHttp("https://localhost:49489/api/user/addUser");
                request.Method = "POST";
                request.ContentType = "application/json";
                StreamWriter stream = new StreamWriter(request.GetRequestStream());
                string json = JsonConvert.SerializeObject(new UserModel()
                {
                    Login = txtLogIn.Text,
                    Password = txtPassword.Text,
                    Role = false
                });
                stream.Write(json);
                WebResponse response = request.GetResponse();
                MessageBox.Show(response.ToString());
                stream.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
