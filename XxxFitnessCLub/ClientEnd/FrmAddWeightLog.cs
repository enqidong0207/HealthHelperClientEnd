using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub.ClientEnd.BLL;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd
{
    public partial class FrmAddWeightLog : Form
    {
        readonly FrmWeightLog frmWeightLog = new FrmWeightLog();
        public FrmAddWeightLog(FrmWeightLog _frmWeightLog)
        {
            frmWeightLog = _frmWeightLog;
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddWeightLog_Load(object sender, EventArgs e)
        {
            ShowComboBox();
            if (isUpdate)
            {
                lbTitle.Text = "修改體重紀錄";
                btnAdd.Text = "修改";
                btnAdd.BackColor = Color.SkyBlue;
                cmbTime.SelectedItem = detail.UpdatedDate.Date;
                txtWeight.Text = detail.Weight.ToString();
            }
        }
        public bool isUpdate = false;
        private void ShowComboBox()
        {
            DateTime day = DateTime.Today;
            cmbTime.Items.Add(day.Date);
            for (int i = 0; i < 6; i++)
            {
                day = day.AddDays(-1);
                cmbTime.Items.Add(day.Date);
            }
            cmbTime.SelectedIndex = 0;

        }
        readonly WeightLogBLL bll = new WeightLogBLL();
        readonly WeightLogDTO dto = new WeightLogDTO();
        public WeightLogDetailDTO detail = new WeightLogDetailDTO();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            double weight;
            if (double.TryParse(txtWeight.Text, out weight))
            {
                if(isUpdate)
                {
                    DateTime updatedDate = Convert.ToDateTime(cmbTime.SelectedItem);
                    detail.Weight = weight;
                    detail.UpdatedDate = updatedDate;
                    bll.Update(detail);
                    MessageBox.Show("已修改體重記錄");
                    frmWeightLog.ShowWeightLogs();
                    this.Close();
                }
                else
                {
                    DateTime updatedDate = Convert.ToDateTime(cmbTime.SelectedItem);
                    detail.MemberID = UserStatic.UserID;
                    detail.Weight = weight;
                    detail.UpdatedDate = updatedDate;
                    bll.Add(detail);
                    MessageBox.Show("已新增體重記錄");
                    frmWeightLog.ShowWeightLogs();
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("請輸入正確的體重數值");
            }
        }
    }
}
