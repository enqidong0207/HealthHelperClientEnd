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
    public partial class BSFrmTag : Form
    {
        public BSFrmTag()
        {
            InitializeComponent();
        }
        TagCategoryBLL bll = new TagCategoryBLL();
        TagCategoryDTO dto = new TagCategoryDTO();
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTag_Load(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void RefreshPage()
        {
            bll = new TagCategoryBLL();
            if (!isSearch) dto.TagCategories = bll.GetTags();
            else dto.TagCategories = bll.GetTags(keyword);
            dataGridView1.DataSource = dto.TagCategories;
            dataGridView1.Columns["ID"].HeaderText = "標籤編號";
            dataGridView1.Columns["Name"].HeaderText = "標籤名稱";
            dto.Meals = bll.GetMealsWithTagID(detail.ID);
            dataGridView2.DataSource = dto.Meals;
            dataGridView2.Columns["ID"].HeaderText = "餐點編號";
            dataGridView2.Columns["Name"].HeaderText = "餐點名稱";
            dataGridView2.Columns["Calories"].HeaderText = "卡路里";
            dataGridView2.Columns["Image"].Visible = false;
            dataGridView2.Columns["Nutrient"].Visible = false;
            dataGridView2.Columns["NutrientID"].Visible = false;
            dataGridView2.Columns["Fat"].Visible = false;
            dataGridView2.Columns["Protein"].Visible = false;
            dataGridView2.Columns["Carbs"].Visible = false;
            dataGridView2.Columns["Sugar"].Visible = false;
            dataGridView2.Columns["VitA"].Visible = false;
            dataGridView2.Columns["VitB"].Visible = false;
            dataGridView2.Columns["VitC"].Visible = false;
            dataGridView2.Columns["VitD"].Visible = false;
            dataGridView2.Columns["VitE"].Visible = false;
            dataGridView2.Columns["Na"].Visible = false;
            dataGridView2.Columns["K"].Visible = false;
            isSearch = false;
        }

        TagCategoryDetailDTO detail = new TagCategoryDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            dto.Meals = bll.GetMealsWithTagID(detail.ID);
            dataGridView2.DataSource = dto.Meals;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("請輸入欲新增標籤名稱");
            }
            else if (bll.IsTagExist(textBox1.Text))
            {
                MessageBox.Show("該標籤已經存在");
            }
            else
            {
                TagCategoryDetailDTO detail = new TagCategoryDetailDTO();
                detail.Name = textBox1.Text;
                bll.Add(detail);
                MessageBox.Show("已新增標籤");
                RefreshPage();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtUpdate.Text == "")
            {
                MessageBox.Show("請輸入欲新增標籤名稱");
            }
            else if (txtUpdate.Text == detail.Name)
            {
                MessageBox.Show("若欲修改，請輸入一個新的名稱");
            }
            else
            {
                detail.Name = txtUpdate.Text;
                bll.Update(detail);
                MessageBox.Show("已修改標籤");
                RefreshPage();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你確定欲刪除該標籤 " + detail.Name + " ?", "警告", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (bll.HasMeals(detail.ID))
                {
                    bll.RemoveAttachedTag(detail.ID);
                    MessageBox.Show("已清除所屬餐點的該附帶標籤");
                }
                bll.Delete(detail.ID);
                MessageBox.Show("已刪除標籤");
                RefreshPage();
            }
           
        }
        bool isSearch = false;
        string keyword;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isSearch = true;
            keyword = textBox1.Text;
            RefreshPage();
        }
    }
}
