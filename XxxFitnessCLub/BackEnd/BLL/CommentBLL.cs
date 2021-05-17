using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub;
using XxxFitnessClub.BackEnd.DAL.DTO;
using XxxFitnessClub.BackEnd.DAL.DAO;

namespace XxxFitnessClub.BackEnd.BLL
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
            comment.CategoryID = entity.CategoryID;
            comment.IsApproved = entity.IsApproved;
            comment.Rating = entity.Rating;
            comment.Feedback = entity.Feedback;
            if (entity.MealOptionID != null)
            {
                comment.MealOptionID = (int)entity.MealOptionID;
            }
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
            comment.CategoryID = entity.CategoryID;
            comment.MealOptionID = entity.MealOptionID;
            comment.Feedback = entity.Feedback;
            commentDAO.Update(comment);
        }

        public void Delete(int ID)
        {
            commentDAO.Delete(ID);
        }
    }
}
