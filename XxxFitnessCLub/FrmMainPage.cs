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

namespace XxxFitnessCLub
{
    
    public partial class FrmMainPage : Form
    {
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
        private void btnMemberPage_Click(object sender, EventArgs e)
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

        //禮物卡
        private void button6_Click(object sender, EventArgs e)
        {
            FrmGiftCard f = new FrmGiftCard();
            f.ShowDialog();
        }
        
        //我的表現
        private void button14_Click(object sender, EventArgs e)
        {
            // todo 我的表現
        }

        //開始計畫
        private void button7_Click(object sender, EventArgs e)
        {
            FrmStartAProgram f = new FrmStartAProgram();
            f.Show();
        }
    }
}
