using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessCLub.Model.DAL.DTO
{
    public class DietDetailsDTO
    {
        public int ID { get; set; }
        public int DietLogID { get; set; }
        public float Portion { get; set; }
        public int MealOptionID { get; set; }
    }
}
