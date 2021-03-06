using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub.ClientEnd.DAL;
using XxxFitnessCLub.ClientEnd.DAL.DAO;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd.BLL
{
    class DietLogBLL
    {
        DietLogDAO dao = new DietLogDAO();

        public bool Add(DietLogDTO entity)
        {
            DietLog dietlog = new DietLog();
            dietlog.MemberID = entity.MemberID;
            dietlog.TimeOfDayID = entity.TimeOfDayID;
            dietlog.MealOptionID = entity.MealOptionID;
            dietlog.EditTime = entity.EditTime;
            dietlog.Portion = entity.Portion;
            dietlog.Date = entity.Date;
            return dao.Add(dietlog);
        }

        public double GetMealConsumedCalories(int mealCalories, double size)
        {
            return mealCalories * size;
        }

        public double DailyGainedCalories(DateTime date)
        {
            return dao.GetDailyGainedCalories(date);
        }

        internal List<dynamic> GetDietLogHistory()
        {
            return dao.GetDietLogs();    
            
        }
        internal List<dynamic> GetDietLogHistory(DateTime startD, DateTime endD)
        {
            return dao.GetDietLogs(startD, endD);

        }

        
        internal List<dynamic> GetDietLogHistory(DateTime date)
        {
            return dao.GetDietLogs(date);
        }
        internal List<dynamic> GetDietLogHistory(DateTime startD, DateTime endD, int timeOfDateID)
        {
            return dao.GetDietLogs(startD, endD, timeOfDateID);

        }

        internal double GetTimeOfDayGainedCal(string timeOfDayName, DateTime date)
        {
            return dao.GetTimeOfDayGainedCal(timeOfDayName, date);
        }

        internal bool DeleteDietLog(int dietLogID)
        {
            return dao.DeleteDietLog(dietLogID);
        }

        internal bool UpdateDietLogPortion(int dietLogID, double newPortion)
        {
            return dao.UpdateDietLogPortion(dietLogID, newPortion );
        }
        internal DietLog GetDietLog(int dietLogID)
        {
            return dao.GetDietLog(dietLogID);
        }

    }
}
