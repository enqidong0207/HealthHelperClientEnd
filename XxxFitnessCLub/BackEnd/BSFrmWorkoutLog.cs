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
    public partial class BSFrmWorkoutLog : Form
    {
        
        public BSFrmWorkoutLog()
        {
            InitializeComponent();
        }
        WorkoutLogBLL bll = new WorkoutLogBLL();
        WorkoutLogDTO dto = new WorkoutLogDTO();
        WorkoutLogDetailDTO detail = new WorkoutLogDetailDTO();

        private void btnChart_Click(object sender, EventArgs e)
        {
            BSFrmPie frm = new BSFrmPie();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void FrmWorkoutLog_Load(object sender, EventArgs e)
        {
            ShowWorkoutLog();
        }

        string keyword;
        bool issearch = false;
        public void ShowWorkoutLog()
        {
            bll = new WorkoutLogBLL();
            if (issearch)
            {
                dto = bll.GetWorkoutLogs(keyword);
            }
            else dto = bll.GetWorkoutLogs();
            this.dataGridView1.DataSource = dto.workoutLogs;
            this.dataGridView1.Columns["ID"].HeaderText = "編號";
            this.dataGridView1.Columns["MemberID"].HeaderText = "會員編號";
            this.dataGridView1.Columns["WorkoutName"].HeaderText = "運動項目";
            this.dataGridView1.Columns["WorkoutHours"].HeaderText = "運動時間";
            this.dataGridView1.Columns["Calories"].HeaderText = "消耗熱量";
            this.dataGridView1.Columns["EditTime"].HeaderText = "編輯時間";
            dataGridView1.Columns["WorkoutID"].Visible = false;
            //dataGridView1.Columns["EditTime"].Visible = false;
            issearch = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            keyword = textBox1.Text;
            issearch = true;
            ShowWorkoutLog();
        }

        private void btnAddWorkoutLog_Click(object sender, EventArgs e)
        {
            BSFrmAddWorkoutLog frm = new BSFrmAddWorkoutLog(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.dto = dto;
            frm.detail = detail;
            frm.IsUpdate = false;
            frm.Show();
            this.textBox1.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你確定欲刪除該運動紀錄 " + detail.WorkoutName + " ?", "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (bll.Delete(detail.ID))
                {
                    MessageBox.Show("已刪除該運動紀錄");
                    ShowWorkoutLog();
                    this.textBox1.Clear();
                }
            }
        }
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            detail.MemberID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MemberID"].Value);
            detail.MemberName = dataGridView1.Rows[e.RowIndex].Cells["MemberName"].Value.ToString();
            detail.WorkoutID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["WorkoutID"].Value);
            detail.WorkoutHours = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["WorkoutHours"].Value);
            detail.EditTime = (DateTime)(dataGridView1.Rows[e.RowIndex].Cells["EditTime"].Value);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (detail.EditTime!=DateTime.Now.Date)
            {
                MessageBox.Show("只能修改今天的紀錄");
            }
            else
            {
            BSFrmAddWorkoutLog frm = new BSFrmAddWorkoutLog(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.dto = dto;
            frm.detail = detail;
            frm.IsUpdate = true;
            frm.Show();
            this.textBox1.Clear();
            }

        }
    }
}
