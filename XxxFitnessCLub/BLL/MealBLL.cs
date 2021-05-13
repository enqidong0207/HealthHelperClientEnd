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
    public class MealBLL
    {
        MealDAO dao = new MealDAO();
        public MealDTO GetMeals()
        {
            MealDTO dto = new MealDTO();
            dto.Meals = dao.GetMeals();
            return dto;
        }

        public int Add(MealDetailDTO entity)
        {
            MealOption meal = new MealOption();
            meal.Name = entity.Name;
            meal.Calories = entity.Calories;
            return dao.Add(meal);
        }

        public bool IsMealExist(string name)
        {
            return dao.IsMealExist(name);
        }

        public void Update(MealDetailDTO entity)
        {
            MealOption meal = new MealOption();
            meal.ID = entity.ID;
            meal.Name = entity.Name;
            meal.Calories = entity.Calories;
            dao.Update(meal);
        }

        public bool HasTag(int mealID, int categoryID)
        {
            return dao.HasTag(mealID, categoryID);
        }

        public void AddTag(int mealID, int categoryID)
        {
            dao.AddTag(mealID, categoryID);
        }

        public MealDTO GetMeals(string text)
        {
            MealDTO dto = new MealDTO();
            dto.Meals = dao.GetMeals(text);
            return dto;
        }

        public bool Delete(int ID)
        {
            return dao.Delete(ID);
        }

        public void RemoveTag(int mealID, int categoryID)
        {
            dao.RemoveTag(mealID, categoryID);
        }

        public List<TagCategoryDetailDTO> GetTagsWithMealID(int ID)
        {
            List<TagCategoryDetailDTO> dtoList = new List<TagCategoryDetailDTO>();
            dtoList = dao.GetTagsWithMealID(ID);
            return dtoList;
        }

        public bool HasTags(int ID)
        {
            return dao.HasTags(ID);
        }

        public void RemoveTags(int ID)
        {
            dao.RemoveTags(ID);
        }

        //采馨加的
        public MealDetailDTO GetMeal(int ID)
        {
            MealDetailDTO theMeal = new MealDetailDTO();
            MealOption mOpt =  dao.GetMeal(ID);
            theMeal.ID = mOpt.ID;
            theMeal.Name = mOpt.Name;
            theMeal.Calories = (int)mOpt.Calories;
            theMeal.Image = mOpt.Image;
            return theMeal;
        }
    }
}
