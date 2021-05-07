using HHFirstDraft.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XxxFitnessCLub.DAL.DAO
{
    class WorkoutPreferencesDAO : HHContext
    {
        //恩旗
        internal bool AddPreferences(List<WorkoutPreference> wplist)
        {
            try
            {
                foreach (var item in wplist)
                {
                    db.WorkoutPreferences.Add(item);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
