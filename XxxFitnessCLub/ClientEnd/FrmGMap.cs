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
using System.Threading.Tasks;
using XxxFitnessCLub.ClientEnd.BLL;
using System.Drawing.Drawing2D;

namespace XxxFitnessCLub.ClientEnd
{
    //恩旗
    public partial class FrmGMap : Form
    {
        GeoCoordinate coord;
        GMapOverlay overlayOne = new GMapOverlay("circle");
        GMapOverlay overlayTwo = new GMapOverlay("Name");
        string keyword;
        WorkoutBLL wBll = new WorkoutBLL();
        GMapMarkerWithLabel mainMarker;

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

            GMapProvider.Language = LanguageType.ChineseTraditional;

            CreateCircle(new PointF((float)coord.Latitude, (float)coord.Longitude), 0.018d, 60);
            AddPlaces(keyword);
            this.gMapControl1.Overlays.Add(overlayTwo);
        }

        private void AddPlaces(string keyword)
        {
            if (keyword == null)
            {
                keyword = "";
            }
            
            Task<PlacesNearbySearchResponse> task = wBll.GetWorkoutPlaces(keyword, coord);

            PlacesNearbySearchResponse response = task.Result;

            List<NearByResult> points = Enumerable.ToList(response.Results);

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

            overlayOne.Polygons.Add(gpol);
            this.gMapControl1.Overlays.Add(overlayOne);
            overlayOne.IsVisibile = false;
            overlayOne.IsVisibile = true;
        }

        private void AddMarkers(GMapOverlay overlay, List<NearByResult> points)
        {
            mainMarker = new GMapMarkerWithLabel(
                new PointLatLng(coord.Latitude, coord.Longitude), GMarkerGoogleType.red, "目前位置", Color.Red);
            overlay.Markers.Add(mainMarker);

            for (int i = 0; i < points.Count; i++)
            {
                PointLatLng point = new PointLatLng(points[i].Geometry.Location.Latitude, points[i].Geometry.Location.Longitude);

                GMapMarkerWithLabel marker = new GMapMarkerWithLabel(point, GMarkerGoogleType.green, points[i].Name, Color.Green);
                marker.ToolTipText = "\n" + points[i].Name;

                marker.ToolTip.TextPadding = new Size((int)marker.ToolTip.Font.Height, (int)marker.ToolTip.Font.Height);
                
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

        //todo
        private void gMapControl1_OnMapZoomChanged()
        {
            //DrawNameOnMarker(this.mainMarker);

            if (this.gMapControl1.Zoom == 18)
            {
                for (int i = 0; i < overlayOne.Markers.Count; i++)
                {
                    GMapMarkerWithLabel marker = overlayOne.Markers[i] as GMapMarkerWithLabel;
                    //marker.SetZoomLevel(this.gMapControl1.Zoom);
                    marker.ToolTipMode = MarkerTooltipMode.Never;
                }
            }
            else
            {
                for (int i = 0; i < overlayOne.Markers.Count; i++)
                {
                    GMapMarkerWithLabel marker = overlayOne.Markers[i] as GMapMarkerWithLabel;
                    //marker.SetZoomLevel(this.gMapControl1.Zoom);
                    marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                }
            }

            
        }
        private void DrawNameOnMarker(GMapMarkerWithLabel marker)
        {
            Graphics g = this.overlayTwo.Control.CreateGraphics();

            var stringSize = g.MeasureString(marker.Caption, marker.Font);
            var localPoint = new PointF(marker.LocalPosition.X + marker.Size.Width / 2 - stringSize.Width / 2, marker.LocalPosition.Y - stringSize.Height);

            g.DrawString(marker.Caption, marker.Font, new SolidBrush(marker.Color), localPoint);

            //GraphicsPath p = new GraphicsPath();
            //p.AddString(
            //    marker.Caption,             // text to draw
            //    FontFamily.GenericSansSerif,  // or any other font family
            //    (int)FontStyle.Bold,      // font style (bold, italic, etc.)
            //    g.DpiY * 16 / 72,       // em size
            //    new Point((int)localPoint.X, (int)localPoint.Y),              // location where to draw text
            //    new StringFormat());          // set options here (e.g. center alignment)
            //g.DrawPath(new Pen(Color.White, 3f), p);
            //g.FillPath(new SolidBrush(marker.Color), p);
        }

    }

    public class GMapMarkerWithLabel : GMarkerGoogle
    {
        private double zoom = 0;
        private Font font = new Font("Arial", 16);
        private string caption;
        private Color color;

        public GMapMarkerWithLabel(PointLatLng p, GMarkerGoogleType type, string caption, Color color)
            : base(p, type)
        {
            this.caption = caption;
            this.color = color;
        }

        public string Caption 
        {
            get
            {
                return this.caption;
            }
        }

        public Font Font
        {
            get
            {
                return this.font;
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
        }

        public void SetZoomLevel(double z)
        {
            this.zoom = z;
        }

        public override void OnRender(Graphics g)
        {
            base.OnRender(g);

            if (zoom == 18)
            {
                var stringSize = g.MeasureString(this.caption, this.font);
                var localPoint = new PointF(LocalPosition.X + this.Size.Width / 2 - stringSize.Width / 2, LocalPosition.Y - stringSize.Height);
                g.DrawString(this.caption, this.font, new SolidBrush(this.color), localPoint);

                //GraphicsPath p = new GraphicsPath();
                //p.AddString(
                //    this.caption,             // text to draw
                //    FontFamily.GenericSansSerif,  // or any other font family
                //    (int)FontStyle.Bold,      // font style (bold, italic, etc.)
                //    g.DpiY * 16 / 72,       // em size
                //    new Point((int)localPoint.X, (int)localPoint.Y),              // location where to draw text
                //    new StringFormat());          // set options here (e.g. center alignment)
                //g.DrawPath(new Pen(Color.White, 3f), p);
                //g.FillPath(new SolidBrush(this.color), p);
            }

            
        }

        
    }
}
