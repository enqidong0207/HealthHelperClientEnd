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
using XxxFitnessCLub;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft
{   
    //恩旗
    public partial class FrmWorkoutLog : Form
    {
        public FrmWorkoutLog()
        {
            InitializeComponent();
        }

        WorkoutLogBLL wlBll = new WorkoutLogBLL();
        internal WorkoutLogDTO dto;
        internal bool isUpdate = false;
        internal string keyword;
        bool isAscending = false;
        int sortColIndex = -1;

        private void FrmWorkout_Load(object sender, EventArgs e)
        {
            ShowWorkoutLog(null);

            this.dataGridView1.DataSource = this.bsWL;
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
        }

        public void ShowWorkoutLog(string keyword)
        {
            wlBll = new WorkoutLogBLL();
            this.bsWL.DataSource = wlBll.GetWorkoutLogsByKeyword(keyword);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isUpdate = false;

            FrmAddWorkoutLog frm = new FrmAddWorkoutLog(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if (dto.EditTime.Date != DateTime.Now.Date)
            {
                MessageBox.Show($"此紀錄的日期為{dto.EditTime.Date:yyyy/MM/dd}\n只能修改今天({DateTime.Now.Date:yyyy/MM/dd})的紀錄");
                return;
            }

            isUpdate = true;

            FrmAddWorkoutLog frm = new FrmAddWorkoutLog(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (dto.EditTime.Date != DateTime.Now.Date)
            {
                MessageBox.Show($"此紀錄的日期為{dto.EditTime.Date:yyyy/MM/dd}\n只能刪除今天({DateTime.Now.Date:yyyy/MM/dd})的紀錄");
                return;
            }

            DialogResult result = MessageBox.Show($"你確定欲刪除該運動紀錄\n{dto.WorkoutName}\n(紀錄時間{dto.EditTime})", "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool isSuccess = wlBll.Delete(dto);

                if (isSuccess)
                {
                    MessageBox.Show("刪除成功");
                    ShowWorkoutLog(keyword);
                }
                else
                {
                    MessageBox.Show("刪除失敗");
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (this.dataGridView1.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
            {
                return;
            }

            string columnName = this.dataGridView1.Columns[e.ColumnIndex].Name;

            if (e.ColumnIndex == this.sortColIndex)
            {
                if (isAscending)
                {
                    this.bsWL.DataSource = wlBll.GetWorkoutLogsByKeyword(keyword)
                        .OrderByDescending(wl => wl.GetType().GetProperty(columnName).GetValue(wl)).ToList();
                    this.isAscending = false;
                    this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                }
                else
                {
                    this.bsWL.DataSource = wlBll.GetWorkoutLogsByKeyword(keyword)
                        .OrderBy(wl => wl.GetType().GetProperty(columnName).GetValue(wl)).ToList();
                    this.isAscending = true;
                    this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                }
            }
            else
            {
                this.bsWL.DataSource = wlBll.GetWorkoutLogsByKeyword(keyword)
                    .OrderBy(wl => wl.GetType().GetProperty(columnName).GetValue(wl)).ToList();
                this.isAscending = true;
                this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                this.sortColIndex = e.ColumnIndex;
            }



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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "WorkoutTotalCal"
                || this.dataGridView1.Columns[e.ColumnIndex].Name == "WorkoutHours")
            {
                e.Value = $"{e.Value:0.00}";
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            dto = wlBll.GetWorkoutLogByID(ID);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // todo 加入日期搜尋
            keyword = textBox1.Text;
            ShowWorkoutLog(keyword);
        }
    }
}
