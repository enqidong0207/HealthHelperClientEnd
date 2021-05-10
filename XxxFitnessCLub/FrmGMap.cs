using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Drawing;
using System.Windows.Forms;

namespace XxxFitnessCLub
{
    public partial class FrmGMap : Form
    {
        List<PointLatLng> searchResult;
        GeocodingProvider gp;
        GoogleMapProvider gmp;
        GeoCoordinate coord;
        GMapOverlay overlayOne = new GMapOverlay("circle");

        public FrmGMap()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {


            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            coord = new GeoCoordinate();
            while (coord.IsUnknown)
            {
                watcher.TryStart(true, TimeSpan.FromMilliseconds(5000));
                coord = watcher.Position.Location;
            }

            if (coord.IsUnknown != true)
            {
                MessageBox.Show($"Lat: {coord.Latitude}, Long: {coord.Longitude}");
            }
            else
            {
                MessageBox.Show("Unknown latitude and longitude.");
            }

            
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            this.gMapControl1.MapProvider = GMapProviders.GoogleMap;
            this.gMapControl1.Position = new PointLatLng(coord.Latitude, coord.Longitude);

            gmp = this.gMapControl1.MapProvider as GoogleMapProvider;
            gmp.ApiKey = "AIzaSyAE3Hi6N9QONHypztdZAvYkdTIOXdnzNE4";

            //gp = GMapProviders.OpenStreetMap;
            GMapProvider.Language = LanguageType.ChineseTraditional;

            CreateCircle(new PointF((float)coord.Latitude, (float)coord.Longitude), 0.01d, 60);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeoCoderStatusCode statusCode = gmp.GetPoints("中正紀念堂", out searchResult);
            AddMarkers(overlayOne, searchResult);
        }

        private void CreateCircle(PointF point, double radius, int segments)
        {
            
            List<PointLatLng> gpollist = new List<PointLatLng>();

            double seg = Math.PI * 2 / segments;

            for (int i = 0; i < segments; i++)
            {
                double theta = seg * i;
                double a = point.X + Math.Cos(theta) * radius;
                double b = point.Y + Math.Sin(theta) * radius;

                PointLatLng gpoi = new PointLatLng(a, b);

                gpollist.Add(gpoi);
            }
            GMapPolygon gpol = new GMapPolygon(gpollist, "pol");

            //add overlay to control
            overlayOne.Polygons.Add(gpol);
            this.gMapControl1.Overlays.Add(overlayOne);
            overlayOne.IsVisibile = false;
            overlayOne.IsVisibile = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void AddMarkers(GMapOverlay overlay, List<PointLatLng> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                GMapMarker marker = new GMarkerGoogle(points[i], GMarkerGoogleType.green);
                overlay.Markers.Add(marker);
            }
            overlay.IsVisibile = false;
            overlay.IsVisibile = true;
        }
    }
}
