using Microsoft.Maps.MapControl.WPF;
using Microsoft.Win32;
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
using ZakladkiAdoNet.Config;

namespace ZakladkiAdoNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NameOfProduct(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
        }

        private void PriceOfProduct(object sender, RoutedEventArgs e)
        {
            txtPrice.Text = "";
          
        }

        private void CommentToProduct(object sender, RoutedEventArgs e)
        {
            txtComment.Text = "";
        }

        public void CheckAOrderInfo()
        {
            if (txtName.Text == "" ||
                txtPrice.Text == "" ||
                txtComment.Text == "")
            {
                MessageBox.Show("Please fill in the empty fields!");
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                PictureOfProductLocation.Source = new BitmapImage(new Uri(op.FileName));
                textboxphoto.Text = op.FileName;
            }




        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
           
            byte[] imgbyte = File.ReadAllBytes(textboxphoto.Text);
            HttpWebRequest request = WebRequest.CreateHttp($"{Api.Url}/Product/addProduct");
            request.Method = "POST";
            request.ContentType = "application/json";
            StreamWriter stream = new StreamWriter(request.GetRequestStream());
            string json = JsonConvert.SerializeObject(new Product()
            {

                Name = txtName.Text,
                Price = decimal.Parse(txtPrice.Text),
                Description = txtComment.Text,
                Imagge = Convert.ToBase64String(imgbyte),
                Quantity = float.Parse(txtQuantity.Text),
                CoordX = txtcoordx.Text,
                CoordY = txtcoordy.Text,
                User_Id=((ZakazClient)(listboxClient.SelectedItems[0])).UserId
                
               

        });
            stream.Write(json);
            stream.Close();

            WebResponse response = request.GetResponse();
            MessageBox.Show("added");
            ClearAllFields();
            




        }

        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MapLayer maplayer = new MapLayer();
            Pushpin pin=new Pushpin();
            pin.Location = Map.Center;

            maplayer.Children.Add(pin);
            Map.Children.Add(maplayer);


            //Point mousePosition = e.GetPosition(this);
            //Location pinLocation = Map.ViewportPointToLocation(mousePosition);

            //pin = new Pushpin();
            //pin.Location = pinLocation;

            txtcoordx.Text = pin.Location.Latitude.ToString();
            txtcoordy.Text = pin.Location.Longitude.ToString();

            //Map.Children.Add(pin);
            //MapLayer maplayer2 = new MapLayer();

            //Map.Children.Add(maplayer2);
            Map.IsEnabled = false;

        }

        private void txtQuantity_GotFocus(object sender, RoutedEventArgs e)
        {
            txtQuantity.Text = "";
        }
        public void ClearAllFields()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtComment.Text = "";
            PictureOfProductLocation.Source = null;
            txtQuantity.Text = "";
            txtcoordx.Text = "";
            txtcoordy.Text = "";
            Map.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //ButtonRefreshListBox
            HttpWebRequest request = WebRequest.CreateHttp($"{Api.Url}/Zakaz/getZakaz");
            request.Method = "GET";
            request.ContentType = "application/json";
            var response = request.GetResponse();
            string res = "";
            List<ZakazClient> zakaz;
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                res += reader.ReadToEnd();
                zakaz = JsonConvert.DeserializeObject<List<ZakazClient>>(res);
            }
            listboxClient.ItemsSource = zakaz;






            //MessageBox.Show(res);
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
            listboxProduct.ItemsSource = products;
        }

    }
}
