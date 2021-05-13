using HHFirstDraft.BLL;
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


namespace HHFirstDraft
{

    public partial class FrmMealInfo : Form
    {
        MealBLL mBll = new MealBLL();
        DietLogBLL dBll = new DietLogBLL();
        public int mealID;
        MealDetailDTO theMeal;
        FrmMealLog theCallerFrm;
       

        public FrmMealInfo(int selectedMealID,  FrmMealLog caller)
        {
            InitializeComponent();
            theCallerFrm = caller;
            


            mealID = selectedMealID;
            theMeal = mBll.GetMeal(mealID);

            this.LabelMealTitle.Text = theMeal.Name;
            this.textBoxCalories.Text = theMeal.Calories.ToString();
        }


        private void btn_AddTheMeal(object sender, EventArgs e)
        {
            ComboBox callerFrmComboToD = (ComboBox)theCallerFrm.Controls["comboBoxTimesOfDay"];
            TimeOfDayDTO selectedTOD = callerFrmComboToD.SelectedItem as TimeOfDayDTO;

            if (!double.TryParse(this.textBoxMealSize.Text, out double size) || size <= 0 || selectedTOD == null)
            //todo1 //把請選擇段設定為預設值 最後一個判斷條件才可以用得上
            {
                MessageBox.Show("Please Enter Size...etc");
                return;
            }
            double gainCalories = dBll.GetMealConsumedCalories(theMeal.Calories, size);
            
            DietLogDTO dL = new DietLogDTO();
            dL.MemberID = StaticUser.UserID;
            dL.MealOptionID = theMeal.ID;
            dL.Portion = size;
            dL.TimeOfDayID = selectedTOD.ID;
            dL.Date = DateTime.Now.AddDays(-1);  //
            dL.EditTime = DateTime.Now;
            dL.每100克卡路里 = theMeal.Calories;
            dL.總卡路里 = (int)gainCalories;
            dL.餐點名稱 = theMeal.Name;
            dL.時段 = selectedTOD.Name;








            //switch (selectedTOD.Name)
            //{
            //    case "早餐":
            //        theCallerFrm.breakfastList.Add(dL);
            //        break;

            //    case "午餐":
            //        theCallerFrm.lunchList.Add(dL);
            //        break;
            //    case "晚餐":
            //        theCallerFrm.dinerList.Add(dL);
            //        break;

            //    case "點心":
            //        theCallerFrm.snackList.Add(dL);
            //        break;

            //    case "消夜":
            //        theCallerFrm.bedtimeSnacksList.Add(dL);
            //        break;
            //    default:
            //        MessageBox.Show("Bug!");
            //        break;
            //}

            //this.Close();
           Panel callerPanel = theCallerFrm.Controls["PanelMealInfo"] as Panel;
            callerPanel.Controls.Remove(this);




        }

       
    }
}
