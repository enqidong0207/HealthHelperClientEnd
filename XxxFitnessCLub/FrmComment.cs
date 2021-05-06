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
using XxxFitnessCLub.BLL;
using XxxFitnessCLub.DAL.DTO;

namespace XxxFitnessCLub
{
    public partial class FrmComment : Form
    {
        public FrmComment()
        {
            InitializeComponent();
        }
        CommentBLL commentBLL = new CommentBLL();
        CommentDTO commentDTO = new CommentDTO();
        private void FrmComment_Load(object sender, EventArgs e)
        {
            ShowComments();
            LoadComboBox();
            txtMember.Enabled = false;
            txtMember.Text = UserStatic.UserName;
        }
        MealBLL mealBLL = new MealBLL();
        MealDTO mealDTO = new MealDTO();
        private void LoadComboBox()
        {
            mealDTO = mealBLL.GetMeals();
            cmbMeals.DataSource = mealDTO.Meals;
            cmbMeals.DisplayMember = "Name";
            cmbMeals.ValueMember = "ID";
        }
        
        public void ShowComments()
        {
            commentBLL = new CommentBLL();
            commentDTO = commentBLL.GetApprovedComments();
            dataGridView1.DataSource = commentDTO.Comments;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Title"].HeaderText = "標題";
            dataGridView1.Columns["CommentContent"].HeaderText = "內容";
            dataGridView1.Columns["MemberID"].Visible = false;
            dataGridView1.Columns["Member"].HeaderText = "會員";
            dataGridView1.Columns["AddDate"].HeaderText = "留言時間";
            dataGridView1.Columns["IsApproved"].Visible = false;
            dataGridView1.Columns["MealID"].Visible = false;
            dataGridView1.Columns["MealName"].HeaderText = "評論餐點";
            dataGridView1.Columns["Rating"].HeaderText = "評分";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextboxes();
        }
        private void ClearTextboxes()
        {
            txtTitle.Clear();
            txtComment.Clear();
            txtTitle.Enabled = true;
            txtComment.Enabled = true;
            txtMember.Text = UserStatic.UserName;
            txtMember.Enabled = false;
            cmbMeals.SelectedIndex = -1;
            numericRating.Value = 1;
            cmbMeals.Enabled = true;
            numericRating.Enabled = true;
        }
        CommentDetailDTO detail = new CommentDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            detail.MemberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MemberID"].Value);
            detail.Member = dataGridView1.Rows[e.RowIndex].Cells["Member"].Value.ToString();
            detail.Title = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
            detail.MealName = dataGridView1.Rows[e.RowIndex].Cells["MealName"].Value.ToString();
            detail.Rating = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Rating"].Value);
            detail.CommentContent = dataGridView1.Rows[e.RowIndex].Cells["CommentContent"].Value.ToString();
            detail.MealID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MealID"].Value);
            detail.IsApproved = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["IsApproved"].Value);

            txtTitle.Text = detail.Title;
            txtComment.Text = detail.CommentContent;
            txtMember.Text = detail.Member;
            cmbMeals.SelectedValue = detail.MealID;
            numericRating.Value = detail.Rating;
            txtMember.Enabled = false;
            if (detail.MemberID == UserStatic.UserID)
            {
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                txtTitle.Enabled = true;
                txtComment.Enabled = true;
                cmbMeals.Enabled = true;
                numericRating.Enabled = true;
            }
            else
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                txtTitle.Enabled = false;
                txtComment.Enabled = false;
                cmbMeals.Enabled = false;
                numericRating.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!txtTitle.Enabled) 
            {
                ClearTextboxes(); // Clear textboxes first.
            }
            else if (txtTitle.Text == "" || txtComment.Text == "")
            {
                MessageBox.Show("請填入所有欄位"); // Empty control.
            }
            else
            {
                detail = new CommentDetailDTO();
                detail.Title = txtTitle.Text;
                detail.CommentContent = txtComment.Text;
                detail.MealID = Convert.ToInt32(cmbMeals.SelectedValue);
                detail.Rating = Convert.ToInt32(numericRating.Value);
                detail.MemberID = UserStatic.UserID;
                detail.IsApproved = false;
                detail.AddDate = DateTime.Now;
                commentBLL.Add(detail);
                MessageBox.Show("已新增留言");
                ClearTextboxes();
                ShowComments(); // Refresh page. => Won't show comment before approved.
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            detail.Title = txtTitle.Text;
            detail.CommentContent = txtComment.Text;
            detail.MealID = Convert.ToInt32(cmbMeals.SelectedValue);
            detail.Rating = Convert.ToInt32(numericRating.Value);
            commentBLL.Update(detail);
            MessageBox.Show("已修改留言");
            ClearTextboxes();
            ShowComments(); // Refresh page. => Won't show comment before approved.
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你確定欲刪除 " + detail.Member + " 的評論?", "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                commentBLL.Delete(detail.ID);
                MessageBox.Show("已刪除評論");
                ClearTextboxes();
                ShowComments();
            }
        }
    }
}
