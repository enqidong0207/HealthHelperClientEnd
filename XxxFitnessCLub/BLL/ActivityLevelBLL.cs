using HHFirstDraft.DAL.DAO;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHFirstDraft.BLL
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
