using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessCLub.ClientEnd.DAL.DTO
{
    class LikedMealDTO: LikedMeal
    {
        public LikedMealDTO(LikedMeal LM)
        {
            foreach (var propertyInfo in typeof(LikedMeal).GetProperties())
            {
                propertyInfo.SetValue(this, propertyInfo.GetValue(LM));
            }

        }
    }
}
