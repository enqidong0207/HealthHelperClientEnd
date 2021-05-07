using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft.DAL.DAO
{
    class WorkoutLogDAO : HHContext
    {
        //恩旗
        internal List<WorkoutLog> GetWorkoutLogs()
        {
            return db.WorkoutLogs.ToList();
        }

        //恩旗
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

        //恩旗
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

        //恩旗
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
