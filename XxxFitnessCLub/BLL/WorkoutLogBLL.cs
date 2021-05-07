using HHFirstDraft.DAL;
using HHFirstDraft.DAL.DAO;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft.BLL
{
    class WorkoutLogBLL
    {
        WorkoutLogDAO dao = new WorkoutLogDAO();
        const int TAKEDAYS = 14;

        //恩旗
        internal List<WorkoutLogDTO> GetWorkoutLogs()
        {
            List<WorkoutLogDTO> list = new List<WorkoutLogDTO>();
            foreach (var wl in dao.GetWorkoutLogs())
            {
                list.Add(new WorkoutLogDTO(wl));
            }
            return list;
        }

        internal bool Add(WorkoutLog entity)
        {
            return dao.Add(entity);
        }

        //恩旗
        internal List<DailyWorkoutCal> GetWorkoutCalByDate(DateTime? startDate, DateTime? endDate)
        {
            DateTime sd = startDate ?? DateTime.MinValue;
            DateTime ed = endDate ?? DateTime.MaxValue;
            
            var q = (from wl in GetWorkoutLogs().Where(wl => wl.EditTime.Date >= sd.Date
                    && wl.EditTime.Date <= ed.Date)
                     group wl by wl.EditTime.Date into g
                     select new DailyWorkoutCal
                     {
                         EditDate = g.Key,
                         TotalCal = $"{g.Sum(wl => wl.WorkoutTotalCal):0.00}",
                         TotalHours = $"{g.Sum(wl => wl.WorkoutHours):0.00}"
                     }).OrderBy(g => g.EditDate);


            if (q.ToList().Count > TAKEDAYS)
            {
                int skipDays = q.ToList().Count - TAKEDAYS;
                return q.Skip(skipDays).ToList();
            }
            else
            {
                return q.Take(14).ToList();
            }

        }
        //恩旗
        internal WorkoutLogDTO GetWorkoutLogByID(int ID)
        {
            return GetWorkoutLogs().SingleOrDefault(r => r.ID == ID);
        }

        //恩旗
        internal bool Edit(WorkoutLog entity)
        {
            return dao.Edit(entity);
        }

        //恩旗
        internal bool Delete(WorkoutLog entity)
        {
            return dao.Delete(entity);
        }

        //恩旗
        internal List<WorkoutLogDTO> GetWorkoutLogsByKeyword(string keyword)
        {
            if (keyword == null)
            {
                return GetWorkoutLogs();
            }
            else
            {
                return GetWorkoutLogs().Where(wl => wl.WorkoutName.Contains(keyword)
                || wl.WorkoutCategoryName.Contains(keyword)
                || wl.ActivityLevelName.Contains(keyword)).ToList();
            }

            
        }
    }

    //恩旗
    class DailyWorkoutCal
    {
        public DateTime EditDate { get; set; }
        public string TotalCal { get; set; }
        public string TotalHours { get; set; }
    }
}
