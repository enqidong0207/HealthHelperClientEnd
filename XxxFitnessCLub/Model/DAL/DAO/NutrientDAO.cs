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
            dto.K = (float)nutrient.Calcium;


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

        public bool HasTag(int NurientID)
        {
            Nutrient tag = db.Nutrients.FirstOrDefault(x => x.ID == NurientID);
            if (tag != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<MealDetailDTO> Nutrient_ComboBox_Selected(string text)
        {

            List<MealDetailDTO> dtolist = new List<MealDetailDTO>();
            if (text == "脂肪")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.Fat).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "蛋白質")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.Protein).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "碳水化合物")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.Carbs).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "醣")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.Sugar).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "維生素A")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.VitA).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "維生素B")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.VitB).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "維生素C")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.VitC).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "維生素D")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.VitD).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "維生素E")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.VitE).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "鈉")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.Na).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            else if (text == "鉀")
            {
                var list = db.MealOptions.OrderByDescending(x => x.Nutrient.Calcium).Take(5).ToList();
                foreach (var item in list)
                {
                    MealDetailDTO dto = new MealDetailDTO();
                    dto.Name = item.Name;
                    dto.Calories = Convert.ToInt32(item.Calories);
                    dto.Fat = (float)item.Nutrient.Fat;
                    dto.Protein = (float)item.Nutrient.Protein;
                    dto.Carbs = (float)item.Nutrient.Carbs;
                    dto.Sugar = (float)item.Nutrient.Sugar;
                    dto.VitA = (float)item.Nutrient.VitA;
                    dto.VitB = (float)item.Nutrient.VitB;
                    dto.VitC = (float)item.Nutrient.VitC;
                    dto.VitD = (float)item.Nutrient.VitD;
                    dto.VitE = (float)item.Nutrient.VitE;
                    dto.Na = (float)item.Nutrient.Na;
                    dto.K = (float)item.Nutrient.Calcium;
                    dtolist.Add(dto);
                }
            }
            return dtolist;
        }


        public List<MealDetailDTO> Nutrient_Of_AllDay(int id)//NutrientID
        {
            var list = db.MealOptions.Where(x => x.Nutrient.ID == id);
            List<MealDetailDTO> dtoList = new List<MealDetailDTO>();
            foreach (var item in list)
            {
                NutrientBLL nutrientBLL = new NutrientBLL();
                MealDetailDTO dto = new MealDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.Calories = Convert.ToInt32(item.Calories);
                dto.Image = item.Image;
                dto.Nutrient = nutrientBLL.GetNutrient(dto.ID);
                dto.NutrientID = dto.Nutrient.ID;
                dto.Fat = dto.Nutrient.Fat;
                dto.Protein = dto.Nutrient.Protein;
                dto.Carbs = dto.Nutrient.Carbs;
                dto.Sugar = dto.Nutrient.Sugar;
                dto.VitA = dto.Nutrient.VitA;
                dto.VitB = dto.Nutrient.VitB;
                dto.VitC = dto.Nutrient.VitC;
                dto.VitD = dto.Nutrient.VitD;
                dto.VitE = dto.Nutrient.VitE;
                dto.Na = dto.Nutrient.Na;
                dto.K = dto.Nutrient.K;
                dtoList.Add(dto);
            }
            
            return dtoList;
        }
    }
}



