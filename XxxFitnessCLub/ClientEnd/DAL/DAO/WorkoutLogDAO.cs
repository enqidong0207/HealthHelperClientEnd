using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XxxFitnessCLub.ClientEnd.DAL.DAO
{
    //恩旗
    class WorkoutLogDAO : HHContext
    {
        internal List<WorkoutLog> GetWorkoutLogs()
        {
            return db.WorkoutLogs.ToList();
        }

        internal bool Add(WorkoutLog entity)
        {
            try
            {
                db.WorkoutLogs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }

        internal bool Edit(WorkoutLog entity)
        {
            WorkoutLog oldEntity = db.WorkoutLogs.Where(wl => wl.ID == entity.ID).SingleOrDefault();
            try
            {
                oldEntity.WorkoutID = entity.WorkoutID;
                oldEntity.EditTime = entity.EditTime;
                oldEntity.WorkoutHours = entity.WorkoutHours;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        internal bool Delete(WorkoutLog entity)
        {
            WorkoutLog oldEntity = db.WorkoutLogs.Where(wl => wl.ID == entity.ID).SingleOrDefault();
            try
            {
                db.WorkoutLogs.Remove(oldEntity);
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
