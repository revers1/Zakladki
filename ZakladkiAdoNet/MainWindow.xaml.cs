using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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
            }





        }
    }
}
