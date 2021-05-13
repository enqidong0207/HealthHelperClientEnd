using HHFirstDraft.DAL.DAO;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft.BLL
{
    class TimesOfDayBLL
    {
        TimesOfDayDAO dao = new TimesOfDayDAO();

        public List<TimeOfDayDTO> GetTimesOfDay()
        {
            List <TimeOfDayDTO> tod = new List<TimeOfDayDTO>();
            foreach (TimesOfDay td in dao.GetTimesOfDay())
            {
                TimeOfDayDTO tDto = new TimeOfDayDTO();
                tDto.ID = td.ID;
                tDto.Name = td.Name;
                tod.Add(tDto);
            }
            return tod;
        }

       

    }
}
