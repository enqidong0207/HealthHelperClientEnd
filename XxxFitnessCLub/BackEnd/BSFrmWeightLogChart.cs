using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessClub.BackEnd.BLL;
using XxxFitnessClub.BackEnd.DAL.DTO;

namespace XxxFitnessClub.BackEnd
{
    public partial class BSFrmWeightLogChart : Form
    {
        public BSFrmWeightLogChart()
        {
            InitializeComponent();
        }
        MemberBLL memberBLL = new MemberBLL();
        MemberDTO memberDTO = new MemberDTO();
        WeightLogBLL weightLogBLL = new WeightLogBLL();
        WeightLogDTO weightLogDTO = new WeightLogDTO();
        public int selectedMember;
        private void FrmWeightLogChart_Load(object sender, EventArgs e)
        {
            memberDTO = memberBLL.GetMembers();
            memberDTO.Members.Insert(0, new MemberDetailDTO { ID = 0, Name = "全部" });
            cmbMembers.DataSource = memberDTO.Members;
            cmbMembers.DisplayMember = "Name";
            cmbMembers.ValueMember = "ID";
            cmbMembers.SelectedValue = selectedMember;
            dpStart.Value = DateTime.Today.AddDays(-7);
            dpEnd.Value = DateTime.Today;
            ShowWeightLogChart();
        }

        private void ShowWeightLogChart()
        {
            weightLogBLL = new WeightLogBLL();
            DateTime startDate = dpStart.Value;
            DateTime endDate = dpEnd.Value;
            if (selectedMember != 0)
            {
                weightLogDTO.WeightLogs = weightLogBLL.GetWeightLogs(selectedMember, startDate, endDate);
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
            else
            {
                weightLogDTO.WeightLogs = weightLogBLL.GetWeightLogs(startDate, endDate);
                var list = from wl in weightLogDTO.WeightLogs
                           group wl by wl.MemberName into g
                           select new
                           {
                               MemberName = g.Key,
                               MemberCount = g.Count()
                           };
                chart1.Series.Clear();
                chart1.Series.Add("體重登入次數");
                chart1.DataSource = list.ToList();
                chart1.Series["體重登入次數"].XValueMember = "MemberName";
                chart1.Series["體重登入次數"].YValueMembers = "MemberCount";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parsedValue;
            if (int.TryParse(cmbMembers.SelectedValue.ToString(), out parsedValue))
            {
                selectedMember = parsedValue;
                ShowWeightLogChart();
            }
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
