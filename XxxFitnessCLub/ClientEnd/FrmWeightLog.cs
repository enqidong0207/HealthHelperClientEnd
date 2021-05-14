using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub;
using XxxFitnessCLub.ClientEnd.BLL;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd
{
    public partial class FrmWeightLog : Form
    {
        public FrmWeightLog()
        {
            InitializeComponent();
        }
        WeightLogBLL bll = new WeightLogBLL();
        WeightLogDTO dto = new WeightLogDTO();
        private void FrmWeightLog_Load(object sender, EventArgs e)
        {
            ShowWeightLogs();
        }
        public void ShowWeightLogs()
        {
            bll = new WeightLogBLL();
            dto.WeightLogs = bll.GetWeightLogs(UserStatic.UserID);
            dataGridView1.DataSource = dto.WeightLogs;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["MemberID"].Visible = false;
            dataGridView1.Columns["MemberName"].HeaderText = "會員名稱";
            dataGridView1.Columns["Weight"].HeaderText = "體重";
            dataGridView1.Columns["UpdatedDate"].HeaderText = "更新時間";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddWeightLog frm = new FrmAddWeightLog(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmAddWeightLog frm = new FrmAddWeightLog(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.isUpdate = true;
            frm.detail = detail;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();

        }
        WeightLogDetailDTO detail = new WeightLogDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            detail.MemberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MemberID"].Value);
            detail.Weight = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Weight"].Value);
            detail.UpdatedDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["UpdatedDate"].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你確定欲刪除 " + detail.UpdatedDate+ "  的體重記錄?", "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bll.Delete(detail.ID);
                MessageBox.Show("已刪除紀錄");
                ShowWeightLogs();
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            FrmWeightLogChart frm = new FrmWeightLogChart();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
    }
}
