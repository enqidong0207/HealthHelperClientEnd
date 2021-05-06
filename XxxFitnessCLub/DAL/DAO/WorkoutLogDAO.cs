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
        internal List<WorkoutLogDTO> GetWorkoutLogs()
        {
            List<WorkoutLogDTO> list = new List<WorkoutLogDTO>();
            foreach (var wl in db.WorkoutLogs)
            {
                list.Add(new WorkoutLogDTO(wl));
            }

            return list;
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
    }
}
