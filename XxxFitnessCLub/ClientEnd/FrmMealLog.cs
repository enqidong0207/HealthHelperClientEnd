using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub.ClientEnd.BLL;
using XxxFitnessCLub.ClientEnd.DAL.DTO;
using XxxFitnessCLub.ClientEnd.ViewModel;

namespace XxxFitnessCLub.ClientEnd
{
    public partial class FrmMealLog : Form
    {

        MealBLL mBll = new MealBLL();
        TimesOfDayBLL tBll = new TimesOfDayBLL();
        DietLogBLL dBll = new DietLogBLL();
        public List<DietLogDTO> mealList = new List<DietLogDTO>();

        MyCircleProgress[] cBars;
        public FrmMealLog()
        {
            InitializeComponent();
            LoadTimeOfDay();
            this.cBoxKeyWord.SelectedIndexChanged += CBoxKeyWord_SelectedIndexChanged;            
            this.cBoxKeyWord.TextChanged += CBoxKeyWord_TextChanged;
            this.tBoxPortion.GotFocus += TBoxPortion_GotFocus;          
            this.DGVAddedMeals.DataSource = bS_AddedMeals;
            this.DGVRecordOfToday.DataSource = bS_RecordOfToday;
            //========================================
            
            

            //====================================
            this.dateTimePicker1.MinDate = DateTime.Today.AddDays(-6);
            this.dateTimePicker1.MaxDate = DateTime.Today;
            this.pBarDailyGain.Minimum = 0; 
            this.pBarDailyGain.Maximum = StaticUser.TBLL;
            //============================================
            myCProParBf.timeOfDayName = "早餐";
            myCProParLn.timeOfDayName = "午餐";
            myCProParDn.timeOfDayName = "晚餐";
            myCProParSn.timeOfDayName = "點心";
            myCProParBedSn.timeOfDayName = "宵夜";

             cBars =new MyCircleProgress[] { myCProParBf,myCProParLn,myCProParDn,myCProParSn,myCProParBedSn};

            //====================================================
            bS_RecordOfToday.DataSource = dBll.GetDietLogHistory(DateTime.Today);
            

        }

        private void LoadTimeOfDay()
        {
            this.cBoxTimesOfDay.DataSource = tBll.GetTimesOfDay();
            this.cBoxTimesOfDay.DisplayMember = "Name";
        }
        private void FrmMealLog_Shown(object sender, EventArgs e)
        {
            DefaultCircleProgressBars(cBars);
            RefreshDailyProgressBar(DateTime.Today);
        }


        //==================================
        private void DefaultCircleProgressBars(MyCircleProgress[] cBars)  //重0跑
        {
            foreach (MyCircleProgress cB in cBars)
            {

                double timeOfDayGained = dBll.GetTimeOfDayGainedCal(cB.timeOfDayName, DateTime.Today);
                int timeOfDayGainedPercentage = (int)((timeOfDayGained / StaticUser.TBLL) * 100);
                for (int i = 0; i <= timeOfDayGainedPercentage; i++)
                {
                    Thread.Sleep(5);
                    cB.Value = i;
                    cB.Text = $"{cB.timeOfDayName}: {cB.Value}%";
                }
                
                


            }
        }

        private void RefreshDailyProgressBar(DateTime date)
        {
            this.pBarDailyGain.Value = (int)dBll.DailyGainedCalories(date);
        }

        //==================================

        private void TBoxPortion_GotFocus(object sender, EventArgs e)
        {
            this.lblGainCal.Visible = false;
        }
  
        private void CBoxKeyWord_TextChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            string InputKeyword = cb.Text;
            if (InputKeyword == "") { return; }
            MealDTO Mdto = mBll.GetMeals(InputKeyword);
            if (Mdto.Meals.Count == 0) { return; }
            cb.DataSource = Mdto.Meals;
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
            cb.DroppedDown = true;
            
        }


        MealDetailDTO theMeal;
        private void CBoxKeyWord_SelectedIndexChanged(object sender, EventArgs e)
        {
            MealDetailDTO selectedMeal = (sender as ComboBox).SelectedItem as MealDetailDTO;

            theMeal = mBll.GetMeal(selectedMeal.ID);
            if (theMeal.Image != null)
            {
                byte[] bytes = theMeal.Image;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                this.pBoxMeal.Image = Image.FromStream(ms);
            }
            this.tBoxCal.Text = theMeal.Calories.ToString();
            this.LabelMealTitle.Text = theMeal.Name;
        }

        //==================================



        private void btnSendMealsToDB_Click(object sender, EventArgs e)
        {
            if (mealList.Count == 0) return;

            foreach (DietLogDTO dto in mealList)
            {

                dBll.Add(dto);
              
            }
            MessageBox.Show("ItemAdded!");
            mealList.Clear();
            this.DGVAddedMeals.DataSource = null;
            RefreshDailyProgressBar(DateTime.Today);
        }

        double thePortion;
        private void btnProtionCheck_Click(object sender, EventArgs e)
        {
            string inputPortion = this.tBoxPortion.Text;          
            if (!double.TryParse(inputPortion, out double portionTemp) || portionTemp <= 0)
            {
                MessageBox.Show("Please Enter Size...etc");
                return;
            }
            thePortion = portionTemp;
            this.lblGainCal.Text = $"Total Gained Calories: {thePortion* theMeal.Calories}";
            this.lblGainCal.Visible = true;

        }

        private void btnAddToTempList_Click(object sender, EventArgs e)
        {
            TimeOfDayDTO selectedTOD = this.cBoxTimesOfDay.SelectedItem as TimeOfDayDTO;
            if (selectedTOD == null || this.lblGainCal.Visible == false) { return; }      
            //double gainCalories = dBll.GetMealConsumedCalories(theMeal.Calories, thePortion);

            DietLogDTO dL = new DietLogDTO();
            dL.MemberID = StaticUser.UserID;
            dL.MealOptionID = theMeal.ID;
            dL.Portion = thePortion;
            dL.TimeOfDayID = selectedTOD.ID;
            dL.Date = this.dateTimePicker1.Value;  //
            dL.EditTime = DateTime.Now;
            //-------------------------
            dL.圖片 = theMeal.Image;
            dL.日期 = dL.Date;
            dL.時段 = selectedTOD.Name;        
            dL.餐點名稱 = theMeal.Name;
            dL.每100克卡路里 = (int)theMeal.Calories;
            dL.份量 = dL.Portion;
            dL.總卡路里 = (int)(dL.每100克卡路里 * dL.份量);
            mealList.Add(dL);

            foreach (var m in mealList.ToList())
            { }

            this.bS_AddedMeals.DataSource = mealList.ToList();         
            ShowReqdColumns();

        }

        private void ShowReqdColumns()
        {
            int cols = this.DGVAddedMeals.Columns.Count;
            for (int i = 6; i < cols; i++)
            {
                this.DGVAddedMeals.Columns[i].Visible = false;
            }
            this.DGVAddedMeals.Columns["圖片"].Visible = true;
            this.DGVAddedMeals.Columns["日期"].Visible = true;
            this.DGVAddedMeals.Columns["時段"].Visible = true;
            this.DGVAddedMeals.Columns["餐點名稱"].Visible = true;
            this.DGVAddedMeals.Columns["每100克卡路里"].Visible = true;
            this.DGVAddedMeals.Columns["份量"].Visible = true;
            this.DGVAddedMeals.Columns["總卡路里"].Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mealList.Clear();
            this.bS_AddedMeals.DataSource = mealList.ToList();


        }

      
    }
}
