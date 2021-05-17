using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XxxFitnessClub.BackEnd
{
    public partial class BSFrmMain : Form
    {
        public BSFrmMain()
        {
            InitializeComponent();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            BSFrmMember frm = new BSFrmMember();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btnWorkout_Click(object sender, EventArgs e)
        {
            BSFrmWorkout frm = new BSFrmWorkout();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btnMeal_Click(object sender, EventArgs e)
        {
            BSFrmMeal frm = new BSFrmMeal();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnTag_Click(object sender, EventArgs e)
        {
            BSFrmTag frm = new BSFrmTag();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            BSFrmAddWorkoutCat frm = new BSFrmAddWorkoutCat();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btnSportLog_Click(object sender, EventArgs e)
        {
            BSFrmWorkoutLog frm = new BSFrmWorkoutLog();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BSFrmNutrient frm = new BSFrmNutrient();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            BSFrmComment frm = new BSFrmComment();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void btnWeightLog_Click(object sender, EventArgs e)
        {
            BSFrmWeightLog frm = new BSFrmWeightLog();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
    }
}
