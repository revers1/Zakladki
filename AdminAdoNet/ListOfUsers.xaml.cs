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
using ZakladkiAdoNet;

namespace AdminAdoNet
{
    /// <summary>
    /// Interaction logic for ListOfUsers.xaml
    /// </summary>
    public partial class ListOfUsers : Window
    {   
        public ListOfUsers()
        {
            InitializeComponent();

            List<UserModel> list = new List<UserModel>();

            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:49808/api/user/getUser/");
            request.Method = "GET";
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                var users = JsonConvert.DeserializeObject<List<UserModel>>(json);
                list = users;
            }

            dgOfUsers.ItemsSource = list;
        }

        private void BlockUser(object sender, RoutedEventArgs e)
        {
            List<UserModel> list = new List<UserModel>();

            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:49808/api/user/blockUser/"+$"{((UserModel)dgOfUsers.SelectedItems[0]).Id}");
            request.Method = "POST";
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                var users = JsonConvert.DeserializeObject<List<UserModel>>(json);
                list = users;
            }

            dgOfUsers.ItemsSource = list;
        }

        private void UblockUser(object sender, RoutedEventArgs e)
        {
            List<UserModel> list = new List<UserModel>();

            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:49808/api/user/unblockUser/" + $"{((UserModel)dgOfUsers.SelectedItems[0]).Id}");
            request.Method = "POST";
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                var users = JsonConvert.DeserializeObject<List<UserModel>>(json);
                list = users;
            }

            dgOfUsers.ItemsSource = list;
        }

        private void ChangeRoleOfUser(object sender, RoutedEventArgs e)
        {
            List<UserModel> models = new List<UserModel>();

            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:49808/api/user/changeRoleOfUser/");
            request.Method = "POST";
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                var users = JsonConvert.DeserializeObject<List<UserModel>>(json);
                models = users;
            }
        }
    }
}
