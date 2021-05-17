using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessClub.BackEnd.DAL.DTO;
using XxxFitnessCLub;

namespace XxxFitnessClub.BackEnd.DAL.DAO
{
    public class CommentCategoryDAO : HHContext
    {
        public List<CommentCategoryDetailDTO> GetCommentCategories()
        {
            List<CommentCategory> list = db.CommentCategories.ToList();
            List<CommentCategoryDetailDTO> dtoList = new List<CommentCategoryDetailDTO>();
            foreach (var item in list)
            {
                CommentCategoryDetailDTO dto = new CommentCategoryDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dtoList.Add(dto);
            }
            return dtoList;
        }
    }
}
