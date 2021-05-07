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
    public class WorkoutCategoryBLL
    {
        WorkoutCategoryDAO dao = new WorkoutCategoryDAO();
        public bool Add(WorkoutCategoryDetailDTO entity)
        {
            WorkoutCategory workoutCategory = new WorkoutCategory();
            workoutCategory.Name = entity.Name;
            return dao.Add(workoutCategory);
        }
        public List<WorkoutCategoryDetailDTO> GetCategories()
        {
            List<WorkoutCategoryDetailDTO> dtoList = new List<WorkoutCategoryDetailDTO>();
            dtoList = dao.GetCategories();
            return dtoList;
        }
        public List<WorkoutCategoryDetailDTO> GetCategories(string text)
        {
            List<WorkoutCategoryDetailDTO> dtoList = new List<WorkoutCategoryDetailDTO>();
            dtoList = dao.GetCategories(text);
            return dtoList;
        }

        public void Update(WorkoutCategoryDetailDTO entity)
        {
            WorkoutCategory category = new WorkoutCategory();
            category.ID = entity.ID;
            category.Name = entity.Name;
            dao.Update(category);
        }

        public bool IsCategoryExist(string text)
        {
            return dao.IsCategoryExist(text);
        }

        public bool HasWorkouts(int ID)
        {
            return dao.HasWorkouts(ID);
        }

        public bool Delete(int ID)
        {
            return dao.Delete(ID);
        }
        WorkoutDAO workoutDAO = new WorkoutDAO();
        public List<WorkoutDetailDTO> GetWorkouts(int ID)
        {
            List<WorkoutDetailDTO> dtoList = new List<WorkoutDetailDTO>();
            dtoList = workoutDAO.GetWorkouts(ID);
            return dtoList;
        }

        //恩旗
        public List<ClbItem> GetWcItems()
        {
            return GetCategories().Select(wc => new ClbItem 
            { 
                Text = wc.Name,
                wcID = wc.ID
            }).ToList();
        }
    }

    //恩旗
    public class ClbItem
    {
        public string Text { get; set; }

        public int wcID { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
