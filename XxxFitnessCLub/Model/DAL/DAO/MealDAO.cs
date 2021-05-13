using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.Model.DAL;

namespace HHFirstDraft.DAL.DAO
{
    public class MealDAO : HHContext
    {
        public List<MealDetailDTO> GetMeals()
        {
            var list = db.MealOptions.ToList();

            List<MealDetailDTO> dtoList = new List<MealDetailDTO>();
            foreach (var item in list)
            {
                MealDetailDTO dto = new MealDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.Calories = (int)item.Calories;
                List<TagCategoryDetailDTO> tagDetailList = new List<TagCategoryDetailDTO>();
                var tagList = db.MealTags.Where(x => x.MealOptionID == item.ID).ToList();
                foreach (var tag in tagList)
                {
                    TagCategoryDetailDTO tagDTO = new TagCategoryDetailDTO();
                    tagDTO.ID = tag.ID;
                    tagDTO.Name = tag.MealTagCategory.Name;
                    tagDetailList.Add(tagDTO);
                }
                dto.Tags = tagDetailList;
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public bool HasTag(int mealID, int categoryID)
        {
            MealTag tag = db.MealTags.FirstOrDefault(x => x.MealOptionID == mealID && x.MealTagCategoriesID == categoryID);
            if (tag!= null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddTag(int mealID, int categoryID)
        {
            try
            {
                MealTag tag = new MealTag();
                tag.MealOptionID = mealID;
                tag.MealTagCategoriesID = categoryID;
                db.MealTags.Add(tag);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool HasTags(int ID)
        {
            MealTag tag = db.MealTags.FirstOrDefault(x => x.MealOptionID == ID);
            if (tag != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveTags(int ID)
        {
            List<MealTag> list = db.MealTags.Where(x => x.MealOptionID == ID).ToList();
            foreach (MealTag item in list)
            {
                db.MealTags.Remove(item);
                db.SaveChanges();
            }
        }

        public void RemoveTag(int mealID, int categoryID)
        {
            try
            {
                MealTag tag = db.MealTags.First(x => x.MealOptionID == mealID && x.MealTagCategoriesID == categoryID);
                db.MealTags.Remove(tag);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Add(MealOption meal)
        {
            try
            {
                db.MealOptions.Add(meal);
                db.SaveChanges();
                return meal.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TagCategoryDetailDTO> GetTagsWithMealID(int ID)
        {
            var list = db.MealTags.Where(x => x.MealOptionID == ID);
            List <TagCategoryDetailDTO > dtoList = new List<TagCategoryDetailDTO>();
            foreach (var item in list)
            {
                TagCategoryDetailDTO dto = new TagCategoryDetailDTO();
                dto.ID = item.MealTagCategoriesID;
                dto.Name = item.MealTagCategory.Name;
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public void Update(MealOption entity)
        {
            MealOption meal = db.MealOptions.First(x => x.ID == entity.ID);
            meal.Name = entity.Name;
            meal.Calories = entity.Calories;
            db.SaveChanges();
        }

        public List<MealDetailDTO> GetMeals(string text)
        {
            var list = db.MealOptions.Where(x => x.Name.Contains(text)).ToList();
            List<MealDetailDTO> dtoList = new List<MealDetailDTO>();
            foreach (var item in list)
            {
                MealDetailDTO dto = new MealDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.Calories = (int)item.Calories;
                List<TagCategoryDetailDTO> tagDetailList = new List<TagCategoryDetailDTO>();
                var tagList = db.MealTags.Where(x => x.MealOptionID == item.ID).ToList();
                foreach (var tag in tagList)
                {
                    TagCategoryDetailDTO tagDTO = new TagCategoryDetailDTO();
                    tagDTO.ID = tag.ID;
                    tagDTO.Name = tag.MealTagCategory.Name;
                    tagDetailList.Add(tagDTO);
                }
                dto.Tags = tagDetailList;
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public bool Delete(int ID)
        {
            try
            {
                MealOption meal = db.MealOptions.First(x => x.ID == ID);
                db.MealOptions.Remove(meal);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IsMealExist(string name)
        {
            try
            {
                MealOption meal = db.MealOptions.FirstOrDefault(x => x.Name == name);
                return meal != null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //采馨加的
        public MealOption GetMeal(int ID)
        {
            try
            {
                MealOption theMeal = db.MealOptions.First(x => x.ID == ID);
               
                return theMeal;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}
