using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub;
using XxxFitnessClub.BackEnd.DAL.DTO;
using XxxFitnessClub.BackEnd.DAL.DAO;

namespace XxxFitnessClub.BackEnd.BLL
{
    public class WorkoutLogBLL:HHContext
    {
        WorkoutLogDAO dao = new WorkoutLogDAO();
        public WorkoutLogDTO GetWorkoutLogs()
        {
            WorkoutLogDTO dto = new WorkoutLogDTO();
            dto.workoutLogs = dao.GetWorkoutLogs();
            return dto;
        }

        public WorkoutLogDTO GetWorkoutLogs(string keyword)
        {
            WorkoutLogDTO dto = new WorkoutLogDTO();
            dto.workoutLogs = dao.GetWorkoutLogs(keyword);
            return dto;
        }

        public List<CreatePie> GetWorkoutNamePie()
        {
            CreatePie dto = new CreatePie();
            var q = from p in db.WorkoutLogs
                    group p by p.Workout.Name into g
                    select new CreatePie
                    {
                        WorkoutName = g.Key,
                        Count = g.Count(),
                        //Persent = g.Count() / g.All()
                    };

            return q.ToList();
        }
        public List<CreatePie> GetWorkoutDatePie(DateTime start, DateTime end)
        {
            CreatePie dto = new CreatePie();
            var q = from p in db.WorkoutLogs
                    where p.EditTime >= start && p.EditTime <= end
                    group p by p.Workout.Name into g
                    select new CreatePie
                    {
                        WorkoutName = g.Key,
                        Count = g.Count()
                    };
            return q.ToList();
        }

        public List<CreatePie> GetWorkoutGenderPie(bool gender)
        {
            CreatePie dto = new CreatePie();
            var q = /*db.WorkoutLogs.Where(x=>x.)*/
                from p in db.WorkoutLogs
                    where p.Member.Gender==gender
                    group p by p.Workout.Name into g
                    select new CreatePie
                    {
                        WorkoutName = g.Key,
                        Count = g.Count()
                    };
            return q.ToList();
        }

        public class CreatePie
        {
            public string WorkoutName { get; set; }
            public int Count { get; set; }
            public double Persent { get; set; }
        }

        public void UpDate(WorkoutLogDetailDTO entity)
        {
            WorkoutLog workoutLog = new WorkoutLog();
            workoutLog.ID = entity.ID;
            workoutLog.MemberID = (int)entity.MemberID;
            workoutLog.WorkoutID = (int)entity.WorkoutID;
            workoutLog.EditTime = entity.EditTime;
            //workoutLog.Workout.Name = entity.WorkoutName;
            workoutLog.WorkoutHours = entity.WorkoutHours;
            dao.Update(workoutLog);
        }

        public bool Delete(int ID)
        {
            return dao.Delete(ID);            
        }

        public bool Add(WorkoutLogDetailDTO entity)
        {
            WorkoutLog workoutLog = new WorkoutLog();           
            workoutLog.MemberID = (int)entity.MemberID;
            workoutLog.WorkoutID = (int)entity.WorkoutID;
            workoutLog.EditTime = entity.EditTime;
            //workoutLog.Workout.Name = entity.WorkoutName;
            workoutLog.WorkoutHours = entity.WorkoutHours;
            return dao.Add(workoutLog);
        }

        public bool IsWorkoutLogExist(int ID)
        {
            return dao.IsWorkoutLogExist(ID);
        }
    }
}
