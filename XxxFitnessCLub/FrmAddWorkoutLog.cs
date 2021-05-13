using HHFirstDraft.BLL;
using HHFirstDraft.DAL;
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
using XxxFitnessCLub.DAL;

namespace HHFirstDraft
{
    public partial class FrmAddWorkoutLog : Form
    {
        private FrmWorkoutLog workoutLogForm;
        private WorkoutCategoryBLL wcBll = new WorkoutCategoryBLL();
        private WorkoutLogBLL wlBll = new WorkoutLogBLL();
        private WorkoutBLL wBll = new WorkoutBLL();
        private ActivityLevelBLL alBll = new ActivityLevelBLL();

        private DateTime oneMonthAgo = new DateTime(2021, 4, 1);

        public FrmAddWorkoutLog(FrmWorkoutLog _workoutLogForm)
        {
            workoutLogForm = _workoutLogForm;
            InitializeComponent();

            this.lblWorkoutCategoryTest.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAddWorkoutLog_Load(object sender, EventArgs e)
        {
            LoadComboBox();

            this.cmbWorkoutCategory.SelectedIndexChanged += this.cmbs_SelectedIndexChanged;
            this.cmbActivityLevel.SelectedIndexChanged += this.cmbs_SelectedIndexChanged;
        }

        private void LoadComboBox()
        {   
            List<WorkoutCategoryDetailDTO> wcList = wcBll.GetCategories();
            wcList.Insert(0, new WorkoutCategoryDetailDTO
            {
                Name = "全部類別",
                ID = -1
            });

            this.cmbWorkoutCategory.DisplayMember = "Name";
            this.cmbWorkoutCategory.ValueMember = "ID";
            this.cmbWorkoutCategory.DataSource = wcList;

            List<ActivityLevelDetailDTO> alList = alBll.GetActivityLevels().OrderBy(e => e.ID).ToList();
            alList.Insert(0, new ActivityLevelDetailDTO
            {
                Description = "全部強度",
                ID = -1
            });

            this.cmbActivityLevel.DisplayMember = "Description";
            this.cmbActivityLevel.ValueMember = "ID";
            this.cmbActivityLevel.DataSource = alList;

            List<WorkoutDetailDTO> wList = wBll.GetWorkoutByWCAL();

            this.cmbWorkout.DisplayMember = "Name";
            this.cmbWorkout.ValueMember = "ID";
            this.cmbWorkout.DataSource = wList;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            oneMonthAgo = oneMonthAgo.AddDays(1);
            // todo
            if (!double.TryParse(this.txtWorkoutHours.Text, out double workoutHours))
            {
                this.lblWorkoutCategoryTest.Text = "請輸入數字";
                return;
            }
            else
            {
                this.lblWorkoutCategoryTest.Text = "";
            }

            bool isSuccess = wlBll.Add(new WorkoutLog 
            { 
                MemberID = 3,
                WorkoutID = (int)this.cmbWorkout.SelectedValue,
                EditTime = oneMonthAgo,
                WorkoutHours = workoutHours
            });

            if (isSuccess)
            {
                MessageBox.Show("新增成功");
            }
            else
            {
                MessageBox.Show("新增失敗");
            }
        }

        private void txtCalories_KeyPress(object sender, KeyPressEventArgs e)
        {
            // todo
            //e.Handled = General.isNumber(e);
        }

        private void FrmAddWorkout_FormClosed(object sender, FormClosedEventArgs e)
        {
            workoutLogForm.ShowWorkoutLog();
        }

        private void cmbs_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbWorkout.DisplayMember = "Name";
            this.cmbWorkout.ValueMember = "ID";

            List<WorkoutDetailDTO> list = wBll.GetWorkoutByWCAL((int)this.cmbWorkoutCategory.SelectedValue, (int)this.cmbActivityLevel.SelectedValue);
            if (list.Count == 0)
            {
                this.cmbWorkout.DataSource = null;
            }
            else
            {
                this.cmbWorkout.DataSource = list;
            }
        }
    }
}
