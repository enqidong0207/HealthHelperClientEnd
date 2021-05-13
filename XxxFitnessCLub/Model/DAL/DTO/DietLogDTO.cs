using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessCLub.Model.DAL.DTO
{
    public class DietLogDTO
    {
        public int ID { get; set; }
        public int MemberID { get; set; }
        public int TimeOfDayID { get; set; }
        public DateTime EditTime { get; set; }
    }
}
