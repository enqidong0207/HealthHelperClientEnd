using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.DAL;
using XxxFitnessCLub.DAL.DAO;

namespace XxxFitnessCLub.BLL
{
    //恩旗
    class WorkoutPreferencesBLL
    {
        
        WorkoutPreferencesDAO dao = new WorkoutPreferencesDAO();

        public bool AddPreferences(List<WorkoutPreference> wplist)
        {
            return dao.AddPreferences(wplist);
        }

        public bool EditPreferences(List<WorkoutPreference> wplist)
        {
            return dao.EditPreferences(wplist);
        }

        public List<WorkoutPreference> GetPreferences(int MemberID)
        {
            return dao.GetPreferences(MemberID);
        }
    }
}
