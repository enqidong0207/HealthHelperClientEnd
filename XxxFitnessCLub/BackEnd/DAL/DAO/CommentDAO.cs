using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub;
using XxxFitnessClub.BackEnd.DAL.DTO;

namespace XxxFitnessClub.BackEnd.DAL.DAO
{
    class CommentDAO : HHContext
    {
        public void Add(Comment comment)
        {
            try
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CommentDetailDTO> GetComments()
        {
            List<Comment> list = db.Comments.ToList();
            List<CommentDetailDTO> dtoList = new List<CommentDetailDTO>();
            foreach (var item in list)
            {
                CommentDetailDTO dto = new CommentDetailDTO();
                dto.ID = item.ID;
                dto.Title = item.Title;
                dto.CommentContent = item.CommentContent;
                dto.MemberID = item.MemberID;
                dto.Member = item.Member.Name;
                dto.AddDate = item.AddDate;
                dto.IsApproved = item.IsApproved;
                dto.CategoryID = (int)item.CategoryID;
                dto.CategoryName = item.CommentCategory.Name;
                dto.Rating = item.Rating;
                dto.Feedback = item.Feedback;
                if (item.MealOptionID != null)
                {
                    dto.MealOptionID = (int)item.MealOptionID;
                    dto.MealName = item.MealOption.Name;
                }
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<CommentDetailDTO> GetComments(string keyword)
        {
            List<Comment> list = db.Comments.Where(x => x.Title.Contains(keyword) || x.Member.Name.Contains(keyword) || x.CommentContent.Contains(keyword)) .ToList();
            List<CommentDetailDTO> dtoList = new List<CommentDetailDTO>();
            foreach (var item in list)
            {
                CommentDetailDTO dto = new CommentDetailDTO();
                dto.ID = item.ID;
                dto.Title = item.Title;
                dto.CommentContent = item.CommentContent;
                dto.MemberID = item.MemberID;
                dto.Member = item.Member.Name;
                dto.AddDate = item.AddDate;
                dto.IsApproved = item.IsApproved;
                dto.CategoryID = (int)item.CategoryID;
                dto.CategoryName = item.CommentCategory.Name;
                dto.Rating = item.Rating;
                dto.Feedback = item.Feedback;
                if (dto.MealOptionID != null)
                {
                    dto.MealOptionID = (int)item.MealOptionID;
                    dto.MealName = item.MealOption.Name;
                }
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public void Delete(int ID)
        {
            Comment comment = db.Comments.FirstOrDefault(x => x.ID == ID);
            db.Comments.Remove(comment);
            db.SaveChanges();
        }

        public void Update(Comment entity)
        {
            Comment comment = db.Comments.FirstOrDefault(x => x.ID == entity.ID);
            comment.Title = entity.Title;
            comment.CommentContent = entity.CommentContent;
            comment.Rating = entity.Rating;
            comment.CategoryID = entity.CategoryID;
            comment.IsApproved = entity.IsApproved;
            if (comment.CategoryID == General.CommentCategory.meal)
            {
                comment.MealOptionID = entity.MealOptionID;
            }
            comment.Feedback = entity.Feedback;

            db.SaveChanges();
        }
    }
}
