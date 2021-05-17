using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessClub.BackEnd.DAL.DTO
{
    public class CommentDetailDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public int MemberID { get; set; }
        public string Member { get; set; }
        public int? MealOptionID { get; set; }
        public string MealName { get; set; }
        public DateTime AddDate { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Rating { get; set; }
        public string Feedback { get; set; }
    }
}
