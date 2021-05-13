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
using HHFirstDraft;

namespace HHFirstDraft
{
    public partial class FrmWorkoutLog : Form
    {
        public FrmWorkoutLog()
        {
            InitializeComponent();
        }

        WorkoutLogBLL bll = new WorkoutLogBLL();
        WorkoutLogDTO dto;
        private void FrmWorkout_Load(object sender, EventArgs e)
        {
            ShowWorkoutLog();
        }
        // todo
        //bool isSearch = false;
        public void ShowWorkoutLog()
        {
            bll = new WorkoutLogBLL();

            dataGridView1.DataSource = bll.GetWorkoutLogs();

            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["MemberID"].Visible = false;
            dataGridView1.Columns["MemberName"].Visible = false;
            dataGridView1.Columns["WorkoutID"].Visible = false;
            dataGridView1.Columns["WorkoutName"].HeaderText = "運動名稱";
            dataGridView1.Columns["WorkoutCategoryName"].HeaderText = "運動類型名稱";
            dataGridView1.Columns["ActivityLevelName"].HeaderText = "運動強度";
            dataGridView1.Columns["EditTime"].HeaderText = "紀錄時間";
            dataGridView1.Columns["WorkoutHours"].HeaderText = "運動時間";
            dataGridView1.Columns["IsWorkoutPreference"].HeaderText = "喜好運動";
            dataGridView1.Columns["WorkoutTotalCal"].HeaderText = "總消耗卡路里";
            dataGridView1.Columns["Workout"].Visible = false;
            dataGridView1.Columns["Member"].Visible = false;
            //isSearch = false;
        }

        private void btnAddWorkout_Click(object sender, EventArgs e)
        {
            FrmAddWorkoutLog frm = new FrmAddWorkoutLog(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
        string keyword;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            keyword = textBox1.Text;
            //isSearch = true;
            //ShowWorkouts();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // todo
            //FrmAddWorkout frm = new FrmAddWorkout(this);
            //frm.TopLevel = false;
            //frm.AutoScroll = true;
            //this.Controls.Add(frm);
            //frm.FormBorderStyle = FormBorderStyle.None;
            //frm.detail = detail;
            //frm.dto = dto;
            //frm.IsUpdate = true;
            //frm.Show();
        }
        WorkoutDetailDTO detail = new WorkoutDetailDTO();

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // todo
            //detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            //detail.Name = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            //detail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CategoryID"].Value);
            //detail.ActivityLevelID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ActivityLevelID"].Value);
            //detail.Calories = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Calories"].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // todo
            //DialogResult result = MessageBox.Show("你確定欲刪除該運動 " + detail.Name + " ?", "警告", MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
            //    if (bll.Delete(detail.ID))
            //    {
            //        MessageBox.Show("已刪除該運動項目");
            //        //ShowWorkouts();
            //        this.textBox1.Clear();
            //    }
            //}
        }
        bool isAscending = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // todo
            //List<WorkoutDetailDTO> list = (List<WorkoutDetailDTO>)dataGridView1.DataSource;
            //string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            //if (isAscending)
            //{
            //    dataGridView1.DataSource = list.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x)).ToList();
            //    isAscending = false;
            //}
            //else
            //{
            //    isAscending = true;
            //    dataGridView1.DataSource = list.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x)).ToList();
            //}
        }

        private void btnWorkoutLogChart_Click(object sender, EventArgs e)
        {
            FrmWorkoutLogChart frm = new FrmWorkoutLogChart(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();

        }
    }
}
