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
    public partial class BSFrmEditWorkoutCat : Form
    {
        private BSFrmAddWorkoutCat frmWorkoutcat;
        WorkoutCategoryBLL bll = new WorkoutCategoryBLL();
        WorkoutCategoryDTO dto = new WorkoutCategoryDTO();
        public WorkoutCategoryDetailDTO detail = new WorkoutCategoryDetailDTO();
        public BSFrmEditWorkoutCat(BSFrmAddWorkoutCat workoutCat)
        {
            frmWorkoutcat = workoutCat;
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if (textBox2.Text == "")
            {
                MessageBox.Show("名稱不得為空白");
            }
            else if (textBox2.Text == textBox1.Name)
            {
                MessageBox.Show("若欲修改，請輸入一個新的名稱");
            }
            else if (bll.IsCategoryExist(textBox2.Text))
            {
                MessageBox.Show("該類別名稱已存在");
            }
            else
            {

                DialogResult DR = MessageBox.Show($"{textBox1.Text}將變更為{textBox2.Text}?", "確認訊息!", MessageBoxButtons.YesNo);
                if (DR == DialogResult.Yes)
                {
                    detail.Name = textBox2.Text;
                    bll.Update(detail);
                    MessageBox.Show("已修改類別名稱");
                    frmWorkoutcat.ShowWorkoutCat();
                    this.Close();
                }
            }
        }

        private void FrmEditWorkoutCat_Load(object sender, EventArgs e)
        {
            textBox1.Text = detail.Name;
            textBox1.Enabled = false;
        }
    }
}
