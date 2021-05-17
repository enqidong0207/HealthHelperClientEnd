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
using XxxFitnessCLub;

namespace XxxFitnessClub.BackEnd
{
    public partial class BSFrmAddComment : Form
    {
        private BSFrmComment frmComment;
        public BSFrmAddComment(BSFrmComment _frmComment)
        {
            frmComment = _frmComment;
            InitializeComponent();
        }
        CommentBLL commentBLL = new CommentBLL();
        public CommentDetailDTO detail = new CommentDetailDTO();
        MealBLL mealBLL = new MealBLL();
        MealDTO mealDTO = new MealDTO();
        MemberBLL memberBLL = new MemberBLL();
        MemberDTO memberDTO = new MemberDTO();
        private void FrmAddComment_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            if (detail.MealOptionID == General.CommentCategory.meal)
            {
                lblMeal.Visible = true;
                cmbMeals.Visible = true;
            }
            else
            {
                lblMeal.Visible = false;
                cmbMeals.Visible = false;
            }
            if (isUpdate)
            {
                cmbNames.SelectedValue = detail.MemberID;
                cmbNames.Enabled = false;
                cmbCategories.SelectedValue = detail.CategoryID;
                cmbCategories.Enabled = false;
                if(detail.CategoryID == General.CommentCategory.meal)
                {
                    lblMeal.Enabled = false;
                    cmbMeals.Enabled = false;
                    cmbMeals.SelectedValue = detail.MealOptionID;
                }
                txtTitle.Text = detail.Title;
                txtComment.Text = detail.CommentContent;
                numerticRating.Value = detail.Rating;
                cbIsApproved.Checked = detail.IsApproved;
                lbTitle.Text = "修改評論";
                btnAdd.Text = "修改";
                btnAdd.BackColor = Color.SkyBlue;
                
            }
        }
        public bool isUpdate = false;
        CommentCategoryBLL categoryBLL = new CommentCategoryBLL();
        CommentCategoryDTO categoryDTO = new CommentCategoryDTO();
        private void LoadComboBox()
        {
            categoryDTO.categories = categoryBLL.GetCommentCategories();
            cmbCategories.DataSource = categoryDTO.categories;
            cmbCategories.DisplayMember = "Name";
            cmbCategories.ValueMember = "ID";
            memberDTO = memberBLL.GetMembers();
            cmbNames.DataSource = memberDTO.Members;
            cmbNames.DisplayMember = "Name";
            cmbNames.ValueMember = "ID";
            mealDTO = mealBLL.GetMeals();
            cmbMeals.DataSource = mealDTO.Meals;
            cmbMeals.DisplayMember = "Name";
            cmbMeals.ValueMember = "ID";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            detail.AddDate = DateTime.Now;
            detail.Title = txtTitle.Text;
            detail.Rating = Convert.ToInt32(numerticRating.Value);
            detail.MemberID = Convert.ToInt32(cmbNames.SelectedValue);
            detail.CategoryID = Convert.ToInt32(cmbCategories.SelectedValue);
            detail.CommentContent = txtComment.Text;
            detail.IsApproved = cbIsApproved.Checked;
            if (detail.CategoryID == General.CommentCategory.meal)
            {
                detail.MealOptionID = Convert.ToInt32(cmbMeals.SelectedValue);
            }
            if (txtTitle.Text == "" || txtComment.Text == "")
            {
                MessageBox.Show("請輸入所有欄位");
            }
            else
            {
                if (isUpdate)
                {
                    commentBLL.Update(detail);
                    MessageBox.Show("已修改評論");
                }
                else
                {
                    commentBLL.Add(detail);
                    MessageBox.Show("已新增評論");
                }
                frmComment.ShowComments();
                this.Close();
            }
        }

        private void cmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategory;
            if (int.TryParse(cmbCategories.SelectedValue.ToString(), out selectedCategory) &&
                 selectedCategory == General.CommentCategory.meal)
            {

                lblMeal.Visible = true;
                cmbMeals.Visible = true;
            }
            else
            {
                lblMeal.Visible = false;
                cmbMeals.Visible = false;
            }
        }
    }
}
