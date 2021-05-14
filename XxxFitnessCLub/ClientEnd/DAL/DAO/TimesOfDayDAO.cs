using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessCLub.ClientEnd.DAL.DAO
{
    class TimesOfDayDAO : HHContext
    {
        public List<TimesOfDay> GetTimesOfDay()
        {
            return db.TimesOfDays.ToList();
        }
    }
}
