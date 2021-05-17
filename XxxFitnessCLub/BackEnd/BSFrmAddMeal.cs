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
    public partial class BSFrmAddMeal : Form
    {
        private BSFrmMeal mealForm;
        public byte[] bytes1;
        public BSFrmAddMeal(BSFrmMeal _mealForm)
        {
            mealForm = _mealForm;
            InitializeComponent();

        }
        MealBLL bll = new MealBLL();
        public MealDetailDTO detail = new MealDetailDTO();
        public bool IsUpdate = false;
        public NutrientBLL nbll = new NutrientBLL();
        public NutrientDTO ndto = new NutrientDTO();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtCalories.Text == "")
            {
                MessageBox.Show("請輸入所有欄位");
            }
            else
            {
                byte[] bytes;
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bytes = ms.GetBuffer();
                detail.Image = bytes;


                detail.Name = txtName.Text;
                detail.Calories = Convert.ToInt32(txtCalories.Text);
                ndto.Fat = float.Parse(txtFat.Text);
                ndto.Protein = float.Parse(txtProtein.Text);
                ndto.Carbs = float.Parse(txtCarbs.Text);
                ndto.Sugar = float.Parse(txtSugar.Text);
                ndto.VitA = float.Parse(txtVitA.Text);
                ndto.VitB = float.Parse(txtVitB.Text);
                ndto.VitC = float.Parse(txtVitC.Text);
                ndto.VitD = float.Parse(txtVitD.Text);
                ndto.VitE = float.Parse(txtVitE.Text);
                ndto.Na = float.Parse(txtNa.Text);
                ndto.K = float.Parse(txtK.Text);
                if (IsUpdate)
                {
                    int mealID = detail.ID;
                    for (int i = 0; i < clbTag.Items.Count; i++)
                    {
                        TagCategoryDetailDTO dto = clbTag.Items[i] as TagCategoryDetailDTO;
                        int categoryID = dto.ID;
                        if (clbTag.GetItemChecked(i)) // Checked.
                        {
                            if (!bll.HasTag(mealID, categoryID)) // Had not been checked.
                            {
                                bll.AddTag(mealID, categoryID); // Check it!
                            }
                        }
                        else // Not checked.
                        {
                            if (bll.HasTag(mealID, categoryID)) // But it WAS checked.
                            {
                                bll.RemoveTag(mealID, categoryID); // Uncheck it.
                            }
                        }
                    }
                    //detail.Tags = bll.GetTagsWithMealID(mealID);
                    bll.Update(detail);
                    MessageBox.Show("已更新餐點資訊");

                    this.Close();
                }
                else
                {
                    if (bll.IsMealExist(detail.Name))
                    {
                        MessageBox.Show("餐點名稱已存在");
                    }
                    else
                    {

                        detail.NutrientID = nbll.Add(ndto);
                        detail.Image = bytes;
                        detail.Fat = ndto.Fat;
                        detail.Protein = ndto.Protein;
                        detail.Sugar = ndto.Sugar;
                        detail.Carbs = ndto.Carbs;
                        detail.VitA = ndto.VitA;
                        detail.VitB = ndto.VitB;
                        detail.VitC = ndto.VitC;
                        detail.VitD = ndto.VitD;
                        detail.VitE = ndto.VitE;
                        detail.Na = ndto.Na;
                        detail.K = ndto.K;

                        int mealID = bll.Add(detail);
                        for (int i = 0; i < clbTag.Items.Count; i++)
                        {
                            TagCategoryDetailDTO dto = clbTag.Items[i] as TagCategoryDetailDTO;
                            int categoryID = dto.ID;
                            if (clbTag.GetItemChecked(i)) // Checked.
                            {
                                if (!bll.HasTag(mealID, categoryID)) // Had not been checked.
                                {
                                    bll.AddTag(mealID, categoryID); // Check it!
                                }
                            }
                        }
                        MessageBox.Show("已新增餐點");
                        this.Close();
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        TagCategoryBLL tagBLL = new TagCategoryBLL();
        TagCategoryDTO tagDTO = new TagCategoryDTO();
        private void FrmAddMeal_Load(object sender, EventArgs e)
        {
            tagDTO.TagCategories = tagBLL.GetTags();
            clbTag.DataSource = tagDTO.TagCategories;
            clbTag.DisplayMember = "Name";
            clbTag.ValueMember = "ID";
            if (!IsUpdate)
            {
                txtFat.Text = "0";
                txtCarbs.Text = "0";
                txtProtein.Text = "0";
                txtSugar.Text = "0";
                txtVitA.Text = "0";
                txtVitB.Text = "0";
                txtVitC.Text = "0";
                txtVitD.Text = "0";
                txtVitE.Text = "0";
                txtNa.Text = "0";
                txtK.Text = "0";
            }


            if (IsUpdate)
            {
                lbTitle.Text = "修改餐點頁面";
                btnAdd.Text = "修改";
                System.IO.MemoryStream mss = new System.IO.MemoryStream(bytes1);
                pictureBox1.Image = Image.FromStream(mss);
                btnAdd.BackColor = Color.LightSkyBlue;
                txtName.Text = detail.Name;
                txtCalories.Text = detail.Calories.ToString();
                txtFat.Visible = false;
                txtProtein.Visible = false;
                txtCarbs.Visible = false;
                txtSugar.Visible = false;
                txtVitA.Visible = false;
                txtVitB.Visible = false;
                txtVitC.Visible = false;
                txtVitD.Visible = false;
                txtVitE.Visible = false;
                txtNa.Visible = false;
                txtK.Visible = false;
                labFat.Visible = false;
                labProtein.Visible = false;
                labCarbs.Visible = false;
                labSugar.Visible = false;
                labVitA.Visible = false;
                labVitB.Visible = false;
                labVitC.Visible = false;
                labVitD.Visible = false;
                labVitE.Visible = false;
                labNa.Visible = false;
                labK.Visible = false;
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

                foreach (var item in detail.Tags)
                {
                    int index = clbTag.FindStringExact(item.Name);
                    clbTag.SetItemChecked(index, true);
                }
            }
        }

        private void FrmAddMeal_FormClosed(object sender, FormClosedEventArgs e)
        {
            mealForm.ShowMeals();
        }

        private void btn_img_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
