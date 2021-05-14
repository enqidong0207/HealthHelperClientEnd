﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XxxFitnessCLub.ClientEnd.DAL.DAO
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

        //=========================================================================
        internal List<dynamic> GetDietLogs(DateTime startD, DateTime endD)
        {
            var q = from dl in db.DietLogs
                    where dl.Date >= startD && dl.Date <= endD
                    orderby dl.Date, dl.TimeOfDayID
                    select new
                    {
                        dl.Date,
                        TimeOfDay = dl.TimesOfDay.Name,
                        dl.MealOption.Image,
                        dl.MealOption.Name,
                        dl.MealOption.Calories,
                        dl.Portion,
                        TotalCalories = (int)dl.MealOption.Calories * dl.Portion,
                        dl.EditTime
                    };
            return q.ToList<dynamic>();
        }
        public List<dynamic> GetDietLogs()
        {
            var q = from dl in db.DietLogs
                    select new
                    {   
                        dl.Date,
                        TimeOfDay = dl.TimesOfDay.Name,
                        dl.MealOption.Image,
                        dl.MealOption.Name,
                        dl.MealOption.Calories,
                        dl.Portion,
                        TotalCalories = (int)dl.MealOption.Calories * dl.Portion,
                        dl.EditTime
                    };

            return q.ToList<dynamic>();
        }

        public List<dynamic> GetDietLogs(DateTime date)
        {
            var q = from dl in db.DietLogs 
                    where dl.Date == date
                    select new
                    {
                        dl.Date,
                        TimeOfDay = dl.TimesOfDay.Name,
                        dl.MealOption.Image,
                        dl.MealOption.Name,
                        dl.MealOption.Calories,
                        dl.Portion,
                        TotalCalories = (int)dl.MealOption.Calories * dl.Portion,
                        dl.EditTime
                    };

            return q.ToList<dynamic>();
        }



    }
}