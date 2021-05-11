using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.DAL.DAO;
using XxxFitnessCLub.DAL.DTO;

namespace XxxFitnessCLub.BLL
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
