using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessClub.BackEnd.DAL.DAO;
using XxxFitnessClub.BackEnd.DAL.DTO;
using XxxFitnessCLub;

namespace XxxFitnessClub.BackEnd.BLL
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
        public void Delete(int ID)
        {
            dao.Delete(ID);
        } 
        
        //public NutrientDTO GetNutrientLastID()
        //{
        //    NutrientDTO dto = new NutrientDTO();
        //    return dto.ID.ToString().Last();
        //}
        public void Update(NutrientDTO entity)
        {
            NutrientDAO dao = new NutrientDAO();
            Nutrient nutrient = new Nutrient();
            nutrient.ID = entity.ID;
            nutrient.Fat = entity.Fat;
            nutrient.Protein = entity.Protein;
            nutrient.Carbs = entity.Carbs;
            nutrient.Sugar = entity.Sugar;
            nutrient.VitA = entity.VitA;
            nutrient.VitB = entity.VitB;
            nutrient.VitC = entity.VitC;
            nutrient.VitD = entity.VitD;
            nutrient.VitE = entity.VitE;
            nutrient.Na = entity.Na;
            nutrient.Potassium = entity.K;

            dao.Update(nutrient);
        }
        public int Add(NutrientDTO entity)
        {
            Nutrient nutrient = new Nutrient();
            nutrient.Fat = entity.Fat;
            nutrient.Protein = entity.Protein;
            nutrient.Carbs = entity.Carbs;
            nutrient.Sugar = entity.Sugar;
            nutrient.VitA = entity.VitA;
            nutrient.VitB = entity.VitB;
            nutrient.VitC = entity.VitC;
            nutrient.VitD = entity.VitD;
            nutrient.VitE = entity.VitE;
            nutrient.Na = entity.Na;
            nutrient.Potassium = entity.K;
            return dao.Add(nutrient);
        }
    }
}
