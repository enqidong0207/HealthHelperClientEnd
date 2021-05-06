using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft.DAL.DAO
{
    public class WorkoutDAO : HHContext
    {
        internal List<WorkoutDetailDTO> GetWorkouts()
        {
            List<Workout> workouts = db.Workouts.ToList();
            List<WorkoutDetailDTO> workoutDTOList = new List<WorkoutDetailDTO>();
            foreach (var item in workouts)
            {
                WorkoutDetailDTO dto = new WorkoutDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.Calories = item.Calories;
                dto.CategoryID = item.WorkoutCategoryID;
                dto.CategoryName = item.WorkoutCategory.Name;
                dto.ActivityLevelID = item.ActivityLevelID;
                dto.ActivityLevel = item.ActivityLevel.Description;
                workoutDTOList.Add(dto);
            }
            return workoutDTOList;
        }

        public bool Add(Workout entity)
        {
            try
            {
                db.Workouts.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        internal List<WorkoutDetailDTO> GetWorkouts(string text)
        {
            List<Workout> workouts = db.Workouts.Where(x => x.Name.Contains(text) || x.WorkoutCategory.Name.Contains(text)) .ToList();
            List<WorkoutDetailDTO> workoutDTOList = new List<WorkoutDetailDTO>();
            foreach (var item in workouts)
            {
                WorkoutDetailDTO dto = new WorkoutDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.Calories = item.Calories;
                dto.CategoryID = item.WorkoutCategoryID;
                dto.CategoryName = item.WorkoutCategory.Name;
                dto.ActivityLevelID = item.ActivityLevelID;
                dto.ActivityLevel = item.ActivityLevel.Description;
                workoutDTOList.Add(dto);
            }
            return workoutDTOList;
        }

        public List<WorkoutDetailDTO> GetWorkouts(int ID)
        {
            List<Workout> list = db.Workouts.Where(x => x.WorkoutCategoryID == ID).ToList();
            List<WorkoutDetailDTO> dtoList = new List<WorkoutDetailDTO>();
            foreach (Workout item in list)
            {
                WorkoutDetailDTO dto = new WorkoutDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.Calories = item.Calories;
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public bool IsWorkoutExist(string name)
        {
            try
            {
                Workout workout = db.Workouts.FirstOrDefault(x => x.Name == name);
                if (workout != null)
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

        public bool Delete(int ID)
        {
            try
            {
                Workout workout = db.Workouts.First(x => x.ID == ID);
                db.Workouts.Remove(workout);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Workout entity)
        {
            Workout workout = db.Workouts.FirstOrDefault(x => x.ID == entity.ID);
            workout.Name = entity.Name;
            workout.Calories = entity.Calories;
            workout.ActivityLevelID = entity.ActivityLevelID;
            workout.WorkoutCategoryID = entity.WorkoutCategoryID;
            db.SaveChanges();
        }
    }
}
