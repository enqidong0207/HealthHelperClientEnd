using HHFirstDraft.DAL;
using HHFirstDraft.DAL.DAO;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHFirstDraft.DAL;
using HHFirstDraft.DAL;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft.BLL
{
    public class TagCategoryBLL
    {
        TagCategoryDAO dao = new TagCategoryDAO();
        public List<TagCategoryDetailDTO> GetTags()
        {
            return dao.GetTags();
        }
        public List<TagCategoryDetailDTO> GetTags(string text)
        {
            return dao.GetTags(text);
        }
        public List<MealDetailDTO> GetMealsWithTagID(int tagID)
        {
            List<MealDetailDTO> dtoList = new List<MealDetailDTO>();
            dtoList = dao.GetMealsWithTagID(tagID);
            return dtoList;
        }

        public bool IsTagExist(string text)
        {
            return dao.IsTagExist(text);
        }

        public void Add(TagCategoryDetailDTO entity)
        {
            MealTagCategory tag = new MealTagCategory();
            tag.Name = entity.Name;
            dao.Add(tag);
        }

        public void Update(TagCategoryDetailDTO entity)
        {
            MealTagCategory tag = new MealTagCategory();
            tag.Name = entity.Name;
            tag.ID = entity.ID;
            dao.Update(tag);
        }

        public bool HasMeals(int ID)
        {
            return dao.HasMeals(ID);
        }

        public void RemoveAttachedTag(int ID)
        {
            dao.RemoveAttachedTag(ID);
        }

        public void Delete(int ID)
        {
            dao.Delete(ID);
        }
    }
}
