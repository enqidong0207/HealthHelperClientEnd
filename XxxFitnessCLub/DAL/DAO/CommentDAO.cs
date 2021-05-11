using HHFirstDraft.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.DAL.DTO;

namespace XxxFitnessCLub.DAL.DAO
{
    public class CommentDAO : HHContext
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
                dto.CategoryID = (int)item.CategoryID;
                dto.CategoryName = item.CommentCategory.Name;
                dto.IsApproved = item.IsApproved;
                dto.Rating = item.Rating;
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
            List<Comment> list = db.Comments.Where(x => x.Title.Contains(keyword) || x.Member.Name.Contains(keyword) || x.CommentContent.Contains(keyword)).ToList();
            List<CommentDetailDTO> dtoList = new List<CommentDetailDTO>();
            foreach (var item in list)
            {
                CommentDetailDTO dto = new CommentDetailDTO();
                dto.ID = item.ID;
                dto.Title = item.Title;
                dto.CommentContent = item.CommentContent;
                dto.MemberID = item.MemberID;
                dto.Member = item.Member.Name;
                dto.CategoryID = (int)item.CategoryID;
                dto.CategoryName = item.CommentCategory.Name;
                dto.AddDate = item.AddDate;
                dto.IsApproved = item.IsApproved;
                dto.Rating = item.Rating;
                if (item.MealOptionID != null)
                {
                    dto.MealOptionID = (int)item.MealOptionID;
                    dto.MealName = item.MealOption.Name;
                }
                dtoList.Add(dto);
            }
            return dtoList;
        }

        public List<CommentDetailDTO> GetApprovedComments()
        {
            List<Comment> list = db.Comments.Where(x => x.IsApproved == true).ToList();
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
                dto.CategoryID = (int)item.CategoryID;
                dto.CategoryName = item.CommentCategory.Name;
                dto.IsApproved = item.IsApproved;
                dto.Rating = item.Rating;
                if (item.MealOptionID != null)
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
            comment.CategoryID = entity.CategoryID;
            comment.Rating = entity.Rating;
            comment.IsApproved = entity.IsApproved;
            comment.MealOptionID = entity.MealOptionID;
            db.SaveChanges();
        }
    }
}
