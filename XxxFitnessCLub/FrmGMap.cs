using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XxxFitnessCLub
{
    public partial class FrmGMap : Form
    {
        public List<PointLatLng> searchResult;
        public GeocodingProvider gp;
        public YahooMapProvider gmp;

        public FrmGMap()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {


            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            GeoCoordinate coord = new GeoCoordinate();
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

            //初始化地圖為google map 並設定初始中心位置為china
            //gMap.MapProvider = GMap.NET.MapProviders.GoogleChinaMapProvider.Instance;

            GMaps.Instance.Mode = AccessMode.ServerOnly;
            this.gMapControl1.MapProvider = GMapProviders.YahooMap;
            //gmp = this.gMap.MapProvider as YahooMapProvider;
            //gmp.ApiKey = "AIzaSyAE3Hi6N9QONHypztdZAvYkdTIOXdnzNE4";

            //gMap.Position = new PointLatLng(45.74740199642105, 126.69570922851562);
            //gMap.SetPositionByKeywords("china,harbin");//設定初始中心為china harbin

            this.gMapControl1.Position = new PointLatLng(coord.Latitude, coord.Longitude);
            gMapControl1.Position = new PointLatLng(25.03746, 121.564558);

            //gp = this.gMap.MapProvider as GeocodingProvider;
            //GMapProvider.Language = LanguageType.ChineseTraditional;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeoCoderStatusCode statusCode = gmp.GetPoints("park", out searchResult);
        }
    }
}
