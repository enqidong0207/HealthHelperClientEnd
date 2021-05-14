
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.ClientEnd.DAL;
using XxxFitnessCLub.ClientEnd.DAL.DAO;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd.BLL
{
    public class WeightLogBLL
    {
        WeightLogDAO dao = new WeightLogDAO();
        public List<WeightLogDetailDTO> GetWeightLogs()
        {
            return dao.GetWeightLogs();
        }
        public List<WeightLogDetailDTO> GetWeightLogs(int ID)
        {
            return dao.GetWeightLogs(ID);
        }
        public List<WeightLogDetailDTO> GetWeightLogs(int ID, DateTime start, DateTime end)
        {
            return dao.GetWeightLogs(ID, start, end);
        }
        public void Add(WeightLogDetailDTO entity)
        {
            WeightLog weightLog = new WeightLog();
            weightLog.MemberID = entity.MemberID;
            weightLog.Weight = entity.Weight;
            weightLog.UpdatedDate = entity.UpdatedDate;
            dao.Add(weightLog);
        }

        public void Update(WeightLogDetailDTO entity)
        {
            WeightLog weight = new WeightLog();
            weight.ID = entity.ID;
            weight.MemberID = entity.MemberID;
            weight.Weight = entity.Weight;
            weight.UpdatedDate = entity.UpdatedDate;
            dao.Update(weight);
        }

        public void Delete(int ID)
        {
            dao.Delete(ID);
        }
    }
}
