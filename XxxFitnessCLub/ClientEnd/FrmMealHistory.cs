using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using XxxFitnessCLub;
using XxxFitnessCLub.ClientEnd;
using XxxFitnessCLub.ClientEnd.BLL;
using XxxFitnessCLub.ClientEnd.DAL.DTO;
using XxxFitnessCLub.ClientEnd.ViewModel;

namespace HHFirstDraft
{
    public partial class FrmMealHistory : Form
    {
        DietLogBLL dlBll = new DietLogBLL();
        TimesOfDayBLL tBll = new TimesOfDayBLL();
        LikedMealBLL lmBLL = new LikedMealBLL();
        MyCircleProgress[] cBars;

        public FrmMealHistory()
        {
            InitializeComponent();
            DGVMealHistory.CellFormatting += DGVMealHistory_CellFormatting;  
            DGVMealHistory.CellClick += DGVMealHistory_CellClick;

            DGVMealHistory.DataSource = bS_MealHistory;
            bS_MealHistory.DataSource = dlBll.GetDietLogHistory().ToList(); //
            bS_MealHistory.DataSourceChanged += BS_MealHistory_DataSourceChanged;
            DGVMealHistory.Columns["DietLogID"].Visible = false;  //
            
            this.mCalendar.MaxDate = DateTime.Today;
            this.cBoxTimesOfDay.Text = "請選擇時段";
            LoadTimeOfDay();
            myCProParBf.timeOfDayName = "早餐";
            myCProParLn.timeOfDayName = "午餐";
            myCProParDn.timeOfDayName = "晚餐";
            myCProParSn.timeOfDayName = "點心";
            myCProParBedSn.timeOfDayName = "宵夜";
            cBars = new MyCircleProgress[] { myCProParBf, myCProParLn, myCProParDn, myCProParSn, myCProParBedSn };

            this.pBarDailyGain.Minimum = 0;
            this.pBarDailyGain.Maximum = StaticUser.TBLL;

            this.mCalendar.DateSelected += MCalendar_DateSelected;
            
            //=======


        }

        private void BS_MealHistory_DataSourceChanged(object sender, EventArgs e)
        {
            if (this.DGVMealHistory.Columns.Contains("DietLogID"))
            {
                this.DGVMealHistory.Columns["DietLogID"].Visible = false;
            }
        }

        private void MCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {   
            UpdateCircularProgressBars(cBars, e.Start);
            groupBox1.Text = e.Start.ToString("M/d/yyyy");
            RefreshDailyProgressBar(e.Start);
        }

        private void RefreshDailyProgressBar(DateTime date)  //
        {
            int dailyTotal = (int)dlBll.DailyGainedCalories(date);
            if (dailyTotal >= this.pBarDailyGain.Maximum)
            {
                this.pBarDailyGain.Value = this.pBarDailyGain.Maximum;
            }
            else
            {
                this.pBarDailyGain.Value = (int)dlBll.DailyGainedCalories(date);
            }
            lblTotalGainedCalPer.Text = $"{(double)dailyTotal / (double)StaticUser.TBLL * 100}%";

        }
        private void UpdateCircularProgressBars(MyCircleProgress[] cBars, DateTime date)
        {
            foreach (MyCircleProgress cB in cBars)
            {

                double timeOfDayGained = dlBll.GetTimeOfDayGainedCal(cB.timeOfDayName, date);
                int timeOfDayGainedPercentage = (int)((timeOfDayGained / StaticUser.TBLL) * 100);
                for (int i = 0; i <= timeOfDayGainedPercentage; i++)
                {
                    cB.Value = i;
                    cB.Text = $"{cB.timeOfDayName}: {cB.Value}%";
                }

            }
        }

        private void DGVMealHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            int dietLogID = (int)DGVMealHistory.Rows[e.RowIndex].Cells["DietLogID"].Value;
            if (DGVMealHistory.Columns[e.ColumnIndex].Name == "btnLike")
            {

                int mealID = dlBll.GetDietLog(dietLogID).MealOption.ID;

                LikedMealDTO lmDto = new LikedMealDTO(new LikedMeal
                {
                    MemberID = StaticUser.UserID,
                    MealOptionID = mealID
                });
                if (lmBLL.Add(lmDto))
                {
                    MessageBox.Show($"已加入我的最愛");
                }
            }        
            else if (DGVMealHistory.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DateTime date = (DateTime)DGVMealHistory.Rows[e.RowIndex].Cells["日期"].Value;
                string tod = DGVMealHistory.Rows[e.RowIndex].Cells["時段"].Value.ToString();
                string mName = DGVMealHistory.Rows[e.RowIndex].Cells["餐點名稱"].Value.ToString();
                string portion = DGVMealHistory.Rows[e.RowIndex].Cells["份量"].Value.ToString();

                
                string showInfo = date.ToString("MM / dd / yyyy") + $" {tod}\n{mName} {portion}份"; ;

                DialogResult dialogResult = MessageBox.Show(showInfo, "刪除紀錄?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (dlBll.DeleteDietLog(dietLogID))
                    {
                        MessageBox.Show("紀錄已刪除");
                        TimeOfDayDTO t = cBoxTimesOfDay.SelectedItem as TimeOfDayDTO;
                        if (DGVMealHistory.Rows.Count-1 == dlBll.GetDietLogHistory().Count)
                        {
                            bS_MealHistory.DataSource = dlBll.GetDietLogHistory().ToList();
                        }
                        else if (t == null)
                        {
                            bS_MealHistory.DataSource = dlBll.GetDietLogHistory(mCalendar.SelectionStart, mCalendar.SelectionEnd).ToList();
                        }
                        else 
                        {
                            bS_MealHistory.DataSource = dlBll.GetDietLogHistory(mCalendar.SelectionStart, mCalendar.SelectionEnd, t.ID).ToList();

                        }
                    }
                }
            }
            else if (DGVMealHistory.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                if (double.TryParse(Interaction.InputBox("請輸入更改後的份量(可含小數):", "修改份量?"), out double newPortion))
                {
                    if (dlBll.UpdateDietLogPortion(dietLogID, newPortion))
                    {
                        MessageBox.Show("紀錄已修改");
                        bS_MealHistory.DataSource = dlBll.GetDietLogHistory().ToList();      //改成抓現在的葉面


                    }
                }
                
               
            }
        }



        private void LoadTimeOfDay()
        {
            this.cBoxTimesOfDay.Items.Add("全部時段");
            foreach (var t in  tBll.GetTimesOfDay())
            {
                this.cBoxTimesOfDay.Items.Add(t);
                this.cBoxTimesOfDay.DisplayMember = "Name";
            }

        }
     
        private void mCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.bS_MealHistory.DataSource = null;
            MonthCalendar mc = sender as MonthCalendar;
            TimeOfDayDTO toD = cBoxTimesOfDay.SelectedItem as TimeOfDayDTO;
            if (toD == null)
            {
                bS_MealHistory.DataSource = dlBll.GetDietLogHistory(mc.SelectionStart, mc.SelectionEnd);
            }
            else 
            {
                bS_MealHistory.DataSource = dlBll.GetDietLogHistory(mc.SelectionStart, mc.SelectionEnd, toD.ID);
            }
        }

        private void DGVMealHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Rows.Count <= 0) return;
            if (e.ColumnIndex ==4)
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
                        e.CellStyle.BackColor = Color.LightCyan;
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

     

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.bS_MealHistory.DataSource = null;
            TimeOfDayDTO toD = cBoxTimesOfDay.SelectedItem as TimeOfDayDTO;
            if (toD == null)
            {
                bS_MealHistory.DataSource = dlBll.GetDietLogHistory(this.mCalendar.SelectionStart, this.mCalendar.SelectionEnd);
            }
            else
            {
                bS_MealHistory.DataSource = dlBll.GetDietLogHistory(this.mCalendar.SelectionStart, this.mCalendar.SelectionEnd, toD.ID);

            }
        }
    }
}
