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
using HHFirstDraft.BLL;
using HHFirstDraft.DAL.DTO;

namespace XxxFitnessCLub
{
    public partial class FrmNutrient_lbl : Form
    {
        public FrmNutrient_lbl()
        {
            InitializeComponent();
        }
        NutrientBLL bll = new NutrientBLL();
        public NutrientDTO dto = new NutrientDTO();
        public MealDetailDTO detail = new MealDetailDTO();
        public int selectNutrientID;
        string keyword;
        bool isSearch = false;
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
            dataGridView1.Columns["Image"].Visible = false;
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

        private void FrmNutrient_lbl_Load(object sender, EventArgs e)
        {
            ShowNutrient();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblFat.Text = dataGridView1.Rows[e.RowIndex].Cells["Fat"].Value.ToString();
            lblPrtein.Text = dataGridView1.Rows[e.RowIndex].Cells["Protein"].Value.ToString();
            lblCarbs.Text = dataGridView1.Rows[e.RowIndex].Cells["Carbs"].Value.ToString();
            lblSugar.Text = dataGridView1.Rows[e.RowIndex].Cells["Sugar"].Value.ToString();
            lblVitA.Text = dataGridView1.Rows[e.RowIndex].Cells["VitA"].Value.ToString();
            lblVitB.Text = dataGridView1.Rows[e.RowIndex].Cells["VitB"].Value.ToString();
            lblVitC.Text = dataGridView1.Rows[e.RowIndex].Cells["VitC"].Value.ToString();
            lblVitD.Text = dataGridView1.Rows[e.RowIndex].Cells["VitD"].Value.ToString();
            lblVitE.Text = dataGridView1.Rows[e.RowIndex].Cells["VitE"].Value.ToString();
            lblNa.Text =dataGridView1.Rows[e.RowIndex].Cells["Na"].Value.ToString();
            lblK.Text =dataGridView1.Rows[e.RowIndex].Cells["K"].Value.ToString();
        }
    }
}
