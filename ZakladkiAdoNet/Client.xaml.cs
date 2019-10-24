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

namespace ZakladkiAdoNet
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
        }

        private void buttonzakazat_Click(object sender, RoutedEventArgs e)
        {
           
            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:49856/api/zakaz/addZakaz");
            request.Method = "POST";
            request.ContentType = "application/json";
            StreamWriter stream = new StreamWriter(request.GetRequestStream());
            string json = JsonConvert.SerializeObject(new ZakazClient()
            {
                Name=txtName.Text,
                Quantity=float.Parse( txtQuantity.Text),
                Description=txtDescription.Text
            });         
            stream.Write(json);
            stream.Close();

            WebResponse response = request.GetResponse();
            MessageBox.Show("added");
        }
    }
}
