using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHFirstDraft.DAL.DTO
{
    public class MealDetailDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public byte[] Image { get; set; }

        public List<TagCategoryDetailDTO> Tags { get; set; }
    }
}
