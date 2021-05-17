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
    public partial class BSFrmWorkout : Form
    {
        public BSFrmWorkout()
        {
            InitializeComponent();
        }
        WorkoutBLL bll = new WorkoutBLL();
        WorkoutDTO dto = new WorkoutDTO();
        WorkoutCategoryBLL categoryBLL = new WorkoutCategoryBLL();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmWorkout_Load(object sender, EventArgs e)
        {
            ShowWorkouts();
        }
        bool isSearch = false;
        public void ShowWorkouts()
        {
            bll = new WorkoutBLL();
            if (isSearch) dto = bll.GetWorkouts(keyword);
            else dto = bll.GetWorkouts();
            dataGridView1.DataSource = dto.Workouts;
            dataGridView1.Columns["ID"].HeaderText = "編號";
            dataGridView1.Columns["Name"].HeaderText = "名稱";
            dataGridView1.Columns["Calories"].HeaderText = "卡路里";
            dataGridView1.Columns["ActivityLevel"].HeaderText = "活動強度";
            dataGridView1.Columns["CategoryName"].HeaderText = "類別";
            dataGridView1.Columns["CategoryID"].Visible = false;
            dataGridView1.Columns["ActivityLevelID"].Visible = false;
            isSearch = false;
        }

       

        private void btnAddWorkout_Click(object sender, EventArgs e)
        {
            BSFrmAddWorkout frm = new BSFrmAddWorkout(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.dto = dto;
            frm.detail = detail;
            frm.IsUpdate = false;
            frm.Show();
        }
        string keyword;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            keyword = textBox1.Text;
            isSearch = true;
            ShowWorkouts();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            BSFrmAddWorkout frm = new BSFrmAddWorkout(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.detail = detail;
            frm.dto = dto;
            frm.IsUpdate = true;
            frm.Show();
        }
        WorkoutDetailDTO detail = new WorkoutDetailDTO();

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            detail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CategoryID"].Value);
            detail.ActivityLevelID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ActivityLevelID"].Value);
            detail.Calories = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Calories"].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你確定欲刪除該運動 " + detail.Name + " ?", "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (bll.Delete(detail.ID))
                {
                    MessageBox.Show("已刪除該運動項目");
                    ShowWorkouts();
                    this.textBox1.Clear();
                }
            }
        }
        bool isAscending = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<WorkoutDetailDTO> list = (List<WorkoutDetailDTO>)dataGridView1.DataSource;
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
