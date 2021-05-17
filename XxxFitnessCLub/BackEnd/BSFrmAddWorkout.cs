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
    public partial class BSFrmAddWorkout : Form
    {
        private BSFrmWorkout workoutForm;
        public BSFrmAddWorkout(BSFrmWorkout _workoutForm)
        {
            workoutForm = _workoutForm;
            InitializeComponent();
        }
        public WorkoutDTO dto = new WorkoutDTO();
        public bool IsUpdate = false;
        public WorkoutDetailDTO detail = new WorkoutDetailDTO();
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddWorkout_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            if (IsUpdate)
            {
                txtName.Text = detail.Name;
                txtCalories.Text = detail.Calories.ToString();
                lbTitle.Text = "修改運動項目";
                btnAdd.Text = "修改";
                btnAdd.BackColor = Color.LightSkyBlue;
            }
        }

        private void LoadComboBox()
        {
            cmbLevel.DataSource = dto.ActivityLevels;
            cmbLevel.DisplayMember = "Description";
            cmbLevel.ValueMember = "ID";
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "ID";
            if (IsUpdate)
            {
                cmbLevel.SelectedValue = detail.ActivityLevelID;
                cmbCategory.SelectedValue = detail.CategoryID;

            }


        }
        WorkoutBLL bll = new WorkoutBLL();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            detail.Name = txtName.Text;
            detail.Calories = Convert.ToInt32(txtCalories.Text);
            detail.ActivityLevelID = Convert.ToInt32(cmbLevel.SelectedValue);
            detail.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
            if (txtName.Text == "" || txtCalories.Text == "" || cmbLevel.SelectedIndex == -1 || cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("請填寫所有資訊");
                return;

            }
            if (IsUpdate)
            {
                bll.Update(detail);
                MessageBox.Show("已修改運動項目");
                this.Close();

            }
            else
            {
                if (bll.IsWorkoutExist(detail.Name))
                {
                    MessageBox.Show("該運動名稱已存在");

                }
                else 
                {
                    if (bll.Add(detail))
                    {
                        MessageBox.Show("已加入新運動項目");
                        this.Close();
                    }
                    
                }
            }
           
        }

        private void txtCalories_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void FrmAddWorkout_FormClosed(object sender, FormClosedEventArgs e)
        {
            workoutForm.ShowWorkouts();
        }
    }
}
