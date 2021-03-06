using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessClub.BackEnd;
using XxxFitnessCLub.ClientEnd;
using XxxFitnessCLub.ClientEnd.BLL;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd
{
    public partial class FrmEntry : Form
    {
        public FrmEntry()
        {
            InitializeComponent();
        }
        MemberBLL memberBLL = new MemberBLL();
        MemberDetailDTO memberDetailDTO = new MemberDetailDTO();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            int userID = memberBLL.IsMemberExist(txtName.Text, txtPassword.Text);
            memberDetailDTO = memberBLL.GetMember(userID);
            if (memberDetailDTO == null)
            {
                MessageBox.Show("帳戶不存在");
                return;
            }
            if (memberDetailDTO.StatusID == General.Status.locked)
            {
                MessageBox.Show("帳戶已凍結，請聯絡管理員");
                return;
            }
            if (userID == 0)
            {
                MessageBox.Show("帳戶不存在");
            }
            else
            {
                memberDetailDTO = memberBLL.GetMember(userID);
                if (!memberDetailDTO.IsAdmin) // A user who is not an administrator.
                {
                    UserStatic.UserID = userID;
                    UserStatic.UserName = txtName.Text;
                    MessageBox.Show("歡迎進入進康管理系統, " + UserStatic.UserName);

                    //恩旗
                    this.Hide();
                    FrmMainPage f = new FrmMainPage();
                    f.Closed += (s, args) => this.Close();
                    f.Show();
                }
                else if (memberDetailDTO.IsAdmin) // An administrator.
                {
                    UserStatic.UserID = userID;
                    UserStatic.UserName = txtName.Text;
                    MessageBox.Show("歡迎進入進康管理後臺系統, 管理者" + UserStatic.UserName);

                    //恩旗
                    this.Hide();
                    BSFrmMain f = new BSFrmMain();
                    f.Closed += (s, args) => this.Close();
                    f.Show();
                }
                else
                {
                    MessageBox.Show("帳戶不存在");
                }
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
            this.txtPassword.Clear();
        }
    }
}
