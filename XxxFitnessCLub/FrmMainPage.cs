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

namespace XxxFitnessCLub
{
    
    public partial class FrmMainPage : Form
    {
        public FrmMainPage()
        {
            InitializeComponent();
        }

        private void FrmMainPage_Load(object sender, EventArgs e)
        private void btnMember_Click(object sender, EventArgs e)
        {
            FrmHome frm = new FrmHome();
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

        //回首頁
        private void btnHomePage_Click(object sender, EventArgs e)
        private void button6_Click(object sender, EventArgs e)
        {
            FrmGiftCard f = new FrmGiftCard();
            f.ShowDialog();
        }

            FrmHome frm = new FrmHome();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        private void button15_Click(object sender, EventArgs e)
        {
            
             FrmMealWorkoutHistory f = new FrmMealWorkoutHistory();
            f.Show();
        }

        //會員資料
        private void btnMemberPage_Click(object sender, EventArgs e)
        private void button14_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmStartAProgram f = new FrmStartAProgram();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmRules f = new FrmRules();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMealLog f = new FrmMealLog();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmWorkoutSuggestions f = new FrmWorkoutSuggestions();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmWorkoutLog f = new FrmWorkoutLog();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMemberProfile f = new FrmMemberProfile();
            f.TopLevel = false;
            f.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(f);
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        //紀錄飲食
        private void btnMealPage_Click(object sender, EventArgs e)
        private void button10_Click_1(object sender, EventArgs e)
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
        private void button11_Click(object sender, EventArgs e)
        {
            FrmMealLog f = new FrmMealLog();
            f.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

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
        private void button16_Click(object sender, EventArgs e)
        {
            FrmWorkoutSuggestions f = new FrmWorkoutSuggestions();
            f.Show();
        }

        //吃過動過
        private void button15_Click(object sender, EventArgs e)
        private void btnComment_Click(object sender, EventArgs e)
        {

            FrmMealWorkoutHistory f = new FrmMealWorkoutHistory();
            f.Show();
        }
            FrmComment frm = new FrmComment();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            
        //禮物卡
        private void button6_Click(object sender, EventArgs e)
        {
            FrmGiftCard f = new FrmGiftCard();
            f.ShowDialog();
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
        
        //我的表現
        private void button14_Click(object sender, EventArgs e)
        MemberDetailDTO memberDetail = new MemberDetailDTO();
        MemberBLL memberBLL = new MemberBLL();
        private void FrmMainPage_Load(object sender, EventArgs e)
        {
            // todo 我的表現
        }
            
        //開始計畫
        private void button7_Click(object sender, EventArgs e)
        {
            FrmStartAProgram f = new FrmStartAProgram();
            f.Show();
            memberDetail = memberBLL.GetMember(UserStatic.UserID);
            lblUser.Text = "Welcome back, " + UserStatic.UserName + "!";
        }
    }
}
