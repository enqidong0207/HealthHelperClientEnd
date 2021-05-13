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
using System.Windows.Forms.DataVisualization.Charting;

namespace HHFirstDraft
{
    //恩旗
    public partial class FrmWorkoutLogChart : Form
    {
        private FrmWorkoutLog workoutLogForm;
        private WorkoutLogBLL wlBll = new WorkoutLogBLL();
        public FrmWorkoutLogChart(FrmWorkoutLog _workoutLogForm)
        {
            workoutLogForm = _workoutLogForm;
            InitializeComponent();
        }

        private void FrmWorkoutLogChart_Load(object sender, EventArgs e)
        {
            this.dtpStartDate.Value = DateTime.Now.AddDays(-6).Date;
            ShowChart(this.dtpStartDate.Value.Date, this.dtpEndDate.Value.Date);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowChat_Click(object sender, EventArgs e)
        {
            if (this.dtpStartDate.Value > this.dtpEndDate.Value)
            {
                MessageBox.Show("起始日期大於結束日期");
                return;
            }

            ShowChart(this.dtpStartDate.Value.Date, this.dtpEndDate.Value.Date);
        }

        private void ShowChart(DateTime? startDate, DateTime? endDate)
        {
            var list = this.wlBll.GetWorkoutCalByDate(startDate?.Date, endDate?.Date);

            if (list.Count == 0)
            {
                MessageBox.Show("日期區間無資料");
                list = this.wlBll.GetWorkoutCalByDate(null, null);
            }

            this.chart1.DataSource = list;
            this.chart1.Series[0].XValueMember = "EditDate";
            this.chart1.Series[0].YValueMembers = "TotalCal";
            this.chart1.Series[0].ChartType = SeriesChartType.Column;

            this.chart1.Series[1].XValueMember = "EditDate";
            this.chart1.Series[1].YValueMembers = "TotalHours";
            this.chart1.Series[1].ChartType = SeriesChartType.Column;

        }

    }
}
