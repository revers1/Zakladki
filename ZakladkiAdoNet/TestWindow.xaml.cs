using GMap.NET;
using GMap.NET.WindowsPresentation;
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
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow()
        {
            InitializeComponent();
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            mapView.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            mapView.MinZoom = 2;
            mapView.MaxZoom = 17;
            // whole world zoom
            mapView.Zoom = 2;
            // lets the map use the mousewheel to zoom
            mapView.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            // lets the user drag the map
            mapView.CanDragMap = true;
            // lets the user drag the map with the left mouse button
            mapView.DragButton = MouseButton.Left;
        }

        private void click(object sender, MouseButtonEventArgs e)
        {
            var point = mapView.FromLocalToLatLng(Convert.ToInt32(e.GetPosition(mapView).X), Convert.ToInt32(e.GetPosition(mapView).Y
                ));
            double lat = point.Lat;
            double lng = point.Lng;
            PointLatLng dot = new PointLatLng();
            dot.Lat = lat;
            dot.Lng = lng;
            GMapMarker marker = new GMapMarker(dot);
            marker.Shape = new Ellipse
            {
                Width = 10,
                Fill = Brushes.Red,
                Height = 10,
                Stroke = Brushes.Black,
                StrokeThickness = 1.0
            };
            mapView.Markers.Add(marker);
            mapView.IsEnabled = false;
            
        }
    }
}
