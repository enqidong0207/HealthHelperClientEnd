using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using XxxFitnessCLub.ClientEnd.BLL;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace HHFirstDraft
{
    public partial class FrmMealHistory : Form
    {
        DietLogBLL dlBll = new DietLogBLL();
        TimesOfDayBLL tBll = new TimesOfDayBLL();
        public FrmMealHistory()
        {
            InitializeComponent();
            //DGVMealHistory.CellFormatting += DGVMealHistory_CellFormatting;   //
            DGVMealHistory.DataSource = bS_MealHistory;
            DGVMealHistory.CellClick += DGVMealHistory_CellClick;
            bS_MealHistory.DataSource = dlBll.GetDietLogHistory().ToList();
            DGVMealHistory.Columns["DietLogID"].Visible = false;
            this.cBoxTimesOfDay.Text = "請選擇時段";
            LoadTimeOfDay();
            //AddDGVButtons();



        }

        private void DGVMealHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            int dietLogID = (int)DGVMealHistory.Rows[e.RowIndex].Cells["DietLogID"].Value;
            if (DGVMealHistory.Columns[e.ColumnIndex].Name == "btnLike")
            {
                MessageBox.Show("btnLike");
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
                        bS_MealHistory.DataSource = dlBll.GetDietLogHistory().ToList();
                    }
                }
            }
            else if (DGVMealHistory.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                if (double.TryParse(Interaction.InputBox("請輸入更改後的份量(可含小數):", "修改份量?"), out double newPortion))
                {
                    MessageBox.Show(newPortion + "");
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
        private void button1_Click(object sender, EventArgs e)
        {
            
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
            switch (dgv.Rows[e.RowIndex].Cells["TimeOfDay"].Value.ToString()) 
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
                    e.CellStyle.BackColor = Color.LightGray;
                    break;
                default:
                    e.CellStyle.BackColor = Color.White;
                    break;



            }
        }

     

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.bS_MealHistory.DataSource = null;
            TimeOfDayDTO toD = cBoxTimesOfDay.SelectedItem as TimeOfDayDTO;
            if (toD == null)
            {
                bS_MealHistory.DataSource = dlBll.GetDietLogHistory(this.mCalendar.SelectionStart, this.mCalendar.SelectionStart);
            }
            else
            {
                bS_MealHistory.DataSource = dlBll.GetDietLogHistory(this.mCalendar.SelectionStart, this.mCalendar.SelectionStart, toD.ID);

            }
        }
    }
}
