using HHFirstDraft.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft.DAL.DAO
{
    class TimesOfDayDAO : HHContext
    {
        public List<TimesOfDay> GetTimesOfDay()
        {
            return db.TimesOfDays.ToList();
        }
    }
}
