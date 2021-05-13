using HHFirstDraft;
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
using XxxFitnessCLub;

namespace HHFirstDraft
{
    
    public partial class FrmMainPage : Form
    {
        MemberDetailDTO memberDetail = new MemberDetailDTO();
        MemberBLL memberBLL = new MemberBLL();

        public FrmMainPage()
        {
            InitializeComponent();
        }

        //恩旗
        private void FrmMainPage_Load(object sender, EventArgs e) 
        {
            
            this.lblUser.Text += UserStatic.UserName;

            FrmHome frm = new FrmHome();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        //回首頁
        private void btnHomePage_Click(object sender, EventArgs e)
        {
            FrmHome frm = new FrmHome();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        //會員資料
        private void btnMember_Click(object sender, EventArgs e)
        {
            //恩旗
            memberDetail = memberBLL.GetMember(UserStatic.UserID);

            //this.Controls.Clear();
            FrmAddMember frm = new FrmAddMember();
            frm.TopLevel = false;
            frm.isUpdate = true;
            frm.detail = memberDetail;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        //紀錄飲食
        private void btnMealPage_Click(object sender, EventArgs e)
        {
            FrmMealLog frm = new FrmMealLog();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        //運動Log
        private void btnWorkoutLogPage_Click(object sender, EventArgs e)
        {
            FrmWorkoutLog frm = new FrmWorkoutLog();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        //專屬運動推薦
        private void btnWSuggestion_Click(object sender, EventArgs e)
        {
            FrmWorkoutSuggestions frm = new FrmWorkoutSuggestions();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        //吃過動過
        private void button15_Click(object sender, EventArgs e)
        {
            FrmMealWorkoutHistory f = new FrmMealWorkoutHistory();
            f.Show();
        }

        //留言板
        private void btnComment_Click(object sender, EventArgs e)
        {
            FrmComment frm = new FrmComment();
            frm.TopLevel = false;
            frm.AutoScroll = true;

            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
        
        //禮物卡
        private void button6_Click(object sender, EventArgs e)
        {
            FrmGiftCard frm = new FrmGiftCard();
            frm.ShowDialog();
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        //我的表現
        private void button14_Click(object sender, EventArgs e)
        {

        }

        //開始計畫
        private void button7_Click(object sender, EventArgs e)
        {
            FrmStartAProgram f = new FrmStartAProgram();
            f.Show();
            memberDetail = memberBLL.GetMember(UserStatic.UserID);
            lblUser.Text = "Welcome back, " + UserStatic.UserName + "!";
        }

        //遊戲規則
        private void button4_Click(object sender, EventArgs e)
        {
            FrmRules f = new FrmRules();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmNutrient frm = new FrmNutrient();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmNutrient_lbl frm = new FrmNutrient_lbl();
          
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                FrmAllNutrientOfDay frm = new FrmAllNutrientOfDay();

            frm.Show();
        }
    }
}
