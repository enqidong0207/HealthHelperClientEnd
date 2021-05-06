using HHFirstDraft;
using HHFirstDraft.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XxxFitnessCLub
{
    public partial class FrmWorkoutLogChart : Form
    {
        private FrmWorkoutLog workoutLogForm;
        private WorkoutLogBLL wlBll = new WorkoutLogBLL();
        public FrmWorkoutLogChart(FrmWorkoutLog _workoutLogForm)
        {
            workoutLogForm = _workoutLogForm;
            InitializeComponent();

            ShowChart(null, 7);

            this.lblTakeDaysTest.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowChat_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtTakeDays.Text, out int takeDays))
            {
                this.lblTakeDaysTest.Text = "請輸入數字";
                return;
            }

            ShowChart(this.dtpStartDate.Value.Date, takeDays);

            this.lblTakeDaysTest.Text = "";
        }

        private void ShowChart(DateTime? date, int takeDays)
        {
            var list = this.wlBll.GetWorkoutCalByDate(date?.Date, takeDays);

            if (list.Count == 0)
            {
                MessageBox.Show("日期區間無資料");
                list = this.wlBll.GetWorkoutCalByDate(null, takeDays);
            }
            else
            {
                this.chart1.DataSource = list;
                this.chart1.Series[0].XValueMember = "EditDate";
                this.chart1.Series[0].YValueMembers = "TotalCal";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                this.chart1.Series[1].XValueMember = "EditDate";
                this.chart1.Series[1].YValueMembers = "TotalHours";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
            
        }
    }
}
