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
    public class WorkoutBLL
    {
        WorkoutDAO dao = new WorkoutDAO();
        ActivityLevelDAO activityLevelDAO = new ActivityLevelDAO();
        WorkoutCategoryDAO workoutCatDAO = new WorkoutCategoryDAO();

        public WorkoutDTO GetWorkouts()
        {
            WorkoutDTO dto = new WorkoutDTO();
            dto.Workouts = dao.GetWorkouts();
            dto.ActivityLevels = activityLevelDAO.GetLevels();
            dto.Categories = workoutCatDAO.GetCategories();
            return dto;
        }

        public bool Add(WorkoutDetailDTO entity)
        {
            Workout workout = new Workout();
            workout.Name = entity.Name;
            workout.Calories = entity.Calories;
            workout.ActivityLevelID = entity.ActivityLevelID;
            workout.WorkoutCategoryID = (int)entity.CategoryID;
            return dao.Add(workout);
        }

        public WorkoutDTO GetWorkouts(string text)
        {
            WorkoutDTO dto = new WorkoutDTO();
            dto.Workouts = dao.GetWorkouts(text);
            dto.ActivityLevels = activityLevelDAO.GetLevels();
            dto.Categories = workoutCatDAO.GetCategories();
            return dto;
        }

        public void Update(WorkoutDetailDTO entity)
        {
            Workout workout = new Workout();
            workout.ID = entity.ID;
            workout.Name = entity.Name;
            workout.Calories = entity.Calories;
            workout.ActivityLevelID = entity.ActivityLevelID;
            workout.WorkoutCategoryID = (int)entity.CategoryID;
            dao.Update(workout);
        }

        public bool Delete(int ID)
        {
            return dao.Delete(ID);
        }

        public bool IsWorkoutExist(string name)
        {
            return dao.IsWorkoutExist(name);
        }
    }
}
