using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.ClientEnd.DAL.DAO;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd.BLL
{
    class ActivityLevelBLL
    {
        private ActivityLevelDAO dao = new ActivityLevelDAO();

        public List<ActivityLevelDetailDTO> GetActivityLevels()
        {
            return dao.GetLevels();
        }
       
    }
}
