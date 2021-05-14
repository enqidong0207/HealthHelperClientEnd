using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XxxFitnessCLub.ClientEnd.DAL.DTO
{
    public class CommentDetailDTO
    {
        public string Member { get; set; }
        public string MealName { get; set; }
        public int Rating { get; set; }

        public int ID { get; set; }
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public int MemberID { get; set; }
        public DateTime AddDate { get; set; }
        public bool IsApproved { get; set; }
        public int? MealID { get; set; }
    }
}
