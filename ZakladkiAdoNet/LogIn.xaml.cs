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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZakladkiAdoNet.Config;
using ZakladkiAdoNet.Models;

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

        private void GotFocusUserName(object sender, RoutedEventArgs e)
        {
            txtUsername.Text = "";
        }

        private void GotFocusPassword(object sender, RoutedEventArgs e)
        {
            txtPassword.Password = "";
        }

        private void LogInProgramm(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Please fill in the empty fields!");
            }
            else
            {
                try
                {

                    HttpWebRequest request = WebRequest.CreateHttp($"{Api.Url}/user/loginUser");
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    using (StreamWriter stream = new StreamWriter(request.GetRequestStream()))
                    {
                        string json = JsonConvert.SerializeObject(new LogInModel()
                        {
                            Login = txtUsername.Text,
                            Password = txtPassword.Password
                        });
                        stream.Write(json);
                        
                    }
               
                    WebResponse response = request.GetResponse();
                    LoginResultViewModel model2;
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        string json = streamReader.ReadToEnd();
                        model2 = JsonConvert.DeserializeObject<LoginResultViewModel>(json);
                        
                    }

                   
                    if (model2.RoleName == "Manager")
                    {
                        MainWindow mw = new MainWindow();
                        mw.Show();
                        this.Close();
                    }
                    else
                    {
                        
                        Logined.Id = model2.UserId;
                        
                        Client mwv = new Client();
                        mwv.Show();
                        this.Close();
                    }

                    ////MessageBox.Show(request.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Try again!", "Fail", MessageBoxButton.OK);
                }
            }
        }

        private void RegisterProgramm(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }
    }
}
