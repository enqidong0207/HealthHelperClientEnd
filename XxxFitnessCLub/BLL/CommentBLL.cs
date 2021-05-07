using HHFirstDraft.DAL;
using HHFirstDraft.DAL.DAO;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.DAL;
using XxxFitnessCLub.DAL.DAO;
using XxxFitnessCLub.DAL.DTO;

namespace XxxFitnessCLub.BLL
{
    public class CommentBLL
    {
        CommentDAO commentDAO = new CommentDAO();
        public void Add(CommentDetailDTO entity)
        {
            Comment comment = new Comment();
            comment.Title = entity.Title;
            comment.CommentContent = entity.CommentContent;
            comment.MemberID = entity.MemberID;
            comment.AddDate = entity.AddDate;
            comment.MealOptionID = entity.MealID;
            comment.IsApproved = entity.IsApproved;
            comment.Rating = entity.Rating;
            commentDAO.Add(comment);
        }

        public CommentDTO GetComments()
        {
            CommentDTO commentDTO = new CommentDTO();
            commentDTO.Comments = commentDAO.GetComments();
            return commentDTO;
        }

        public CommentDTO GetComments(string keyword)
        {
            CommentDTO commentDTO = new CommentDTO();
            commentDTO.Comments = commentDAO.GetComments(keyword);
            return commentDTO;
        }

        public void Update(CommentDetailDTO entity)
        {
            Comment comment = new Comment();
            comment.ID = entity.ID;
            comment.Title = entity.Title;
            comment.CommentContent = entity.CommentContent;
            comment.Rating = entity.Rating;
            comment.IsApproved = entity.IsApproved;
            commentDAO.Update(comment);
        }

        public CommentDTO GetApprovedComments()
        {
            CommentDTO commentDTO = new CommentDTO();
            commentDTO.Comments = commentDAO.GetApprovedComments();
            return commentDTO;
        }

        public void Delete(int ID)
        {
            commentDAO.Delete(ID);
        }
    }
}
