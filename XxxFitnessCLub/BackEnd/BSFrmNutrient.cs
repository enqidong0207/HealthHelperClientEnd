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
    public partial class BSFrmNutrient : Form
    {
        public BSFrmNutrient()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BSFrmAddNutrient frm = new BSFrmAddNutrient(this);
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.IsUpdate = false;
            frm.Show();
        }
        NutrientDTO dto = new NutrientDTO();
        private void btnEdit_Click(object sender, EventArgs e)
        {
            BSFrmAddNutrient frm = new BSFrmAddNutrient(this);
            frm.mealName = mealName_inFrmNutrient;
            frm.mealCalories = mealCalories_inFrmNutrient;
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.detail = detail;
            frm.dto = dto;
            frm.IsUpdate = true;
            frm.Show();
        }

        private void FrmNutrient_Load(object sender, EventArgs e)
        {
            ShowNutrient();
        }
        
        NutrientBLL bll = new NutrientBLL();
        MealBLL mbll = new MealBLL();
        
        bool isSearch = false;
        int ID;
        public void ShowNutrient()
        {
            
            NutrientDTO Nutdto = new NutrientDTO();
            MealDTO dto = new MealDTO();
            MealDetailDTO MDdto = new MealDetailDTO();
            //dto = mbll.GetMeals();
            if (isSearch) dto = mbll.GetMeals(keyword);
            else dto = mbll.GetMeals();

            dataGridView1.DataSource = dto.Meals;
            dataGridView1.Columns["ID"].HeaderText = "餐點編號";
            dataGridView1.Columns["Name"].HeaderText = "食物名稱";
            dataGridView1.Columns["Calories"].HeaderText = "卡路里";
            dataGridView1.Columns["Nutrient"].Visible = false;
            dataGridView1.Columns["Image"].Visible = false;
            dataGridView1.Columns["NutrientID"].HeaderText = "營養編號";
            dataGridView1.Columns["Fat"].HeaderText = "脂肪";
            dataGridView1.Columns["Protein"].HeaderText = "蛋白質";
            dataGridView1.Columns["Carbs"].HeaderText = "碳水化合物";
            dataGridView1.Columns["Sugar"].HeaderText = "醣";
            dataGridView1.Columns["VitA"].HeaderText = "維生素A";
            dataGridView1.Columns["VitB"].HeaderText = "維生素B";
            dataGridView1.Columns["VitC"].HeaderText = "維生素C";
            dataGridView1.Columns["VitD"].HeaderText = "維生素D";
            dataGridView1.Columns["VitE"].HeaderText = "維生素E";
            dataGridView1.Columns["Na"].HeaderText = "鈉";
            dataGridView1.Columns["K"].HeaderText = "鉀";


        }

        private void button1_Click(object sender, EventArgs e)
        {


            //int selectID = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            MessageBox.Show(detail.NutrientID.ToString());
        }
MealDetailDTO detail = new MealDetailDTO();
        public string mealName_inFrmNutrient;
        public string mealCalories_inFrmNutrient;
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            
            detail.Name = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            mealName_inFrmNutrient = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            detail.Calories = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Calories"].Value);
            mealCalories_inFrmNutrient = dataGridView1.Rows[e.RowIndex].Cells["Calories"].Value.ToString();
            detail.NutrientID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["NutrientID"].Value);
            detail.Fat = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Fat"].Value);
            detail.Protein = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Protein"].Value);
            detail.Carbs = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Carbs"].Value);
            detail.Sugar = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Sugar"].Value);
            detail.VitA = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitA"].Value);
            detail.VitB = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitB"].Value);
            detail.VitC = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitC"].Value);
            detail.VitD = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitD"].Value);
            detail.VitE = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitE"].Value);
            detail.Na = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Na"].Value);
            detail.K = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["K"].Value);
            dto.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["NutrientID"].Value);
            dto.Fat = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Fat"].Value);
            dto.Protein = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Protein"].Value);
            dto.Carbs = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Carbs"].Value);
            dto.Sugar = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Sugar"].Value);
            dto.VitA = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitA"].Value);
            dto.VitB = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitB"].Value);
            dto.VitC = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitC"].Value);
            dto.VitD = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitD"].Value);
            dto.VitE = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["VitE"].Value);
            dto.Na = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Na"].Value);
            dto.K = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["K"].Value);

        }
        //string keyword;
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    keyword = textBox1.Text;
        //    isSearch = true;
        //    ShowMeals();
        //}
        string keyword;
        private void selectTextbox_TextChanged(object sender, EventArgs e)
        {
            keyword = selectTextbox.Text;
            isSearch = true;
            ShowNutrient();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
