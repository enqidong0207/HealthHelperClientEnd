using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd.DAL.DAO
{
    class LikedMealDAO : HHContext
    {
        public int LikedMealsCount()
        {
            try
            {
                int count = db.LikedMeals.Where(lm => lm.MemberID == StaticUser.UserID).Count();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Add(LikedMeal likeMeal)
        {
            try
            {
                bool hasAdded = db.LikedMeals.Where(lm => lm.MemberID == StaticUser.UserID).Any(ml => ml.MealOptionID == likeMeal.MealOptionID);
                if (!hasAdded)
                {
                    db.LikedMeals.Add(likeMeal);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("此餐點已在我的最愛");
                    return false;
                }


            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        internal List<MealDetailDTO> GetLikedMeals()
        {
            List<MealDetailDTO> likedMealList;
            var q = from lm in db.LikedMeals
                    where lm.MemberID == StaticUser.UserID
                    select new MealDetailDTO
                    {
                        ID = lm.MealOption.ID,
                        Name = lm.MealOption.Name,
                        Calories = lm.MealOption.Calories,
                        Image = lm.MealOption.Image,
                    };
            likedMealList = q.ToList();
            return likedMealList;



        }
    }
}
