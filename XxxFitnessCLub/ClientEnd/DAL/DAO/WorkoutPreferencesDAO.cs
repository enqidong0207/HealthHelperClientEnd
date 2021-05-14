using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XxxFitnessCLub.ClientEnd.DAL.DAO
{
    //恩旗
    class WorkoutPreferencesDAO : HHContext
    {
        internal bool AddPreferences(List<WorkoutPreference> wplist)
        {
            try
            {
                foreach (var item in wplist)
                {
                    var q = db.WorkoutPreferences
                        .Where(wp => wp.MemberID == item.MemberID && wp.WorkoutCategoryID == item.MemberID)
                        .SingleOrDefault();

                    if (q == null)
                    {
                        db.WorkoutPreferences.Add(item);
                    }
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

        internal bool EditPreferences(List<WorkoutPreference> wplist)
        {
            try
            {
                foreach (var item in wplist)
                {
                    var q = db.WorkoutPreferences
                        .Where(wp => wp.MemberID == item.MemberID && wp.WorkoutCategoryID == item.WorkoutCategoryID)
                        .SingleOrDefault();

                    if (q == null)
                    {
                        db.WorkoutPreferences.Add(item);
                    }
                }

                foreach (var item in db.WorkoutPreferences)
                {
                    var q = wplist
                        .Where(wp => item.MemberID == wp.MemberID && item.WorkoutCategoryID == wp.WorkoutCategoryID)
                        .SingleOrDefault();

                    if (q == null)
                    {
                        db.WorkoutPreferences.Remove(item);
                    }
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

        internal List<WorkoutPreference> GetPreferences(int MemberID)
        {
            return db.WorkoutPreferences.Where(wp => wp.MemberID == MemberID).ToList();
        }
    }
}
