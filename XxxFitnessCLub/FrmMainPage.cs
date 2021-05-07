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
        MemberDetailDTO memberDetail = new MemberDetailDTO();
        MemberBLL memberBLL = new MemberBLL();

        public FrmMainPage()
        {
            InitializeComponent();
        }

        private void FrmMainPage_Load(object sender, EventArgs e) 
        {
            
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
        private void button16_Click(object sender, EventArgs e)
        {
            FrmWorkoutSuggestions f = new FrmWorkoutSuggestions();
            f.Show();
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
    }
}
