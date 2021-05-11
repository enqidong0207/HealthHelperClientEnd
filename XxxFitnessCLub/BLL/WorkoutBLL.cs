﻿using HHFirstDraft.DAL;
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

        //恩旗
        public List<WorkoutDetailDTO> GetWorkoutByWCAL(int wcID = -1, int alID = -1)
        {

            return dao.GetWorkouts()
                .Where(e => (wcID == -1 || e.CategoryID == wcID) && (alID == -1 || e.ActivityLevelID == alID)).ToList();
        }

        //恩旗
        public string ToPlacesKeyword(string workout)
        {
            if (workout.Contains("跑")
                || workout.Contains("步")
                || workout.Contains("走")
                || workout == "衝刺")
            {
                return "公園";
            }
            else if (workout.Contains("樓梯"))
            {
                return null;
            }
            else if (workout.Contains("騎"))
            {
                return "自行車道";
            }
            else if (workout.Contains("瑜珈"))
            {
                return workout;
            }
            else if (workout.Contains("舞蹈"))
            {
                return workout;
            }
            else if (workout.Contains("游"))
            {
                return "游泳池";
            }
            else if (workout.Contains("跳繩"))
            {
                return "公園";
            }
            else if (workout.Contains("球"))
            {
                return workout + "場";
            }
            else if (workout.Contains("有氧") || workout.Contains("飛輪"))
            {
                return "健身房";
            }
            else
            {
                return null;
            }

        }
    }
}
