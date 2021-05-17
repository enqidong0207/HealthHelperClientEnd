using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub;
using XxxFitnessClub.BackEnd.DAL.DTO;

namespace XxxFitnessClub.BackEnd.DAL.DAO
{
    public class WorkoutLogDAO:HHContext
    {
        internal List<WorkoutLogDetailDTO> GetWorkoutLogs()
        {
            List<WorkoutLog> workoutLogs = db.WorkoutLogs.ToList();
            List<WorkoutLogDetailDTO> logDTOlist = new List<WorkoutLogDetailDTO>();
            foreach(var item in workoutLogs)
            {
                WorkoutLogDetailDTO dto = new WorkoutLogDetailDTO();
                dto.ID = item.ID;
                dto.MemberID = item.MemberID;
                dto.MemberName = item.Member.Name;
                dto.WorkoutID = item.WorkoutID;
                dto.WorkoutName = item.Workout.Name;
                dto.WorkoutHours = item.WorkoutHours;
                dto.Calories =Math.Round( item.Workout.Calories * item.WorkoutHours,2);
                dto.EditTime = item.EditTime;
                logDTOlist.Add(dto);
            }
            return logDTOlist;
        }

        internal List<WorkoutLogDetailDTO> GetWorkoutLogs(string keyword)
        {
            List<WorkoutLog> workoutLogs = db.WorkoutLogs.Where(x=>x.Workout.Name.Contains(keyword)
                ||x.Member.Name.Contains(keyword)
                ||x.ID.ToString().Contains(keyword)
                ||x.MemberID.ToString().Contains(keyword)
                ||x.WorkoutID.ToString().Contains(keyword)
                ||x.EditTime.ToString().Contains(keyword)
                ).ToList();
            List<WorkoutLogDetailDTO> logDTOlist = new List<WorkoutLogDetailDTO>();
            foreach(var item in workoutLogs)
            {
                WorkoutLogDetailDTO dto = new WorkoutLogDetailDTO();
                dto.ID = item.ID;
                dto.MemberID = item.MemberID;
                dto.MemberName = item.Member.Name;               
                dto.WorkoutName = item.Workout.Name;
                dto.WorkoutHours = item.WorkoutHours;
                dto.Calories = Math.Round(item.Workout.Calories * item.WorkoutHours,2);
                logDTOlist.Add(dto);
            }
            return logDTOlist;
        }
        internal List<WorkoutLogDetailDTO> GetWorkoutLogs(DateTime starttime,DateTime end)
        {
            List<WorkoutLog> workoutLogs = db.WorkoutLogs.Where(x => x.EditTime >= starttime && x.EditTime <= end).ToList();
          
            List<WorkoutLogDetailDTO> logDTOlist = new List<WorkoutLogDetailDTO>();
            foreach (var item in workoutLogs)
            {
                WorkoutLogDetailDTO dto = new WorkoutLogDetailDTO();
                dto.MemberID = item.MemberID;
                dto.MemberName = item.Member.Name;
                dto.WorkoutName = item.Workout.Name;
                dto.WorkoutHours = item.WorkoutHours;
                dto.Calories = Math.Round(item.Workout.Calories * item.WorkoutHours, 2);
                logDTOlist.Add(dto);
            }
            return logDTOlist;
        }
        public void Update(WorkoutLog entity)
        {
            WorkoutLog workoutLog = db.WorkoutLogs.First(x => x.ID == entity.ID);
            workoutLog.MemberID = entity.MemberID;
            //workoutLog.Member.Name = entity.Member.Name;
            workoutLog.WorkoutID = entity.WorkoutID;
            //workoutLog.Workout.Name = entity.Workout.Name;
            workoutLog.EditTime = entity.EditTime;
            workoutLog.WorkoutHours = entity.WorkoutHours;
            //workoutLog.Workout.Calories = entity.Workout.Calories;
            db.SaveChanges();
        }
        public bool Delete( int ID)
        {
            WorkoutLog workoutLog = db.WorkoutLogs.First(x => x.ID == ID);
            db.WorkoutLogs.Remove(workoutLog);
            db.SaveChanges();
            return true;
        }
        public bool Add(WorkoutLog workoutLog)
        {
            db.WorkoutLogs.Add(workoutLog);
            db.SaveChanges();
            return true;
        }

        public bool IsWorkoutLogExist(int ID)
        {
            try
            {
                WorkoutLog workoutLog = db.WorkoutLogs.FirstOrDefault(x => x.ID== ID);
                if (workoutLog != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
