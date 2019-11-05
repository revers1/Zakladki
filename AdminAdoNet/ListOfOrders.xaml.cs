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
    /// Interaction logic for ListProducts.xaml
    /// </summary>
    public partial class ListOfOrders : Window
    {
       
        public ListOfOrders()
        {
            InitializeComponent();
            List<OrderModel> list = new List<OrderModel>();

            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:51295/api/zakazclient/getZakaz/");
            request.Method = "GET";
            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                var orders = JsonConvert.DeserializeObject<List<OrderModel>>(json);
                list = orders;
            }

            dgOfOrders.ItemsSource = list;
        }
    }
}
