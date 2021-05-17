using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.ClientEnd.DAL.DAO;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd.BLL
{
    class LikedMealBLL
    {

        LikedMealDAO dao = new LikedMealDAO();
        public int LikedMealsCount
        {
            get 
            {
                return dao.LikedMealsCount();
            }
        }

        public bool Add(LikedMealDTO entity)
        {


            LikedMeal likedmeal = new LikedMeal();
            likedmeal.MemberID = entity.MemberID;
            likedmeal.MealOptionID = entity.MealOptionID;
            
            return dao.Add(likedmeal);
        }

        internal List<MealDetailDTO> GetLikedMeals()
        {
            return dao.GetLikedMeals();
        }
    }
}
