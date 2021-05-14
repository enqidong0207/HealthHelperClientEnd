using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessCLub.ClientEnd.DAL.DTO
{
    public class TagCategoryDTO
    {
        public List<TagCategoryDetailDTO> TagCategories { get; set; }
        public List<MealDetailDTO> Meals { get; set; }
    }
}
