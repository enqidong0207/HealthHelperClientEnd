using HHFirstDraft.DAL;
using HHFirstDraft.DAL.DAO;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.Model.DAL;

namespace HHFirstDraft.BLL
{
    class WorkoutLogBLL
    {
        WorkoutLogDAO dao = new WorkoutLogDAO();
        internal List<WorkoutLogDTO> GetWorkoutLogs()
        {
            return dao.GetWorkoutLogs();
        }

        internal bool Add(WorkoutLog entity)
        {
            return dao.Add(entity);
        }
    }
}
