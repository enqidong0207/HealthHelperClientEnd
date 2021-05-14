using HHFirstDraft.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft.DAL.DAO
{
    class DietLogDAO : HHContext
    {

        public bool Add(DietLog dietLog)
        {
            try
            {
                db.DietLogs.Add(dietLog);
                db.SaveChanges();       
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //=========================================================================

        public double GetDailyGainedCalories(DateTime date)
        {
            try
            {
                var rc = db.DietLogs.Where(dl => dl.Date == date).Select(dl => dl);
                if (rc.ToList().Count == 0)
                {
                    return 0;
                }
                else 
                {
                    double gainCal = rc.Sum(dl => dl.MealOption.Calories * dl.Portion);
                    return gainCal;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal double GetTimeOfDayGainedCal(string timeOfDayName, DateTime date)
        {
            try
            {
                var rc = db.DietLogs.Where(dl => dl.Date == date && dl.TimesOfDay.Name == timeOfDayName).Select(dl => dl);
                if (rc.ToList().Count == 0)
                {
                    return 0;
                }
                else 
                {
                    double gainCal = rc.Sum(dl => dl.MealOption.Calories * dl.Portion);
                    return gainCal;
                }              
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        internal bool DeleteDietLog(int dietLogID)
        {
            try
            {
                DietLog d = db.DietLogs.FirstOrDefault(dl => dl.ID == dietLogID);
                db.DietLogs.Remove(d);
                db.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        internal bool UpdateDietLogPortion(int dietLogID, double newPortion)
        {

            try
            {
                db.DietLogs.FirstOrDefault(dl => dl.ID == dietLogID).Portion = newPortion;
                db.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        //=========================================================================
        internal List<dynamic> GetDietLogs(DateTime startD, DateTime endD)
        {
            var q = from dl in db.DietLogs
                    where dl.Date >= startD && dl.Date <= endD
                    orderby dl.Date, dl.TimeOfDayID
                    select new
                    {
                        日期 = dl.Date,
                        時段 = dl.TimesOfDay.Name,
                        餐點圖片 = dl.MealOption.Image,
                        餐點名稱 = dl.MealOption.Name,
                        每100克卡路里 = dl.MealOption.Calories,
                        份量 = dl.Portion,
                        總卡路里 = (int)dl.MealOption.Calories * dl.Portion,
                        更改時間 = dl.EditTime,
                        DietlogID = dl.ID
                    };
            return q.ToList<dynamic>();
        }
        public List<dynamic> GetDietLogs()
        {
            var q = from dl in db.DietLogs
                    orderby dl.Date descending, dl.TimeOfDayID
                    select new
                    {
                        日期 = dl.Date,
                        時段 = dl.TimesOfDay.Name,
                        餐點圖片 = dl.MealOption.Image,
                        餐點名稱 = dl.MealOption.Name,
                        每100克卡路里 = dl.MealOption.Calories,
                        份量 = dl.Portion,
                        總卡路里 = (int)dl.MealOption.Calories * dl.Portion,
                        更改時間 = dl.EditTime,
                        DietlogID = dl.ID
                    };

            return q.ToList<dynamic>();
        }

        public List<dynamic> GetDietLogs(DateTime date)
        {
            var q = from dl in db.DietLogs 
                    where dl.Date == date
                    orderby dl.Date descending, dl.TimeOfDayID
                    select new
                    {
                        日期 = dl.Date,
                        時段 = dl.TimesOfDay.Name,
                        餐點圖片 = dl.MealOption.Image,
                        餐點名稱 = dl.MealOption.Name,
                        每100克卡路里 = dl.MealOption.Calories,
                        份量 = dl.Portion,
                        總卡路里 = (int)dl.MealOption.Calories * dl.Portion,
                        更改時間 = dl.EditTime,
                        DietlogID = dl.ID
                    };

            return q.ToList<dynamic>();
        }

        public List<dynamic> GetDietLogs(DateTime startD, DateTime endD,  int timeOfDateID)
        {
            var q = from dl in db.DietLogs
                    where dl.Date >= startD && dl.Date <= endD && dl.TimeOfDayID == timeOfDateID
                    orderby dl.Date descending, dl.TimeOfDayID
                    select new
                    {
                        日期 = dl.Date,
                        時段 = dl.TimesOfDay.Name,
                        餐點圖片 = dl.MealOption.Image,
                        餐點名稱 = dl.MealOption.Name,
                        每100克卡路里 = dl.MealOption.Calories,
                        份量 = dl.Portion,
                        總卡路里 = (int)dl.MealOption.Calories * dl.Portion,
                        更改時間 = dl.EditTime,
                        DietlogID = dl.ID
                    };

            return q.ToList<dynamic>();
        }


    }
}
