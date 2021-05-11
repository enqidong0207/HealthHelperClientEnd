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

namespace XxxFitnessCLub
{
    public partial class FrmWeightLogChart : Form
    {
        public FrmWeightLogChart()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        WeightLogBLL weightLogBLL = new WeightLogBLL();
        WeightLogDTO weightLogDTO = new WeightLogDTO();

        private void ShowWeightLogChart()
        {
            weightLogBLL = new WeightLogBLL();
            DateTime startDate = dpStart.Value;
            DateTime endDate = dpEnd.Value;
            weightLogDTO.WeightLogs = weightLogBLL.GetWeightLogs(UserStatic.UserID, startDate, endDate);
            if (weightLogDTO.WeightLogs.Count != 0)
            {
                chart1.Series.Clear();
                chart1.Series.Add("體重");
                chart1.DataSource = weightLogDTO.WeightLogs;
                chart1.Series["體重"].XValueMember = "UpdatedDate";
                chart1.Series["體重"].YValueMembers = "Weight";
            }
            else
            {
                chart1.Series.Clear();
            }
        }
        private void FrmWeightLogChart_Load(object sender, EventArgs e)
        {
            dpStart.Value = DateTime.Today.AddDays(-7);
            dpEnd.Value = DateTime.Today;
            ShowWeightLogChart();
        }

        private void dpStart_ValueChanged(object sender, EventArgs e)
        {
            ShowWeightLogChart();
        }

        private void dpEnd_ValueChanged(object sender, EventArgs e)
        {
            ShowWeightLogChart();
        }
    }
}
