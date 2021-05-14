using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd.DAL.DAO
{
    public class ActivityLevelDAO : HHContext
    {
        public List<ActivityLevelDetailDTO> GetLevels()
        {
            List<ActivityLevelDetailDTO> activities = new List<ActivityLevelDetailDTO>();
            var list = db.ActivityLevels.ToList();

            foreach (var item in list)
            {
                ActivityLevelDetailDTO dto = new ActivityLevelDetailDTO();
                dto.ID = item.ID;
                dto.Description = item.Description;
                activities.Add(dto);
            }
            return activities;
        }
    }
}
