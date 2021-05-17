using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub;
using XxxFitnessClub.BackEnd.DAL.DTO;

namespace XxxFitnessClub.BackEnd.DAL.DAO
{
    public class WeightLogDAO : HHContext
    {
        public List<WeightLogDetailDTO> GetWeightLogs()
        {
            List<WeightLog> list = db.WeightLogs.ToList();
            List<WeightLogDetailDTO> dtoList = new List<WeightLogDetailDTO>();
            foreach (var item in list)
            {
                WeightLogDetailDTO dto = new WeightLogDetailDTO();
                dto.ID = item.ID;
                dto.MemberID = item.MemberID;
                dto.MemberName = item.Member.Name;
                dto.Weight = item.Weight;
                dto.UpdatedDate = item.UpdatedDate;
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<WeightLogDetailDTO> GetWeightLogs(int ID)
        {
            List<WeightLog> list = db.WeightLogs.Where(x => x.MemberID == ID).ToList();
            List<WeightLogDetailDTO> dtoList = new List<WeightLogDetailDTO>();
            foreach (var item in list)
            {
                WeightLogDetailDTO dto = new WeightLogDetailDTO();
                dto.ID = item.ID;
                dto.MemberID = item.MemberID;
                dto.MemberName = item.Member.Name;
                dto.Weight = item.Weight;
                dto.UpdatedDate = item.UpdatedDate;
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<WeightLogDetailDTO> GetWeightLogs(DateTime start, DateTime end)
        {
            List<WeightLog> list = db.WeightLogs.Where(x => x.UpdatedDate >= start && x.UpdatedDate <= end).ToList();
            List<WeightLogDetailDTO> dtoList = new List<WeightLogDetailDTO>();
            foreach (var item in list)
            {
                WeightLogDetailDTO dto = new WeightLogDetailDTO();
                dto.ID = item.ID;
                dto.MemberID = item.MemberID;
                dto.MemberName = item.Member.Name;
                dto.Weight = item.Weight;
                dto.UpdatedDate = item.UpdatedDate;
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public List<WeightLogDetailDTO> GetWeightLogs(int ID, DateTime start, DateTime end)
        {
            List<WeightLog> list = db.WeightLogs.Where(x => x.MemberID == ID && x.UpdatedDate >= start && x.UpdatedDate <= end).ToList();
            List<WeightLogDetailDTO> dtoList = new List<WeightLogDetailDTO>();
            foreach (var item in list)
            {
                WeightLogDetailDTO dto = new WeightLogDetailDTO();
                dto.ID = item.ID;
                dto.MemberID = item.MemberID;
                dto.MemberName = item.Member.Name;
                dto.Weight = item.Weight;
                dto.UpdatedDate = item.UpdatedDate;
                dtoList.Add(dto);
            }
            return dtoList;
        }
        public void Delete(int ID)
        {
            WeightLog weight = db.WeightLogs.First(x => x.ID == ID);
            db.WeightLogs.Remove(weight);
            db.SaveChanges();
        }

        public void Add(WeightLog weightLog)
        {
            try
            {
                db.WeightLogs.Add(weightLog);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update(WeightLog entity)
        {
            try
            {
                WeightLog weightLog = db.WeightLogs.First(x => x.ID == entity.ID);
                weightLog.MemberID = entity.MemberID;
                weightLog.Weight = entity.Weight;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
