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
        LikedMealBLL lmBLL = new LikedMealBLL();
        public List<DietLogDTO> mealList = new List<DietLogDTO>();
    

    MyCircleProgress[] cBars;
        public FrmMealLog()
        {
            InitializeComponent();

            this.cBoxTimesOfDay.Text = "請選擇時段";
            LoadTimeOfDay();
            this.tBoxPortion.GotFocus += TBoxPortion_GotFocus;          
            this.DGVAddedMeals.DataSource = bS_AddedMeals;
            this.DGVRecordOfToday.DataSource = bS_RecordOfToday;
            
            this.DGVAddedMeals.CellContentClick += DGVAddedMeals_CellContentClick;
            this.DGVRecordOfToday.CellFormatting += DGVsCellFormatting;
            this.DGVAddedMeals.CellFormatting += DGVsCellFormatting;
            this.tBoxCal.ReadOnly = true;
            this.tBoxTotalCal.ReadOnly = true;

            //========================================

            bS_RecordOfToday.DataSource = dBll.GetDietLogHistory(DateTime.Today);

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
            //this.DGVRecordOfToday.Columns["DietLogID"].Visible = false;   //todo 藏


             cBars =new MyCircleProgress[] { myCProParBf,myCProParLn,myCProParDn,myCProParSn,myCProParBedSn};

            //====================================================
            //recordList = dBll.GetDietLogHistory(DateTime.Today);
            DGVAddedMeals.AllowUserToAddRows = false;
            DGVAddedMeals.ReadOnly = true;
            RefreshDailyProgressBar(DateTime.Today);
            this.lblLikedCount.Text = lmBLL.LikedMealsCount.ToString();
            





        }

     
        private void DGVAddedMeals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex == 0 )   //Delete button's index is 0
            {            
                mealList.RemoveAt(e.RowIndex);
            }

            this.bS_AddedMeals.DataSource = mealList.Count == 0 ? null : mealList.ToList().OrderByDescending(dl => dl.Date).ThenBy(dl => dl.TimeOfDayID);


        }

        private void LoadTimeOfDay()
        {
            foreach (var t in tBll.GetTimesOfDay())
            {
                this.cBoxTimesOfDay.Items.Add(t);
                this.cBoxTimesOfDay.DisplayMember = "Name";
            }
        }
      


        //==================================

       


        private void UpdateCircularProgressBar(MyCircleProgress[] cBars)  //重0跑
        {
            foreach (MyCircleProgress cB in cBars)
            {

                double timeOfDayGained = dBll.GetTimeOfDayGainedCal(cB.timeOfDayName, DateTime.Today);
                int timeOfDayGainedPercentage = (int)((timeOfDayGained / StaticUser.TBLL) * 100);
                for (int i = 0; i <= timeOfDayGainedPercentage; i++)
                {
                    Thread.Sleep(1);
                    cB.Value = i;
                    cB.Text = $"{cB.timeOfDayName}: {cB.Value}%";
                }
                
                


            }
        }

        private void RefreshDailyProgressBar(DateTime date)
        {
            int dailyTotal = (int)dBll.DailyGainedCalories(date);
            if (dailyTotal >= this.pBarDailyGain.Maximum)
            {
                this.pBarDailyGain.Value = this.pBarDailyGain.Maximum;
            }
            else
            {
                this.pBarDailyGain.Value = dailyTotal;
            }
            this.lblGreeting.Text = $"Hello {StaticUser.UserName} 您的TDEE是 {StaticUser.TBLL}大卡\n" +
                $"目前獲取卡路里: {dailyTotal}大卡";
            lblTotalCalPer.Text = $"{(double)dailyTotal / (double)StaticUser.TBLL * 100}%";

        }

        //==================================

        private void TBoxPortion_GotFocus(object sender, EventArgs e)
        {
            thePortion = 0;
            this.tBoxTotalCal.Text = "";
        }
  
        private void CBoxKeyWord_TextChanged(object sender, EventArgs e)
        {
            
            ComboBox cb = sender as ComboBox;
            string InputKeyword = cb.Text;
            if (InputKeyword == "")
            {
                return; 
            }
            MealDTO Mdto = mBll.GetMeals(InputKeyword);
            if (Mdto.Meals.Count == 0) { return; }
            foreach (var m in Mdto.Meals)
            {
                cb.Items.Add(m);
                cb.DisplayMember = "Name";
                cb.ValueMember = "ID";
            }
            
            cb.DroppedDown = true;
            cb.Text = "";


        }


        MealDetailDTO theMeal;
     
        private void btnSendMealsToDB_Click(object sender, EventArgs e)
        {
            if (mealList.Count == 0) return;

            foreach (DietLogDTO dto in mealList)
            {

                dBll.Add(dto);
              
            }
            MessageBox.Show("ItemAdded!");
            mealList.Clear();
            this.bS_AddedMeals.DataSource = mealList.ToList()/*.OrderByDescending(dl => dl.Date).ThenBy(dl => dl.TimeOfDayID);*/;

            bS_RecordOfToday.DataSource = dBll.GetDietLogHistory(DateTime.Today);
            RefreshDailyProgressBar(DateTime.Today);
            UpdateCircularProgressBar(cBars);

        }

        double thePortion;
        private void btnProtionCheck_Click(object sender, EventArgs e)
        {
            if (theMeal == null) return;
            string inputPortion = this.tBoxPortion.Text;          
            if (!double.TryParse(inputPortion, out double portionTemp) || portionTemp <= 0)
            {
                MessageBox.Show("請輸入>0的分量(可含小數)");
                return;
            }
            thePortion = portionTemp;
            this.tBoxTotalCal.Text = $"{thePortion* theMeal.Calories}";

        }

        private void btnAddToTempList_Click(object sender, EventArgs e)
        {
            if (theMeal == null) { return; }
            TimeOfDayDTO selectedTOD = this.cBoxTimesOfDay.SelectedItem as TimeOfDayDTO;
            if (selectedTOD == null || this.tBoxTotalCal.Text == "")
            {
                MessageBox.Show("請確認時段及份量");
                return;
            }
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

            this.bS_AddedMeals.DataSource = mealList.ToList().OrderByDescending(dl => dl.Date).ThenBy(dl => dl.TimeOfDayID);

            ShowReqdColumns();
            this.tBoxTotalCal.Text = "";

        }

        private void ShowReqdColumns()     //DTO包起來?
        {

            int cols = this.DGVAddedMeals.Columns.Count;
            for (int i = 8; i < cols; i++)
            {
                this.DGVAddedMeals.Columns[i].Visible = false;
            }
            //this.DGVAddedMeals.Columns["圖片"].Visible = true;
            //this.DGVAddedMeals.Columns["日期"].Visible = true;
            //this.DGVAddedMeals.Columns["時段"].Visible = true;
            //this.DGVAddedMeals.Columns["餐點名稱"].Visible = true;
            //this.DGVAddedMeals.Columns["每100克卡路里"].Visible = true;
            //this.DGVAddedMeals.Columns["份量"].Visible = true;
            //this.DGVAddedMeals.Columns["總卡路里"].Visible = true;
            //this.DGVAddedMeals.Columns["刪除紐"].Visible = true;
           
        }

        private void FrmMealLog_Shown(object sender, EventArgs e)
        {
            UpdateCircularProgressBar(cBars);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            mealList.Clear();
            this.bS_AddedMeals.DataSource = null;

        }

        private void DGVsCellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string[] todNames = { "早餐", "午餐", "晚餐", "點心", "宵夜" };
            if (todNames.Contains(e.Value.ToString()))
            {
                switch (e.Value.ToString())
                {
                    case "早餐":
                        e.CellStyle.BackColor = Color.Pink;
                        break;
                    case "午餐":
                        e.CellStyle.BackColor = Color.PapayaWhip;
                        break;
                    case "晚餐":
                        e.CellStyle.BackColor = Color.Honeydew;
                        break;
                    case "點心":
                        e.CellStyle.BackColor = Color.Azure;
                        break;
                    case "宵夜":
                        e.CellStyle.BackColor = Color.Lavender;
                        break;
                    default:
                        e.CellStyle.BackColor = Color.White;
                        break;



                }
            }
        }

        private void btnSearchMeals_Click(object sender, EventArgs e)
        {       
            string inputKW = this.tBoxSearch.Text;
            if (inputKW != "")
            {
                MealDTO Mdto = mBll.GetMeals(inputKW);
                if (Mdto.Meals.Count == 0)
                {
                    listBoxMeals.DataSource = null;
                }
                else {
                    listBoxMeals.DataSource = Mdto.Meals;
                    listBoxMeals.DisplayMember = "Name";

                }
            }
            else {
                listBoxMeals.DataSource = null;
            }
        }

        private void listBoxMeals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listBoxMeals.Items.Count == 0 || this.listBoxMeals.DataSource == null) { return; }
            theMeal = (sender as ListBox).SelectedItem as MealDetailDTO;
            this.LabelMealTitle.Text = theMeal.Name;
            //====================================
            if (theMeal.Image != null)
            {
                byte[] bytes = theMeal.Image;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                this.pBoxMeal.Image = Image.FromStream(ms);
            }
            else
            {
                this.pBoxMeal.Image = this.pBoxMeal.InitialImage;
            }
            //====================================
            this.tBoxCal.Text = theMeal.Calories.ToString();


        }

        private void btnAddLikes_Click(object sender, EventArgs e)
        {
            if (theMeal == null) return;
            LikedMealDTO lmDto = new LikedMealDTO(new LikedMeal
            {
                MemberID = StaticUser.UserID,
                MealOptionID = theMeal.ID
            });
            if (lmBLL.Add(lmDto))
            {
                MessageBox.Show($"{theMeal.Name} 已加入我的最愛");
                this.lblLikedCount.Text = lmBLL.LikedMealsCount.ToString();
            }
            

        }

        private void btnViewLikes_Click(object sender, EventArgs e)
        {
            listBoxMeals.DataSource = lmBLL.GetLikedMeals();
            listBoxMeals.DisplayMember = "Name";


        }

        private void BtnRefImg_Click(object sender, EventArgs e)
        {
            FrmPortionRef f = new FrmPortionRef();
            f.ShowDialog();
        }
    }
}
