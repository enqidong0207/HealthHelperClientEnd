using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.Model.DAL;

namespace HHFirstDraft.DAL.DAO
{
    public class TagCategoryDAO : HHContext
    {
        public List<TagCategoryDetailDTO> GetTags()
        {
            var list = db.MealTagCategories.ToList();
            List<TagCategoryDetailDTO> dtoList = new List<TagCategoryDetailDTO>();
            foreach (var item in list)
            {
                TagCategoryDetailDTO dto = new TagCategoryDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<TagCategoryDetailDTO> GetTags(string text)
        {
            var list = db.MealTagCategories.Where(x => x.Name.Contains(text)).ToList();
            List<TagCategoryDetailDTO> dtoList = new List<TagCategoryDetailDTO>();
            foreach (var item in list)
            {
                TagCategoryDetailDTO dto = new TagCategoryDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<MealDetailDTO> GetMealsWithTagID(int tagID)
        {
            var list = (from m in db.MealOptions
                        from t in m.MealTags
                        join c in db.MealTagCategories
                        on t.MealTagCategoriesID equals c.ID
                        where c.ID == tagID
                        select new
                        {
                            Name = m.Name,
                            ID = m.ID,
                            Calories = m.Calories
                        }).ToList();
            List<MealDetailDTO> dtoList = new List<MealDetailDTO>();
            foreach (var item in list)
            {
                MealDetailDTO dto = new MealDetailDTO();
                dto.Name = item.Name;
                dto.ID = item.ID;
                dto.Calories =Convert.ToInt32( item.Calories);
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public void Delete(int ID)
        {
            try
            {
                MealTagCategory category = db.MealTagCategories.First(x => x.ID == ID);
                db.MealTagCategories.Remove(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void RemoveAttachedTag(int ID)
        {
            try
            {
                List<MealTag> list = db.MealTags.Where(x => x.MealTagCategoriesID == ID).ToList();
                foreach (MealTag item in list)
                {
                    db.MealTags.Remove(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool HasMeals(int ID)
        {
            try
            {
                MealTag tag = db.MealTags.FirstOrDefault(x => x.MealTagCategoriesID == ID);
                return tag != null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(MealTagCategory entity)
        {
            try
            {
                MealTagCategory category = db.MealTagCategories.First(x => x.ID == entity.ID);
                category.Name = entity.Name;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Add(MealTagCategory entity)
        {
            try
            {
                db.MealTagCategories.Add(entity);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IsTagExist(string text)
        {
            try
            {
                MealTag tag = db.MealTags.FirstOrDefault(x => x.MealTagCategory.Name == text);
                return tag != null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
