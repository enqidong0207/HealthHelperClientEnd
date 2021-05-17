using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessClub.BackEnd.DAL.DTO;

namespace XxxFitnessClub.BackEnd.DAL.DAO
{
    public class StatusDAO : HHContext
    {
        public List<StatusDetailDTO> GetStatuses()
        {
            List<StatusDetailDTO> statuses = new List<StatusDetailDTO>();
            var list = db.Status.ToList();
            
            foreach (var item in list)
            {
                StatusDetailDTO dto = new StatusDetailDTO();
                dto.ID = item.ID;
                dto.Description = item.Name;
                statuses.Add(dto);
            }
            return statuses;
        }
    }
}
