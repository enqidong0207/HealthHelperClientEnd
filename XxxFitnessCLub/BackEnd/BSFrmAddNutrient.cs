using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessClub.BackEnd.BLL;
using XxxFitnessClub.BackEnd.DAL.DTO;

namespace XxxFitnessClub.BackEnd
{
    public partial class BSFrmAddNutrient : Form
    {
        public bool IsUpdate = false;
        public string mealName;
        public string mealCalories;
        //public FrmAddNutrient()
        //{
        //    InitializeComponent();
        //}
        private BSFrmNutrient frmNutrientFrom;
        public BSFrmAddNutrient(BSFrmNutrient _FrmAddNutrient)
        {
            frmNutrientFrom = _FrmAddNutrient;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (IsUpdate)
            {
                lbTitle.Text = "修改餐點營養項目";
                btnAdd.Text = "修改";
                lblMealName.Text = mealName;
                lblMealCalories.Text = mealCalories;

            }
        }
        NutrientBLL bll = new NutrientBLL();
        public NutrientDTO dto = new NutrientDTO();
        public MealDetailDTO detail = new MealDetailDTO();
        public int selectNutrientID;

        public NutrientDTO Ndto = new NutrientDTO();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dto.ID = detail.NutrientID;
            dto.Fat = float.Parse(txtFat.Text);
            dto.Protein = float.Parse(txtProtein.Text);
            dto.Carbs = float.Parse(txtCarbs.Text);
            dto.Sugar = float.Parse(txtSugar.Text);
            dto.VitA = float.Parse(txtVitA.Text);
            dto.VitB = float.Parse(txtVitB.Text);
            dto.VitC = float.Parse(txtVitC.Text);
            dto.VitD = float.Parse(txtVitD.Text);
            dto.VitE = float.Parse(txtVitE.Text);
            dto.Na = float.Parse(txtNa.Text);
            dto.K = float.Parse(txtK.Text);

            bll.Update(dto);

            
            this.Close();


            //detail.NutrientID = Convert.ToInt32(bll.GetNutrientLastID());

            //if (IsUpdate)
            //{
            //    int mealID = detail.ID;
            //    for (int i = 0; i < clbTag.Items.Count; i++)
            //    {
            //        TagCategoryDetailDTO dto = clbTag.Items[i] as TagCategoryDetailDTO;
            //        int categoryID = dto.ID;
            //        if (clbTag.GetItemChecked(i)) // Checked.
            //        {
            //            if (!bll.HasTag(mealID, categoryID)) // Had not been checked.
            //            {
            //                bll.AddTag(mealID, categoryID); // Check it!
            //            }
            //        }
            //        else // Not checked.
            //        {
            //            if (bll.HasTag(mealID, categoryID)) // But it WAS checked.
            //            {
            //                bll.RemoveTag(mealID, categoryID); // Uncheck it.
            //            }
            //        }
            //    }
            //    //detail.Tags = bll.GetTagsWithMealID(mealID);
            //    bll.Update(detail);

        }

        private void FrmAddNutrient_Load(object sender, EventArgs e)
        {
            txtFat.Text = detail.Fat.ToString();
            txtProtein.Text = detail.Protein.ToString();
            txtCarbs.Text = detail.Carbs.ToString();
            txtSugar.Text = detail.Sugar.ToString();
            txtVitA.Text = detail.VitA.ToString();
            txtVitB.Text = detail.VitB.ToString();
            txtVitC.Text = detail.VitC.ToString();
            txtVitD.Text = detail.VitD.ToString();
            txtVitE.Text = detail.VitE.ToString();
            txtNa.Text = detail.Na.ToString();
            txtK.Text = detail.K.ToString();
            
        }

        private void FrmAddNutrient_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNutrientFrom.ShowNutrient();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

