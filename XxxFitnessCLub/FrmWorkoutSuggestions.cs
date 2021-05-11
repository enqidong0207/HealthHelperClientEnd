using HHFirstDraft.BLL;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub.DAL;

namespace XxxFitnessCLub
{
    public partial class FrmWorkoutSuggestions : Form
    {
        WorkoutCategoryBLL wcBLL = new WorkoutCategoryBLL();
        List<WorkoutCategoryDetailDTO> wcList;

        ActivityLevelBLL alBLL = new ActivityLevelBLL();
        List<ActivityLevelDetailDTO> alList;

        WorkoutBLL wBll = new WorkoutBLL();

        const int TBL_CONTENT_START_X = 1;
        const int TBL_CONTENT_START_Y = 3;

        public FrmWorkoutSuggestions()
        {
            InitializeComponent();

            
        }

        private void FrmWorkoutSuggestions_Load(object sender, EventArgs e)
        {
            
            alList = alBLL.GetActivityLevels().OrderBy(al => al.ID).ToList();
            wcList = wcBLL.GetCategories();

            LoadTableHeader(wcList, alList);

            LoadTableContent(wcList, alList);

        }

        private void LoadTableContent(List<WorkoutCategoryDetailDTO> wcList, List<ActivityLevelDetailDTO> alList)
        {
            for (int i = 0; i < wcList.Count; i++)
            {
                for (int j = 0; j < alList.Count; j++)
                {
                    FlowLayoutPanel panel = new FlowLayoutPanel();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Dock = DockStyle.Fill;
                    this.tableLayoutPanel1.Controls.Add(panel, TBL_CONTENT_START_X + j, TBL_CONTENT_START_Y + i);
                    
                    foreach (var item in wBll.GetWorkoutByWCAL(wcList[i].ID, alList[j].ID))
                    {
                        Label lbl = new Label();
                        lbl.Text = item.Name;
                        lbl.Font = new Font(lbl.Font.Name, 12f);
                        lbl.Height = (int)(lbl.Font.Size * 2.5);
                        lbl.Margin = new Padding(2);
                        lbl.Paint += FrmAddWorkoutPreferences.LblWorkout_Paint;
                        lbl.Click += lblWorkout_Click;
                        panel.Controls.Add(lbl);
                    }
                    
                }
            }
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
                this.tableLayoutPanel1.Controls.Add(lbl, TBL_CONTENT_START_X + i, 1);
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
        }

        private void lblWorkout_Click(object sender, EventArgs e)
        {
            Label lblWorkout = sender as Label;

            string keyword = wBll.ToPlacesKeyword(lblWorkout.Text);

            FrmGMap frm = new FrmGMap(keyword);
            frm.ShowDialog();
        }
    }

}
