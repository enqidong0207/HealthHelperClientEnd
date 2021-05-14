using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.ClientEnd.DAL;
using XxxFitnessCLub.ClientEnd.DAL.DAO;

namespace XxxFitnessCLub.ClientEnd.BLL
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
