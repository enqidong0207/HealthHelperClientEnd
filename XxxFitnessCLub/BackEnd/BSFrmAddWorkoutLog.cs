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
    public partial class BSFrmAddWorkoutLog : Form
    {
        public WorkoutLogBLL bll = new WorkoutLogBLL();
        WorkoutBLL workoutBLL = new WorkoutBLL();
        WorkoutDTO workoutDTO = new WorkoutDTO();
        WorkoutDetailDTO detailDTO = new WorkoutDetailDTO();
        public WorkoutLogDTO dto = new WorkoutLogDTO();
        public WorkoutLogDetailDTO detail = new WorkoutLogDetailDTO();
        public bool IsUpdate = false;
        BSFrmWorkoutLog frmWorkoutLog;
        public BSFrmAddWorkoutLog(BSFrmWorkoutLog frmWorkoutLog)
        {
            InitializeComponent();
            this.frmWorkoutLog = frmWorkoutLog;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            detail.MemberID = Convert.ToInt32( txtID.Text);
            detail.MemberName = txtName.Text;
            detail.WorkoutID = Convert.ToInt32(cmbWorkout.SelectedValue);
            detail.WorkoutHours = Convert.ToDouble(txtHours.Text);
            detail.EditTime = DateTime.Now.Date;
            if (txtName.Text == "" || txtID.Text == "" || cmbWorkout.SelectedIndex == -1 || txtHours.Text == "")
            {
                MessageBox.Show("請填寫所有資訊");
                return;

            }
            if (IsUpdate)
            {
                bll.UpDate(detail);
                MessageBox.Show("已修改運動紀錄");
                this.Close();

            }
            else
            {
                if (bll.Add(detail))
                {
                    MessageBox.Show("已加入新運動紀錄");
                   
                    this.Close();
                }                                  
            }
        }
        private void LoadComboBox()
        {
            workoutDTO = workoutBLL.GetWorkouts();
            cmbWorkout.DataSource = workoutDTO.Workouts;
            cmbWorkout.DisplayMember = "Name";
            cmbWorkout.ValueMember = "ID";
            if (IsUpdate)
            {              
                cmbWorkout.SelectedValue = detailDTO.ID;
            }
        }

        private void FrmAddWorkoutLog_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            if (IsUpdate)
            {

                cmbWorkout.SelectedValue = detail.WorkoutID;
                
                //txtName.Text = detail.WorkoutName;
                txtName.Text = detail.MemberName;
                txtName.Enabled = false;
                txtID.Text = detail.MemberID.ToString();
                txtID.Enabled = false;
                txtHours.Text = detail.WorkoutHours.ToString();
                lbTitle.Text = "修改運動紀錄";
                btnAdd.Text = "修改";
                btnAdd.BackColor = Color.LightSkyBlue;

            }
        }

        private void FrmAddWorkoutLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmWorkoutLog.ShowWorkoutLog();
        }
    }
}
