using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessClub.BackEnd.DAL.DTO;
using XxxFitnessCLub;

namespace XxxFitnessClub.BackEnd.DAL.DAO
{
    public class NutrientDAO : HHContext
    {
        public NutrientDTO GetNutrient(int ID)
        {
            MealOption meal = db.MealOptions.First(x => x.ID == ID);
            NutrientDTO dto = new NutrientDTO();
            int nutrientID = (int)meal.NutrientID;

            Nutrient nutrient = db.Nutrients.First(x => x.ID == nutrientID);
            dto.ID = nutrient.ID;

            //把資料庫資料匯入清單
            dto.Fat = (float)nutrient.Fat;
            dto.Protein = (float)nutrient.Protein;
            dto.Carbs = (float)nutrient.Carbs;
            dto.Sugar = (float)nutrient.Sugar;
            dto.VitA = (float)nutrient.VitA;
            dto.VitB = (float)nutrient.VitB;
            dto.VitC = (float)nutrient.VitC;
            dto.VitD = (float)nutrient.VitD;
            dto.VitE = (float)nutrient.VitE;
            dto.Na = (float)nutrient.Na;
            dto.K = (float)nutrient.Potassium;
            

            return dto;
        }
        
        //    var list = db.Nutrients.ToList(); //資料庫
        //    List<NutrientDTO> dtoList = new List<NutrientDTO>(); //MODEL清單
        //    foreach (var item in list)
        //    {
        //        NutrientDTO dto = new NutrientDTO();
        //        dto.ID = item.ID; //把資料庫資料匯入清單
        //        dto.Fat =(float) item.Fat;
        //        dto.Protein = (float)item.Protein;
        //        dto.Carbs = (float)item.Carbs;
        //        dto.Sugar = (float)item.Sugar;
        //        dto.VitA = (float)item.VitA;
        //        dto.VitB = (float)item.VitB;
        //        dto.VitC = (float)item.VitC;
        //        dto.VitD = (float)item.VitD;
        //        dto.VitE = (float)item.VitE;
        //        dto.Na = (float)item.Na;
        //        dto.K = (float)item.K;
        //        dtoList.Add(dto);
        //    }
        //    return dtoList;
        //}

        public void Update(Nutrient entity)
        {
            Nutrient nutrient = db.Nutrients.First(x => x.ID == entity.ID);
            //NutrientDTO dto = new NutrientDTO();
            //int nutrientID = (int)nutrient1.ID;

            nutrient.Fat = (float)entity.Fat;
            nutrient.Protein = (float)entity.Protein;
            nutrient.Carbs = (float)entity.Carbs;
            nutrient.Sugar = (float)entity.Sugar;
            nutrient.VitA = (float)entity.VitA;
            nutrient.VitB = (float)entity.VitB;
            nutrient.VitC = (float)entity.VitC;
            nutrient.VitD = (float)entity.VitD;
            nutrient.VitE = (float)entity.VitE;
            nutrient.Na = (float)entity.Na;
            nutrient.Potassium = (float)entity.Potassium;
            db.SaveChanges();
            //Nutrient myNutrient = new Nutrient();
            //myNutrient.Fat = nutrient.Fat;
            //myNutrient.Protein = nutrient.Protein;
            //myNutrient.Carbs = nutrient.Carbs;
            //myNutrient.Sugar = nutrient.Sugar;
            //myNutrient.VitA = nutrient.VitA;
            //myNutrient.VitB = nutrient.VitB;
            //myNutrient.VitC = nutrient.VitC;
            //myNutrient.VitD = nutrient.VitD;
            //myNutrient.VitE = nutrient.VitE;
            //myNutrient.Na = nutrient.Na;
            //myNutrient.K = nutrient.K;
            //db.Nutrients.Add(nutrient);

            
        }
        public int Add(Nutrient nutrient)
        {
            try
            {
                db.Nutrients.Add(nutrient);
                db.SaveChanges();
                return nutrient.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Delete(int ID)
        {
            try
            {
                
                Nutrient nutrient = db.Nutrients.First(x => x.ID == ID);
                db.Nutrients.Remove(nutrient);
                db.SaveChanges();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool HasTag(int NurientID)
        {
            Nutrient tag = db.Nutrients.FirstOrDefault(x =>x.ID == NurientID);
            if (tag != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
