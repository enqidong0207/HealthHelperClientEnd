using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using GoogleApi;

namespace XxxFitnessCLub
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            AddressGeocodeRequest address = new AddressGeocodeRequest();
            address.Address = "籃球";
            address.Key = "AIzaSyAE3Hi6N9QONHypztdZAvYkdTIOXdnzNE4";

            var response = GoogleApi.GoogleMaps.AddressGeocode.Query(address);

        }
    }
}
