using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessClub.BackEnd.DAL.DAO;
using XxxFitnessClub.BackEnd.DAL.DTO;

namespace XxxFitnessClub.BackEnd.BLL
{
    public class CommentCategoryBLL
    {
        CommentCategoryDAO dao = new CommentCategoryDAO();
        public List<CommentCategoryDetailDTO> GetCommentCategories()
        {
            return dao.GetCommentCategories();
        }
    }
}
