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
    public partial class BSFrmWeightLog : Form
    {
        public BSFrmWeightLog()
        {
            InitializeComponent();
        }
        WeightLogBLL bll = new WeightLogBLL();
        WeightLogDTO dto = new WeightLogDTO();
        MemberBLL memberBLL = new MemberBLL();
        MemberDTO memberDTO = new MemberDTO();
        private void FrmWeightLog_Load(object sender, EventArgs e)
        {
            memberDTO = memberBLL.GetMembers();
            memberDTO.Members.Insert(0, new MemberDetailDTO { Name = "全部", ID = 0 });
            cmbMembers.DataSource = memberDTO.Members;
            cmbMembers.DisplayMember = "Name";
            cmbMembers.ValueMember = "ID";
            cmbMembers.SelectedIndex = 0;
            ShowWeightLogs();
        }

        public void ShowWeightLogs()
        {
            bll = new WeightLogBLL();
            if (!isSearch || cmbMembers.SelectedIndex == 0) dto.WeightLogs = bll.GetWeightLogs();
            else dto.WeightLogs = bll.GetWeightLogs(memberID);
            dataGridView1.DataSource = dto.WeightLogs;
            dataGridView1.Columns["ID"].HeaderText = "編號";
            dataGridView1.Columns["MemberID"].Visible = false;
            dataGridView1.Columns["MemberName"].HeaderText = "會員名稱";
            dataGridView1.Columns["Weight"].HeaderText = "體重";
            dataGridView1.Columns["UpdatedDate"].HeaderText = "更新時間";
            isSearch = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BSFrmAddWeightLog frm = new BSFrmAddWeightLog(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BSFrmAddWeightLog frm = new BSFrmAddWeightLog(this);
            frm.TopLevel = false;
            frm.isUpdate = true;
            frm.detail = detail;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
        WeightLogDetailDTO detail = new WeightLogDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.MemberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MemberID"].Value);
            detail.Weight = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Weight"].Value);
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            detail.UpdatedDate = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["UpdatedDate"].Value);
        }
        bool isSearch = false;
        int memberID;
        private void cmbMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cmbMembers.SelectedValue.ToString(), out memberID))
            {
                isSearch = true;
                ShowWeightLogs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你確定欲刪除 " + detail.MemberName + " 的運動紀錄?", "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bll.Delete(detail.ID);
                MessageBox.Show("已刪除運動紀錄");
                ShowWeightLogs();
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            BSFrmWeightLogChart frm = new BSFrmWeightLogChart();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.selectedMember = Convert.ToInt32(cmbMembers.SelectedValue);
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
        bool isAscending = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<WeightLogDetailDTO> list = (List<WeightLogDetailDTO>)dataGridView1.DataSource;
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (isAscending)
            {
                dataGridView1.DataSource = list.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x)).ToList();
                isAscending = false;
            }
            else
            {
                isAscending = true;
                dataGridView1.DataSource = list.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x)).ToList();
            }
        }
    }
}
