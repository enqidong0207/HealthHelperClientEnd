using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using XxxFitnessClub.BackEnd.BLL;

namespace XxxFitnessClub.BackEnd
{
    public partial class BSFrmPie : Form
    {
        public BSFrmPie()
        {
            InitializeComponent();
        }

        private void FrmPie_Load(object sender, EventArgs e)
        {
            WorkoutLogBLL workoutLogBLL = new WorkoutLogBLL();
            var q = workoutLogBLL.GetWorkoutNamePie();

            this.chart1.DataSource = q;

            this.chart1.Series[0].Name = "WorkoutLog";
            this.chart1.Series[0].XValueMember = "WorkoutName";

            this.chart1.Series[0].YValueMembers = "Count";
            this.chart1.Series[0]["PieLabelStyle"] = "Outside";
            this.chart1.Series[0]["PieLineColor"] = "red";

            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkoutLogBLL workoutLogBLL = new WorkoutLogBLL();
            DateTime start = this.dateTimePicker1.Value;
            DateTime end = this.dateTimePicker2.Value;
            if (end < start)
            {
                MessageBox.Show("時間選擇有誤");
            }
            else
            {
                var q = workoutLogBLL.GetWorkoutDatePie(start, end);

                if (q.Count == 0)
                {
                    MessageBox.Show("此範圍無相關資料");
                }

                else
                {
                    this.chart1.DataSource = q;
                    this.chart1.Series[0].Points.FindMaxByValue()["Exploded"] = "true";

                    this.chart1.Series[0].Name = "WorkoutLog";
                    this.chart1.Series[0].XValueMember = "WorkoutName";
                    this.chart1.Series[0].YValueMembers = "Count";
                    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                }

            }


            //this.chart1.Series[0].Points.FindMaxByValue().Color = System.Drawing.Color.Red;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            WorkoutLogBLL workoutLogBLL = new WorkoutLogBLL();
            bool gender=true;
            if (!RbtnMale.Checked && !RbtnFemale.Checked)
            {
                MessageBox.Show("請點選需分析的性別");
            }
            else
            {
                if (RbtnMale.Checked) gender = true;
                else if (RbtnFemale.Checked) gender = false;

                var q = workoutLogBLL.GetWorkoutGenderPie(gender);
                this.chart1.DataSource = q;

                this.chart1.Series[0].Name = "WorkoutLog";
                this.chart1.Series[0].XValueMember = "WorkoutName";
                this.chart1.Series[0].YValueMembers = "Count";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
            
        }        
    }
}
