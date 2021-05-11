using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Drawing;
using System.Windows.Forms;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using System.Linq;
using Location = GoogleApi.Entities.Places.Search.NearBy.Request.Location;
using HHFirstDraft.BLL;

namespace XxxFitnessCLub
{
    //恩旗
    public partial class FrmGMap : Form
    {
        GeoCoordinate coord;
        GMapOverlay overlayOne = new GMapOverlay("circle");
        string keyword;
        WorkoutBLL wBll = new WorkoutBLL();

        public FrmGMap()
        {
            InitializeComponent();
        }

        public FrmGMap(string keyword, GeoCoordinate coord)
        {
            InitializeComponent();

            this.keyword = keyword;
            this.coord = coord;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

            GMaps.Instance.Mode = AccessMode.ServerOnly;
            this.gMapControl1.MapProvider = GMapProviders.GoogleMap;
            this.gMapControl1.Position = new PointLatLng(coord.Latitude, coord.Longitude);

            //gmp = this.gMapControl1.MapProvider as GoogleMapProvider;
            //gmp.ApiKey = "AIzaSyAE3Hi6N9QONHypztdZAvYkdTIOXdnzNE4";

            //gp = GMapProviders.OpenStreetMap;
            GMapProvider.Language = LanguageType.ChineseTraditional;

            CreateCircle(new PointF((float)coord.Latitude, (float)coord.Longitude), 0.018d, 60);
            AddPlaces(keyword);
        }

        private void AddPlaces(string keyword)
        {
            if (keyword == null)
            {
                keyword = "";
            }
            //GeoCoderStatusCode statusCode = gmp.GetPoints("中正紀念堂", out searchResult);

            //var sCoord = new GeoCoordinate(24, 121);
            //var eCoord = new GeoCoordinate(24.01, 121);
            //double distance = sCoord.GetDistanceTo(eCoord);

            //PlacesNearBySearchRequest placeRequest = new PlacesNearBySearchRequest();
            //placeRequest.Key = "AIzaSyAE3Hi6N9QONHypztdZAvYkdTIOXdnzNE4";
            //placeRequest.Language = GoogleApi.Entities.Common.Enums.Language.ChineseTraditional;
            //placeRequest.Keyword = keyword;
            //placeRequest.Location = new Location(coord.Latitude, coord.Longitude);
            //placeRequest.Radius = 2000d;
            //PlacesNearbySearchResponse response = GoogleApi.GooglePlaces.NearBySearch.Query(placeRequest);
            //List<NearByResult> points = Enumerable.ToList(response.Results);

            List<NearByResult> points = wBll.GetWorkoutPlaces(keyword, coord);

            AddMarkers(overlayOne, points);
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

        private void AddMarkers(GMapOverlay overlay, List<NearByResult> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                PointLatLng point = new PointLatLng(points[i].Geometry.Location.Latitude, points[i].Geometry.Location.Longitude);

                //var distance = coord.GetDistanceTo(new GeoCoordinate(point.Lat, point.Lng));
                //MessageBox.Show(distance.ToString());

                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green);
                marker.ToolTipText = points[i].Name;
                overlay.Markers.Add(marker);
            }
            overlay.IsVisibile = false;
            overlay.IsVisibile = true;
        }

        internal static GeoCoordinate GetCurrentPosition()
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

            return coord;
        }
    }
}
