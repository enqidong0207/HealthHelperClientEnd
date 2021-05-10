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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.gMapControl1.MapProvider = GMapProviders.;

            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            GeoCoordinate coord = new GeoCoordinate();

            while (coord.IsUnknown)
            {
                watcher.TryStart(false, TimeSpan.FromMilliseconds(5000));
                coord = watcher.Position.Location;
            }

            if (coord.IsUnknown != true)
            {
                Console.WriteLine("Lat: {0}, Long: {1}",
                    coord.Latitude,
                    coord.Longitude);
            }
            else
            {
                Console.WriteLine("Unknown latitude and longitude.");
            }

            this.gMapControl1.Position = new PointLatLng(coord.Latitude, coord.Longitude);
        }
    }
}
