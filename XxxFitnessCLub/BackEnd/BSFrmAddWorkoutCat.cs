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
    public partial class BSFrmAddWorkoutCat : Form
    {
        public BSFrmAddWorkoutCat()
        {
            InitializeComponent();
        }
        string keyword;
        bool isSearch = false;
        WorkoutCategoryBLL bll = new WorkoutCategoryBLL();

        WorkoutCategoryDTO dto = new WorkoutCategoryDTO();
        private void FrmAddWorkoutCat_Load(object sender, EventArgs e)
        {
            ShowWorkoutCat();
            
        }
        public void ShowWorkoutCat()
        {
            bll = new WorkoutCategoryBLL();
            if (!isSearch) dto.Categories = bll.GetCategories();
            else dto.Categories = bll.GetCategories(keyword);
            dataGridView1.DataSource = dto.Categories;
            dataGridView1.Columns["ID"].HeaderText = "分類編號";
            dataGridView1.Columns["Name"].HeaderText = "分類名稱";
            isSearch = false;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            WorkoutCategoryDetailDTO detail = new WorkoutCategoryDetailDTO();
            if (txtName.Text == "")
            {
                MessageBox.Show("請輸入名稱");
            }
            else if (bll.IsCategoryExist(txtName.Text))
            {
                MessageBox.Show("該類別名稱已存在");

            }
            else
            {
                detail.Name = txtName.Text;
                if (bll.Add(detail))
                {
                    MessageBox.Show("已新增運動類別"); 
                    ShowWorkoutCat();

                    txtName.Clear();
                }
            }
        }
        WorkoutCategoryDetailDTO selectedDetail = new WorkoutCategoryDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selectedDetail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            selectedDetail.Name = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            dto.Workouts = bll.GetWorkouts(selectedDetail.ID);
            dataGridView2.DataSource = dto.Workouts;
            dataGridView2.Columns["ID"].HeaderText = "運動編號";
            dataGridView2.Columns["Name"].HeaderText = "運動名稱";
            dataGridView2.Columns["ActivityLevel"].Visible = false;
            dataGridView2.Columns["ActivityLevelID"].Visible = false;
            dataGridView2.Columns["CategoryName"].Visible = false;
            dataGridView2.Columns["CategoryID"].Visible = false;


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BSFrmEditWorkoutCat frmEdit = new BSFrmEditWorkoutCat(this);
            frmEdit.detail = selectedDetail;
            frmEdit.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你確定欲刪除該類別 " + selectedDetail.Name + " ?", "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (bll.HasWorkouts(selectedDetail.ID))
                {
                    MessageBox.Show("該類別已存在運動項目，請先刪除運動項目再行刪除");
                }
                else
                {
                    if(bll.Delete(selectedDetail.ID))
                    {
                        MessageBox.Show("已刪除類別"); 
                        ShowWorkoutCat();


                    }

                }
            }
        }
        
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            keyword = txtName.Text;
            isSearch = true;
            ShowWorkoutCat();
        }
        
    }
}
