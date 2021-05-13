using GoogleApi.Entities.Places.Search.NearBy.Response;
using HHFirstDraft.BLL;
using HHFirstDraft.DAL.DTO;
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
using XxxFitnessCLub.DAL;

namespace XxxFitnessCLub
{
    //恩旗
    public partial class FrmWorkoutSuggestions : Form
    {
        WorkoutCategoryBLL wcBLL = new WorkoutCategoryBLL();
        List<WorkoutCategoryDetailDTO> wcList;

        ActivityLevelBLL alBLL = new ActivityLevelBLL();
        List<ActivityLevelDetailDTO> alList;

        WorkoutBLL wBll = new WorkoutBLL();

        const int TBL_CONTENT_START_X = 1;
        const int TBL_CONTENT_START_Y = 4;

        GeoCoordinate coord;

        List<List<FlowLayoutPanel>> panelList = new List<List<FlowLayoutPanel>>();

        bool reloadLock = false;

        public FrmWorkoutSuggestions()
        {
            InitializeComponent();
        }

        private void FrmWorkoutSuggestions_Load(object sender, EventArgs e)
        {
            coord = FrmGMap.GetCurrentPosition();
            this.lblCoord.Text = $"  Latitude：{coord.Latitude}\nLongtitude：{coord.Longitude}";

            alList = alBLL.GetActivityLevels().OrderBy(al => al.ID).ToList();
            wcList = wcBLL.GetCategories();

            LoadTableHeader(wcList, alList);
            LoadTableCell();
            LoadTableContentAsync(wcList, alList);
        }

        private void ClearTableContent() 
        {
            
            foreach (var item in this.panelList.SelectMany(l => l))
            {
                item.Controls.Clear();
            }
                
        }

        private async void LoadTableContentAsync(List<WorkoutCategoryDetailDTO> wcList, List<ActivityLevelDetailDTO> alList)
        {
            List<Task> tasks = new List<Task>();
            Dictionary<String, List<string>> keywords = new Dictionary<String, List<string>>();
            foreach (var item in wBll.GetWorkoutByWCAL(-1, -1))
            {
                string kw = wBll.ToPlacesKeyword(item.Name);
                if (kw == null)
                {
                    kw = "";
                }
                if (keywords.ContainsKey(kw))
                {
                    keywords[kw].Add(item.Name);
                }
                else
                {
                    keywords.Add(kw, new List<string> { item.Name });
                    Task<PlacesNearbySearchResponse> task = wBll.GetWorkoutPlaces(kw, coord);
                    tasks.Add(task);
                }
            }

            while (tasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(tasks);

                int index = tasks.IndexOf(finishedTask);

                List<String> places = keywords.ElementAt(index).Value;

                Task<PlacesNearbySearchResponse> task = finishedTask as Task<PlacesNearbySearchResponse>;
                PlacesNearbySearchResponse response = task.Result;
                if (response.Results.Count() > 0)
                {
                    for (int k = 0; k < places.Count; k++)
                    {
                        Workout w = wBll.GetWorkout(places[k]);

                        Label lbl = new Label();
                        lbl.Text = places[k];
                        lbl.Font = new Font(lbl.Font.Name, 12f);
                        lbl.Height = (int)(lbl.Font.Size * 2.5);
                        lbl.Margin = new Padding(2);
                        lbl.Paint += FrmAddWorkoutPreferences.LblWorkout_Paint;

                        int yIndex = wcList.IndexOf(wcList.SingleOrDefault(wc => wc.ID == w.WorkoutCategoryID));
                        int xIndex = alList.IndexOf(alList.SingleOrDefault(al => al.ID == w.ActivityLevelID));

                        panelList[yIndex][xIndex].Controls.Add(lbl);
                    }

                }

                keywords.Remove(keywords.ElementAt(index).Key);
                tasks.Remove(finishedTask);
            }

            AddClickHandler();
            MessageBox.Show("load success");
        }

        private void LoadTableHeader(List<WorkoutCategoryDetailDTO> wcList, List<ActivityLevelDetailDTO> alList)
        {
            for (int i = 0; i < alList.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = alList[i].Description;
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Font = new Font(lbl.Font.Name, 12);
                lbl.BackColor = Color.DeepSkyBlue;
                lbl.Margin = new Padding(2);
                if (i >= 5)
                {
                    this.tableLayoutPanel1.ColumnCount++;
                    this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / (i + 1)));
                }
                this.tableLayoutPanel1.Controls.Add(lbl, TBL_CONTENT_START_X + i, TBL_CONTENT_START_Y - 2);
                this.tableLayoutPanel1.SetRowSpan(lbl, 2);
            }

            for (int i = 0; i < wcList.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = wcList[i].Name;
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Font = new Font(lbl.Font.Name, 12);
                lbl.BackColor = Color.LightSteelBlue;
                lbl.Margin = new Padding(2);
                this.tableLayoutPanel1.RowCount++;
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100f));
                this.tableLayoutPanel1.Controls.Add(lbl, 0, TBL_CONTENT_START_Y + i);

            }

            Application.DoEvents();
        }

        private void lblWorkout_Click(object sender, EventArgs e)
        {
            Label lblWorkout = sender as Label;

            string keyword = wBll.ToPlacesKeyword(lblWorkout.Text);

            FrmGMap frm = new FrmGMap(keyword, coord);
            frm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (reloadLock)
            {
                return;
            }
            else
            {
                reloadLock = true;

                coord = FrmGMap.GetCurrentPosition();
                this.lblCoord.Text = $"Latitude：{coord.Latitude}\nLongtitude{coord.Longitude}";

                ClearTableContent();
                LoadTableContentAsync(wcList, alList);

                reloadLock = false;
            }
        }

        private void LoadTableCell()
        {
            for (int i = 0; i < wcList.Count; i++)
            {
                panelList.Add(new List<FlowLayoutPanel>());
                for (int j = 0; j < alList.Count; j++)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.Visible = false;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Dock = DockStyle.Fill;
                    panelList[i].Add(panel);
                    this.tableLayoutPanel1.Controls.Add(panel, TBL_CONTENT_START_X + j, TBL_CONTENT_START_Y + i);
                }
            }

            foreach (var panel in panelList.SelectMany(p => p))
            {
                panel.Visible = true;
            }
        }

        private void AddClickHandler()
        {
            List<Control> lblList =  this.panelList.SelectMany(l => l)
                .SelectMany(l => l.Controls.Cast<Control>().ToList()).ToList();

            foreach (var lbl in lblList)
            {
                lbl.Click += lblWorkout_Click;
            }
        }
    }

}
