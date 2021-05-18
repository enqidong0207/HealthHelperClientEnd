using HHFirstDraft;
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
using XxxFitnessCLub.ClientEnd.BLL;
using XxxFitnessCLub.ClientEnd.DAL.DTO;
using XxxFitnessCLub.ClientEnd.ToDoFrms;

namespace XxxFitnessCLub.ClientEnd
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
            memberBLL = new MemberBLL(); // refresh

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
            FrmMealHistory frm = new FrmMealHistory();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            
        }

        //留言板
        private void btnComment_Click(object sender, EventArgs e)
        {
            FrmCommentBoard frm = new FrmCommentBoard();
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

        private void btnWeightLog_Click(object sender, EventArgs e)
        {
            FrmWeightLog frm = new FrmWeightLog();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMealHistory frm = new FrmMealHistory();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.splitContainer2.Panel2.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
    }
}
