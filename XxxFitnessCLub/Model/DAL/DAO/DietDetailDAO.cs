using HHFirstDraft.DAL.DAO;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.Model.BLL;
using XxxFitnessCLub.Model.DAL.DTO;

namespace XxxFitnessCLub.Model.DAL.DAO
{
    public class DietDetailDAO :HHContext
    {


        //public List<Nutrient> GetAllDayNutrient()
        //{
        //    int memberID = 3;
        //    DateTime EditTime = new DateTime(2020, 5, 3);
        //    TimesOfDayDTO tdto = new TimesOfDayDTO();
        //    DietDetailsDTO dd_dto = new DietDetailsDTO();
        //    DietLogDTO dldto = new DietLogDTO();
        //    NutrientDTO ndto = new NutrientDTO();

        //    var list = db.MealOptions.ToList();
        //    foreach(var item in list)
        //    {
        //        NutrientBLL nutrientBLL = new NutrientBLL();
        //        MealDetailDTO mdto = new MealDetailDTO();
        //        mdto.ID = item.ID;
        //        mdto.Name = item.Name;
        //        mdto.Calories = Convert.ToInt32(item.Calories);
        //        mdto.Image = item.Image;
        //        mdto.Nutrient = nutrientBLL.GetNutrient(mdto.ID);
        //        mdto.NutrientID = mdto.Nutrient.ID;
        //        mdto.Fat = mdto.Nutrient.Fat;
        //        mdto.Protein = mdto.Nutrient.Protein;
        //        mdto.Carbs = mdto.Nutrient.Carbs;
        //        mdto.Sugar = mdto.Nutrient.Sugar;
        //        mdto.VitA = mdto.Nutrient.VitA;
        //        mdto.VitB = mdto.Nutrient.VitB;
        //        mdto.VitC = mdto.Nutrient.VitC;
        //        mdto.VitD = mdto.Nutrient.VitD;
        //        mdto.VitE = mdto.Nutrient.VitE;
        //        mdto.Na = mdto.Nutrient.Na;
        //        mdto.K = mdto.Nutrient.K;

        //    }


        //    if (dldto.MemberID == 3)
        //    {
        //        if (dldto.EditTime.Year == 2020 && dldto.EditTime.Month == 5 && dldto.EditTime.Day == 3)
        //        {
                   
        //        }
        //    }
        //}
        
        //public List<MealDetailDTO> GetMeals(string text)
        //{
        //    var list = db.MealOptions.Where(x => x.Name.Contains(text)).ToList();
        //    List<MealDetailDTO> dtoList = new List<MealDetailDTO>();
        //    foreach (var item in list)
        //    {
        //        NutrientBLL nutrientBLL = new NutrientBLL();
        //        MealDetailDTO dto = new MealDetailDTO();
        //        dto.ID = item.ID;
        //        dto.Name = item.Name;
        //        dto.Calories = Convert.ToInt32(item.Calories);
        //        dto.Image = item.Image;
        //        dto.Nutrient = nutrientBLL.GetNutrient(dto.ID);
        //        dto.NutrientID = dto.Nutrient.ID;
        //        dto.Fat = dto.Nutrient.Fat;
        //        dto.Protein = dto.Nutrient.Protein;
        //        dto.Carbs = dto.Nutrient.Carbs;
        //        dto.Sugar = dto.Nutrient.Sugar;
        //        dto.VitA = dto.Nutrient.VitA;
        //        dto.VitB = dto.Nutrient.VitB;
        //        dto.VitC = dto.Nutrient.VitC;
        //        dto.VitD = dto.Nutrient.VitD;
        //        dto.VitE = dto.Nutrient.VitE;
        //        dto.Na = dto.Nutrient.Na;
        //        dto.K = dto.Nutrient.K;
        //        dtoList.Add(dto);
        //    }
        //    return dtoList;
        //}
    }
}
