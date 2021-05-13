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
        internal List<WorkoutLogDTO> GetWorkoutLogs()
        {
            return dao.GetWorkoutLogs();
        }

        internal bool Add(WorkoutLog entity)
        {
            return dao.Add(entity);
        }

        internal List<DailyWorkoutCal> GetWorkoutCalByDate(DateTime? date, int takeDays)
        {

            if (date == null)
            {
                var q = (from wl in dao.GetWorkoutLogs()
                         group wl by wl.EditTime.Date into g
                         select new DailyWorkoutCal
                         {
                             EditDate = g.Key,
                             TotalCal = $"{g.Sum(wl => wl.WorkoutTotalCal):0.00}",
                             TotalHours = $"{g.Sum(wl => wl.WorkoutHours):0.00}"
                         }).OrderBy(g => g.EditDate);

                int skipDays = q.ToList().Count - takeDays;

                return q.Skip(skipDays).ToList();
            }
            else
            {
                var q = (from wl in dao.GetWorkoutLogs().Where(wl => wl.EditTime.Date >= date?.Date
                        && wl.EditTime.Date <= date?.AddDays(takeDays - 1))
                     group wl by wl.EditTime.Date into g
                     select new DailyWorkoutCal
                     {
                         EditDate = g.Key,
                         TotalCal = $"{g.Sum(wl => wl.WorkoutTotalCal):0.00}",
                         TotalHours = $"{g.Sum(wl => wl.WorkoutHours):0.00}"
                     }).OrderBy(g => g.EditDate);

                return q.Take(takeDays).ToList();
            }
        }
    }

    class DailyWorkoutCal
    {
        public DateTime EditDate { get; set; }
        public string TotalCal { get; set; }
        public string TotalHours { get; set; }
    }
}
