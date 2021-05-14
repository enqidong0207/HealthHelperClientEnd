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
using XxxFitnessCLub.ClientEnd.DAL;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd
{
    //恩旗
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

            if (workoutLogForm.isUpdate)
            {
                this.lbTitle.Text = $"修改運動紀錄\n(原本記錄時間{workoutLogForm.dto.EditTime})";
                this.cmbWorkoutCategory.SelectedValue = workoutLogForm.dto.Workout.WorkoutCategory.ID;
                this.cmbActivityLevel.SelectedValue = workoutLogForm.dto.Workout.ActivityLevel.ID;
                this.cmbWorkout.SelectedValue = workoutLogForm.dto.WorkoutID;
                this.btnAdd.Text = "修改";
                this.btnAdd.BackColor = Color.LightSkyBlue;
            }
            else
            {
                this.lbTitle.Text = "新增運動紀錄";
                this.btnAdd.Text = "新增";
                this.btnAdd.BackColor = Color.PaleTurquoise;
            }

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

            if (!double.TryParse(this.txtWorkoutHours.Text, out double workoutHours) || workoutHours == 0)
            {
                this.lblWorkoutCategoryTest.Text = "請輸入數字且必須大於0";
                return;
            }
            else
            {
                this.lblWorkoutCategoryTest.Text = "";
            }

            bool isSuccess = false;

            if (workoutLogForm.isUpdate)
            {
                isSuccess = wlBll.Edit(new WorkoutLog
                {
                    ID = workoutLogForm.dto.ID,
                    MemberID = UserStatic.UserID,
                    WorkoutID = (int)this.cmbWorkout.SelectedValue,
                    EditTime = DateTime.Now.Date,
                    WorkoutHours = workoutHours
                }); ;

                if (isSuccess)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失敗");
                }
            }
            else
            {
                isSuccess = wlBll.Add(new WorkoutLog
                {
                    MemberID = UserStatic.UserID,
                    WorkoutID = (int)this.cmbWorkout.SelectedValue,
                    EditTime = oneMonthAgo.Date,
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
            
        }

        private void FrmAddWorkout_FormClosed(object sender, FormClosedEventArgs e)
        {
            workoutLogForm.ShowWorkoutLog(workoutLogForm.keyword);
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
