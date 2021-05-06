﻿using HHFirstDraft;
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

        private void button8_Click(object sender, EventArgs e)
        {
            //Form1 f = new Form1();
            //f.TopLevel = false;
            //f.AutoScroll = true;
            //this.splitContainer2.Panel2.Controls.Add(f);
            //f.FormBorderStyle = FormBorderStyle.None;
            //f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmGiftCard f = new FrmGiftCard();
            f.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
             FrmMealWorkoutHistory f = new FrmMealWorkoutHistory();
            f.Show();
        }

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
            f.Show();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
        }

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
            frm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FrmWorkoutSuggestions f = new FrmWorkoutSuggestions();
            f.Show();
        }
    }
}
