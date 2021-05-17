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
    public partial class BSFrmComment : Form
    {
        public BSFrmComment()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BSFrmAddComment frm = new BSFrmAddComment(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            this.textBox1.Clear();
        }
        CommentBLL commentBLL = new CommentBLL();
        CommentDTO commentDTO = new CommentDTO();
        private void FrmComment_Load(object sender, EventArgs e)
        {
            ShowComments();
        }
        public void ShowComments()
        {
            commentBLL = new CommentBLL();
            if (!isSearch) commentDTO = commentBLL.GetComments();
            else commentDTO = commentBLL.GetComments(keyword);
            dataGridView1.DataSource = commentDTO.Comments;
            dataGridView1.Columns["ID"].HeaderText = "編號";
            dataGridView1.Columns["Title"].HeaderText = "標題";
            dataGridView1.Columns["CommentContent"].HeaderText = "內容";
            dataGridView1.Columns["MemberID"].Visible = false;
            dataGridView1.Columns["Member"].HeaderText = "會員";
            dataGridView1.Columns["AddDate"].HeaderText = "留言時間";
            dataGridView1.Columns["IsApproved"].HeaderText = "是否核准";
            dataGridView1.Columns["CategoryID"].Visible = false;
            dataGridView1.Columns["CategoryName"].HeaderText = "評論項目";
            dataGridView1.Columns["Rating"].HeaderText = "評分";
            dataGridView1.Columns["MealOptionID"].Visible = false;
            dataGridView1.Columns["MealName"].HeaderText = "餐點";
            dataGridView1.Columns["Feedback"].HeaderText = "回覆";
            isSearch = false;
        }
        bool isAscending = false;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<CommentDetailDTO> list = (List<CommentDetailDTO>)dataGridView1.DataSource;
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
        bool isSearch = false;
        string keyword;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            keyword = textBox1.Text;
            isSearch = true;
            ShowComments();
        }
        CommentDetailDTO detail = new CommentDetailDTO();
        private void btnEdit_Click(object sender, EventArgs e)
        {
            BSFrmAddComment frm = new BSFrmAddComment(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.isUpdate = true;
            frm.detail = detail;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            this.textBox1.Clear();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            detail.Title = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
            detail.CommentContent = dataGridView1.Rows[e.RowIndex].Cells["CommentContent"].Value.ToString();
            detail.MemberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MemberID"].Value);
            detail.CategoryID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CategoryID"].Value);
            detail.IsApproved = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["IsApproved"].Value);
            detail.Rating = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Rating"].Value);
            detail.MealOptionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MealOptionID"].Value);
            if (dataGridView1.Rows[e.RowIndex].Cells["FeedBack"].Value != null)
            {
                detail.Feedback = dataGridView1.Rows[e.RowIndex].Cells["FeedBack"].Value.ToString();
            }
            else
            {
                detail.Feedback = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你確定欲刪除 " + detail.Member + " 的評論?", "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                commentBLL.Delete(detail.ID);
                MessageBox.Show("已刪除評論");
                ShowComments();
            }
        }
    }
}
