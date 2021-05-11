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
using XxxFitnessCLub.Model.BLL;
using XxxFitnessCLub.Model.DAL.DAO;
using XxxFitnessCLub.Model.DAL.DTO;

namespace XxxFitnessCLub
{
    public partial class FrmNutrient : Form
    {
        public FrmNutrient()
        {
            InitializeComponent();
        }

        string keyword;
        bool isSearch = false;
        private void selectTextbox_TextChanged(object sender, EventArgs e)
        {
            keyword = selectTextbox.Text;
            isSearch = true;
            ShowNutrient();
        }
        MealBLL mbll = new MealBLL();
        public void ShowNutrient()
        {

            NutrientDTO Nutdto = new NutrientDTO();
            MealDTO dto = new MealDTO();
            MealDetailDTO MDdto = new MealDetailDTO();
            //dto = mbll.GetMeals();
            if (isSearch) dto = mbll.GetMeals(keyword);
            else dto = mbll.GetMeals();

            dataGridView1.DataSource = dto.Meals;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "食物名稱";
            dataGridView1.Columns["Calories"].HeaderText = "卡路里";
            dataGridView1.Columns["Nutrient"].Visible = false;
            dataGridView1.Columns["NutrientID"].Visible = false;
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

        private void FrmNutrient_Load(object sender, EventArgs e)
        {
            ShowNutrient();
            NutrientComboBox_Load();
        }
        MealDetailDTO dto = new MealDetailDTO();
        
        private void NutrientComboBox_Load()
        {
            NutrientComboBox.Items.Add("脂肪");
            NutrientComboBox.Items.Add("蛋白質");
            NutrientComboBox.Items.Add("碳水化合物");
            NutrientComboBox.Items.Add("醣");
            NutrientComboBox.Items.Add("維生素A");
            NutrientComboBox.Items.Add("維生素B");
            NutrientComboBox.Items.Add("維生素C");
            NutrientComboBox.Items.Add("維生素D");
            NutrientComboBox.Items.Add("維生素E");
            NutrientComboBox.Items.Add("鈉");
            NutrientComboBox.Items.Add("鉀");
        }
        NutrientDAO dao = new NutrientDAO();
        NutrientBLL bll = new NutrientBLL();
        //public void button2_Click(object sender, EventArgs e)
        //{
        //    string ComboBox_select = NutrientComboBox.SelectedItem.ToString();

        //    dataGridView1.DataSource = bll.selectNutrient(ComboBox_select);
        //}

        private void NutrientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ComboBox_select = NutrientComboBox.SelectedItem.ToString();

            dataGridView1.DataSource = bll.selectNutrient(ComboBox_select);
        }
    }
}
