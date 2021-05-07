﻿using HHFirstDraft.BLL;
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
    public partial class FrmEntry : Form
    {
        public FrmEntry()
        {
            InitializeComponent();
        }
        MemberBLL memberBLL = new MemberBLL();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            int userID = memberBLL.IsMemberExist(txtName.Text, txtPassword.Text);
            
            if (userID != 0) // Found a user!
            {
                UserStatic.UserID = userID;
                UserStatic.UserName = txtName.Text;
                MessageBox.Show("歡迎進入進康管理系統, " + UserStatic.UserName);
                FrmMainPage f = new FrmMainPage();
                f.Show();
            }
            else
            {
                MessageBox.Show("帳戶不存在");
            }
           
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            FrmAddMember frm = new FrmAddMember();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            this.Controls.Add(frm);
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
            this.txtName.Clear();
        }

        private void FrmEntry_Load(object sender, EventArgs e)
        {
            
        }
    }
}