using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessClub.BackEnd.BLL;
using XxxFitnessClub.BackEnd.DAL.DTO;
using XxxFitnessCLub;

namespace XxxFitnessClub.BackEnd
{
    public partial class BSFrmAddMember : Form
    {
        bool emailFlag, pwdFlag, nameFlag, idFlag = false;
        private BSFrmMember memberForm;
        public BSFrmAddMember(BSFrmMember _memberForm)
        {
            memberForm = _memberForm;
            InitializeComponent();
        }
        public bool IsUpdate = false;
        public MemberDetailDTO detail = new MemberDetailDTO();
        public MemberDTO dto = new MemberDTO();
        MemberBLL bll = new MemberBLL();
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmAddMember_Load(object sender, EventArgs e)
        {
            LoadcomboBox();
            
            if (IsUpdate)
            {
                btnAdd.Text = "修改";
                btnAdd.BackColor = Color.LightSkyBlue;
                lbTitle.Text = "修改會員資料頁面";
                txtName.Text = detail.Name;
                txtEmail.Text = detail.Email;
                txtPhone.Text = detail.Phone;
                dpBirth.Value = detail.Birthdate;
                rbMale.Checked = detail.Gender;
                rbFemale.Checked = !detail.Gender;
                cbIsAdmin.Checked = detail.IsAdmin;
                cmbStatus.SelectedValue = detail.StatusID;
                txtHeight.Text = detail.Height.ToString();
                txtTaiwanID.Text = detail.TaiwanID;
                txtPassword.Text = detail.Password;
                txtTaiwanID.Enabled = false;
                emailFlag = true;
                pwdFlag = true;
                nameFlag = true;
                idFlag = true;
            }
            else
            {
                lbStatus.Visible = false;
                cmbStatus.Visible = false;
            }
        }

        private void LoadcomboBox()
        {
            cmbActivities.DataSource = dto.ActivityLevels;
            cmbActivities.DisplayMember = "Description";
            cmbActivities.ValueMember = "ID";
            if (IsUpdate)
            {
                cmbStatus.DataSource = dto.Statuses;
                cmbStatus.DisplayMember = "Description";
                cmbStatus.ValueMember = "ID";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" ||
                txtEmail.Text == "" ||
                txtPhone.Text == "" ||
                dpBirth.Value == DateTime.Now ||
                txtPassword.Text == "" ||
                (!rbMale.Checked && !rbFemale.Checked) ||
                txtHeight.Text == "" ||
                cmbActivities.SelectedIndex == -1 ||
                txtTaiwanID.Text == ""
                )
            {
                MessageBox.Show("請填寫所有欄位");
            }
            else if (!emailFlag ||!pwdFlag || !nameFlag || !idFlag)
            {
                MessageBox.Show("請確認欄位格式是否正確");
            }
            else
            {
                detail.Name = txtName.Text;
                detail.Email = txtEmail.Text;
                detail.Phone = txtPhone.Text;
                detail.Birthdate = dpBirth.Value.Date;
                detail.Password = txtPassword.Text;
                if (rbMale.Checked)
                {
                    detail.Gender = true;
                }
                else
                {
                    detail.Gender = false;
                }
                detail.TaiwanID = txtTaiwanID.Text;
                detail.Height = Convert.ToInt32(txtHeight.Text);
                detail.ActivityLevelID = Convert.ToInt32(cmbActivities.SelectedValue);
                detail.IsAdmin = cbIsAdmin.Checked;
                if (IsUpdate)
                {
                    detail.StatusID = Convert.ToInt32(cmbStatus.SelectedValue);
                    bll.Update(detail);
                    MessageBox.Show("已更新會員資料");
                    this.Close();
                }
                else
                {
                    detail.JoinDate = DateTime.Now;
                    detail.StatusID = General.Status.active;
                    if (bll.Add(detail))
                    {
                        MessageBox.Show("已新增會員");
                        this.Close();
                    }
                }
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                lbName.Text = "姓名不能空白";
                nameFlag = false;
            }
            else
            {
                nameFlag = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void FrmAddMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            memberForm.ShowMembers();
        }

        private void txtTaiwanID_Leave(object sender, EventArgs e)
        {
            Regex rule = new Regex(@"^[A-Z]{1}\d{9}$");
            if (txtTaiwanID.Text == "")
            {
                lbTaiwanID.Text = "身分證不能空白";
                idFlag = false;
            }
            else if (!rule.IsMatch(txtTaiwanID.Text))
            {
                lbTaiwanID.Text = "身分證格式錯誤";
                idFlag = false;
            }
            else if (bll.IsTaiwanIDExist(txtTaiwanID.Text) && !IsUpdate)
            {
                lbTaiwanID.Text = "該身份證字號已被註冊";
                idFlag = false;
            }
            else
            {
                lbTaiwanID.Text = "OK";
                idFlag = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                lbPwd.Text = "密碼不能空白";
                pwdFlag = false;
            }
            else if (bll.IsPwdExist(txtPassword.Text) && !IsUpdate)
            {
                lbPwd.Text = "密碼已有人使用";
                pwdFlag = false;
            }
            else
            {
                lbPwd.Text = "OK";
                pwdFlag = true;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                lbEmail.Text = "Email不能空白";
                emailFlag = false;
            }
            else if (bll.IsEmailExist(txtEmail.Text) && !IsUpdate)
            {
                lbEmail.Text = "該Email已被註冊";
                emailFlag = false;
            }
            else {
                try
                {
                    var addr = new MailAddress(txtEmail.Text);
                    if (addr.Address == txtEmail.Text)
                    {
                        lbEmail.Text = "OK";
                        emailFlag = true;
                    }
                }
                catch 
                {
                    lbEmail.Text = "Email格式不正確";
                    emailFlag = false;
                }
            }
        }
    }
}
