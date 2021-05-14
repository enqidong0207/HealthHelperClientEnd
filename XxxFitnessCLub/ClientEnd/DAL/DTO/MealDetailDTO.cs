using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessCLub.ClientEnd.DAL.DTO
{
    public class MealDetailDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public double Calories { get; set; }
        public List<TagCategoryDetailDTO> Tags { get; set; }
    }
}
