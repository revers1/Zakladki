using Microsoft.Maps.MapControl.WPF;
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
using System.Windows.Media.Imaging;
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
           
            HttpWebRequest request = WebRequest.CreateHttp($"{Api.Url}/Zakaz/addZakaz");
            request.Method = "POST";
            request.ContentType = "application/json";
            StreamWriter stream = new StreamWriter(request.GetRequestStream());
            string json = JsonConvert.SerializeObject(new ZakazClient()
            {
                Name=txtName.Text,
                Quantity=float.Parse(txtQuantity.Text),
                Description=txtDescription.Text,
                UserId = Logined.Id

                
            });         
            stream.Write(json);
            stream.Close();

            WebResponse response = request.GetResponse();
            MessageBox.Show("added");
            
        }

        private void Buttonbuy_Click(object sender, RoutedEventArgs e)
        {


            HttpWebRequest request2 = WebRequest.CreateHttp($"{Api.Url}/product/deleteProduct/" + $"{((Product)listboxProduct.SelectedItems[0]).Id}");
            request2.Method = "DELETE";
            request2.ContentType = "application/json";
            var response2 = request2.GetResponse();
            string res2 = "";
            List<Product> products = new List<Product>() { };
            using (Stream stream = response2.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                res2 += reader.ReadToEnd();
                MessageBox.Show(res2);
                

            }
            WebResponse response = request2.GetResponse();
            Button_Click_1(null,null);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {        
            HttpWebRequest request2 = WebRequest.CreateHttp($"{Api.Url}/product/getProductOne/" + $"{Logined.Id}");
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
            if (products != null)
            {
                listboxProduct.ItemsSource = products;
            }
            else
                MessageBox.Show("PRODUCT NULL");
           
        }

        private void ListboxProduct_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HttpWebRequest request2 = HttpWebRequest.CreateHttp($"{Api.Url}/product/getProductClient/" +$"{((Product)listboxProduct.SelectedItems[0]).Id}");
            var response2 = request2.GetResponse();
            string res2 = "";
            Product products;
            using (Stream stream = response2.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                res2 += reader.ReadToEnd();
                products = JsonConvert.DeserializeObject<Product>(res2);
            }
            
                res2 = $"{Api.Url}/content/ProductImages/" + products.Imagge;

            

            Imagebox.Source = new BitmapImage(new Uri(res2));

            //            HttpWebRequest request = WebRequest.CreateHttp($"{Api.Url}/product/getImage/" + $"{((Product)listboxProduct.SelectedItems[0]).Id}");
            //            request.Method = "GET";
            //            request.ContentType = "application/json";
            //            var response = request.GetResponse();
            //            string res = "";
            //#pragma warning disable CS0219 // The variable 'path' is assigned but its value is never used
            //            string path = "";
            //#pragma warning restore CS0219 // The variable 'path' is assigned but its value is never used

            //            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            //            {
            //                string json = reader.ReadToEnd();
            //                List<Product> list = JsonConvert.DeserializeObject<List<Product>>(json);
            //                foreach (var item in list)
            //                {
            //                   res = $"{Api.Url}/content/ProductImages/" + item.Imagge;

            //                }

            //                Imagebox.Source = new BitmapImage(new Uri(res));
            //            }

            //using (Stream streamResponse = response.GetResponseStream())
            //{
            //    StreamReader reader = new StreamReader(streamResponse);
            //    string responseFromServer = reader.ReadToEnd();
            //    byte[] bytes = Convert.FromBase64String(JsonConvert.DeserializeObject<String>(responseFromServer));
            //    System.Drawing.Image image;
            //    using (MemoryStream ms = new MemoryStream(bytes))
            //    {
            //        image = System.Drawing.Image.FromStream(ms);
            //        //Imagebox.Source = (image);

            //    }
            //}
            if (res2!=null)
            {
             
                txtName.Text = products.Name;
            txtQuantity.Text = products.Quantity.ToString();
            txtDescription.Text = products.Description;

                MapLayer maplayer = new MapLayer();
                Pushpin pin = new Pushpin();

                pin.Location.Latitude = Convert.ToDouble(products.CoordX);
                pin.Location.Longitude = Convert.ToDouble(products.CoordY);

                maplayer.Children.Add(pin);
                Map.Children.Add(maplayer);







            }




        }

        private void txtName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
        }

        private void txtQuantity_GotFocus(object sender, RoutedEventArgs e)
        {
            txtQuantity.Text = "";
        }

        private void txtDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            txtDescription.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtQuantity.Text = "";
            Imagebox.Source = null;
            Map.Children.Clear();
            listboxProduct.SelectedItem = null;
           
        }
    }
}
