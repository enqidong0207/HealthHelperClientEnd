using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHFirstDraft.DAL;
using HHFirstDraft.DAL.DAO;
using HHFirstDraft.DAL.DAO;

namespace HHFirstDraft.BLL
{
    public class NutrientBLL
    {
        NutrientDAO dao = new NutrientDAO();

        public NutrientDTO GetNutrient(int ID)
        {
            MealDetailDTO dto = new MealDetailDTO();
            dto.Nutrient = dao.GetNutrient(ID);
            return dto.Nutrient;
        }


        //public NutrientDTO GetNutrientLastID()
        //{
        //    NutrientDTO dto = new NutrientDTO();
        //    return dto.ID.ToString().Last();
        //}
        public List<MealDetailDTO> selectNutrient(string text)
        {
            MealDTO dto = new MealDTO();
            dto.Meals = dao.Nutrient_ComboBox_Selected(text);
            return dto.Meals;
        }


    }
}

