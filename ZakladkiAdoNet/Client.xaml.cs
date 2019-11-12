using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using System.Windows.Shapes;
using ZakladkiAdoNet.Config;

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
           
            HttpWebRequest request = WebRequest.CreateHttp("http://localhost:49421/api/Zakaz/addZakaz");
            request.Method = "POST";
            request.ContentType = "application/json";
            StreamWriter stream = new StreamWriter(request.GetRequestStream());
            string json = JsonConvert.SerializeObject(new ZakazClient()
            {
                Name=txtName.Text,
                Quantity=float.Parse(txtQuantity.Text),
                Description=txtDescription.Text
            });         
            stream.Write(json);
            stream.Close();

            WebResponse response = request.GetResponse();
            MessageBox.Show("added");
        }

        private void Buttonbuy_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {        
            HttpWebRequest request2 = HttpWebRequest.CreateHttp($"{Api.Url}/product/getProductOne/" + $"{Logined.Id}");
            request2.Method = "GET";
            request2.ContentType = "application/json";
            var response2 = request2.GetResponse();
            string res2 = "";
            List<Product> products;
            using (Stream stream = response2.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                res2 += reader.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(res2);
            }
            listboxProduct.ItemsSource = products;
        }

        private void ListboxProduct_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HttpWebRequest request2 = HttpWebRequest.CreateHttp($"{Api.Url}/product/getProductClient/" + $"{((Product)listboxProduct.SelectedItems[0]).Id}");
            request2.Method = "GET";
            request2.ContentType = "application/json";
            var response2 = request2.GetResponse();
            string res2 = "";
            Product products;
            using (Stream stream = response2.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                res2 += reader.ReadToEnd();
                products = JsonConvert.DeserializeObject<Product>(res2);
            }

            HttpWebRequest request = HttpWebRequest.CreateHttp($"{Api.Url}/product/getImage/" + $"{((Product)listboxProduct.SelectedItems[0]).Id}");
            request.Method = "GET";
            request.ContentType = "application/json";
            var response = request.GetResponse();
            string res = "";
            string path = "";

            
            using (Stream streamResponse = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(streamResponse);
                string responseFromServer = reader.ReadToEnd();
                byte[] bytes = Convert.FromBase64String(JsonConvert.DeserializeObject<String>(responseFromServer));
                System.Drawing.Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = System.Drawing.Image.FromStream(ms);
                    //Imagebox.Source = (image);

                }
            }




            if (res2!=null)
            {
             
                txtName.Text = products.Name;
            txtQuantity.Text = products.Quantity.ToString();
            txtDescription.Text = products.Description;
            
            }
        }
    }
}
