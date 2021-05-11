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
    public partial class FrmCommentBoard : Form
    {
        public FrmCommentBoard()
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
            lblMeals.Visible = false;
            cmbMeals.Visible = false;
        }
        CommentCategoryBLL categoryBLL = new CommentCategoryBLL();
        CommentCategoryDTO categoryDTO = new CommentCategoryDTO();
        MealDTO mealDTO = new MealDTO();
        MealBLL mealBLL = new MealBLL();
        private void LoadComboBox()
        {
            categoryDTO.CommentCategories = categoryBLL.GetCommentCategories();
            cmbCategory.DataSource = categoryDTO.CommentCategories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "ID";
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
            dataGridView1.Columns["CategoryID"].Visible = false;
            dataGridView1.Columns["CategoryName"].HeaderText = "評論項目";
            dataGridView1.Columns["Rating"].HeaderText = "評分";
            dataGridView1.Columns["MealOptionID"].Visible = false;
            dataGridView1.Columns["MealName"].HeaderText = "餐點";
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
            numericRating.Value = 1;
            cmbCategory.Enabled = true;
            numericRating.Enabled = true;
        }
        CommentDetailDTO detail = new CommentDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            detail.MemberID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MemberID"].Value);
            detail.Member = dataGridView1.Rows[e.RowIndex].Cells["Member"].Value.ToString();
            detail.Title = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
            detail.CategoryName = dataGridView1.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();
            detail.Rating = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Rating"].Value);
            detail.CommentContent = dataGridView1.Rows[e.RowIndex].Cells["CommentContent"].Value.ToString();
            detail.CategoryID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CategoryID"].Value);
            detail.IsApproved = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["IsApproved"].Value);
            detail.MealOptionID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MealOptionID"].Value);
            if (dataGridView1.Rows[e.RowIndex].Cells["MealName"].Value != null)
            {
                detail.MealName = dataGridView1.Rows[e.RowIndex].Cells["MealName"].Value.ToString();
            }
            txtTitle.Text = detail.Title;
            txtComment.Text = detail.CommentContent;
            txtMember.Text = detail.Member;
            cmbCategory.SelectedValue = detail.CategoryID;
            numericRating.Value = detail.Rating;
            txtMember.Enabled = false;
            if (detail.CategoryID == General.CommentCategory.meal)
            {
                cmbMeals.Visible = true;
                lblMeals.Visible = true;
            }
            else
            {
                cmbMeals.Visible = false;
                lblMeals.Visible = false;
            }
            if (detail.MemberID == UserStatic.UserID)
            {
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                txtTitle.Enabled = true;
                txtComment.Enabled = true;
                cmbCategory.Enabled = true;
                numericRating.Enabled = true;
            }
            else
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                txtTitle.Enabled = false;
                txtComment.Enabled = false;
                cmbCategory.Enabled = false;
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
                detail.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                detail.Rating = Convert.ToInt32(numericRating.Value);
                detail.MemberID = UserStatic.UserID;
                detail.IsApproved = false;
                detail.AddDate = DateTime.Now;
                if (detail.CategoryID == General.CommentCategory.meal)
                {
                    detail.MealOptionID = Convert.ToInt32(cmbMeals.SelectedValue);
                }
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
            detail.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
            detail.Rating = Convert.ToInt32(numericRating.Value);
            if (detail.CategoryID == General.CommentCategory.meal)
            {
                detail.MealOptionID = Convert.ToInt32(cmbMeals.SelectedValue);
            }
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

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategory;
            if (int.TryParse(cmbCategory.SelectedValue.ToString(), out selectedCategory) &&
                 selectedCategory == General.CommentCategory.meal)
            {
               
                lblMeals.Visible = true;
                cmbMeals.Visible = true;
            }
            else
            {
                lblMeals.Visible = false;
                cmbMeals.Visible = false;
            }
        }
    }
}
