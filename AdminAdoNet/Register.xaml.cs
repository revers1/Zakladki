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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void PreviewPage(object sender, RoutedEventArgs e)
        {
            LoginBoss logIn = new LoginBoss();
            logIn.Show();
            this.Close();
        }

        private void GotFocusLoginBoss(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
        }

        private void GotFocusPasswordBoss(object sender, RoutedEventArgs e)
        {
            txtPassword.Text = "";
        }

        private void RegistrationAccount(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Please fill in the empty fields!");
            }
            else
            {
                try
                {
                    HttpWebRequest request = WebRequest.CreateHttp("http://localhost:51295/api/boss/addBoss");
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(new BossModel()
                        {
                            Username = txtUsername.Text,
                            Password = txtPassword.Text
                        });
                        stream.Write(json);
                    }
                    WebResponse response = request.GetResponse();
                    MessageBox.Show(response.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                LoginBoss logIn = new LoginBoss();
                logIn.Show();
                this.Close();
            }
        }
    }
}

