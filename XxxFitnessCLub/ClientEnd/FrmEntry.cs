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
using XxxFitnessCLub.ClientEnd;
using XxxFitnessCLub.ClientEnd.BLL;

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
                    FrmMainPage f = new FrmMainPage();
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
