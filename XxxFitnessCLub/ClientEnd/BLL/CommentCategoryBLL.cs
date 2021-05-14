using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.ClientEnd.DAL.DAO;
using XxxFitnessCLub.ClientEnd.DAL.DTO;

namespace XxxFitnessCLub.ClientEnd.BLL
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
