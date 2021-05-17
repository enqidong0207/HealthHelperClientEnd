using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessClub.BackEnd.BLL;
using XxxFitnessClub.BackEnd.DAL.DTO;

namespace XxxFitnessClub.BackEnd
{
    public partial class BSFrmAddWeightLog : Form
    {
        private BSFrmWeightLog frmWeightLog;
        public BSFrmAddWeightLog(BSFrmWeightLog _frmWeightLog)
        {
            frmWeightLog = _frmWeightLog;
            InitializeComponent();
        }
        MemberBLL memberBLL = new MemberBLL();
        MemberDTO memberDTO = new MemberDTO();
        private void FrmAddWeightLog_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            if (isUpdate)
            {
                cmbMembers.SelectedValue = detail.MemberID;
                txtWeight.Text = detail.Weight.ToString();
                lbTitle.Text = "修改體重記錄";
                btnAdd.Text = "修改";
                btnAdd.BackColor = Color.SkyBlue;
            }
        }
        
        private void LoadComboBox()
        {
            memberDTO = memberBLL.GetMembers();
            cmbMembers.DataSource = memberDTO.Members;
            cmbMembers.DisplayMember = "Name";
            cmbMembers.ValueMember = "ID";
            cmbMembers.SelectedIndex = -1;
            DateTime day = DateTime.Today;
            cmbTime.Items.Add(day.Date);
            for (int i = 0; i < 6; i++)
            {
                day = day.AddDays(-1);
                cmbTime.Items.Add(day.Date);
            }
            cmbTime.SelectedIndex = 0;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        WeightLogBLL bll = new WeightLogBLL();
        WeightLogDTO dto = new WeightLogDTO();
        public WeightLogDetailDTO detail = new WeightLogDetailDTO();
        public bool isUpdate = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            double parsedWeight;
            if (cmbMembers.SelectedIndex == -1 || txtWeight.Text == "")
            {
                MessageBox.Show("請輸入所有欄位");
            }
            else if (!double.TryParse(txtWeight.Text, out parsedWeight))
            {
                MessageBox.Show("請輸入正確的體重數值");
            }
            else
            {
                detail.MemberID = Convert.ToInt32(cmbMembers.SelectedValue);
                detail.Weight = parsedWeight;
                if (isUpdate)
                {
                    bll.Update(detail);
                    MessageBox.Show("已修改體重紀錄");
                    frmWeightLog.ShowWeightLogs();
                    this.Close();
                }
                else
                {
                    detail.UpdatedDate = Convert.ToDateTime(cmbTime.SelectedItem);
                    bll.Add(detail);
                    MessageBox.Show("已新增體重記錄");
                    frmWeightLog.ShowWeightLogs();
                    this.Close();
                }
                
            }
        }
    }
}
