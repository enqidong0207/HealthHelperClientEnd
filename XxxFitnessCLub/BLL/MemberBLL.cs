using HHFirstDraft.DAL;
using HHFirstDraft.DAL.DAO;
using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHFirstDraft.DAL;
using HHFirstDraft.DAL;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft.BLL
{
    public class MemberBLL
    {
        MemberDAO dao = new MemberDAO();
        StatusDAO statusDAO = new StatusDAO();
        
        ActivityLevelDAO activityLevelDAO = new ActivityLevelDAO();
        public MemberDTO GetMembers()
        {
            MemberDTO dto = new MemberDTO();
            dto.Members = dao.GetMembers();
            dto.Statuses = statusDAO.GetStatuses();
            dto.ActivityLevels = activityLevelDAO.GetLevels();
            return dto;
        }
        public MemberDetailDTO GetMember(int ID)
        {
            MemberDetailDTO dto = new MemberDetailDTO();
            dto = dao.GetMember(ID);
            return dto;
            
        }
        public int IsMemberExist(string name, string password)
        {
            return dao.IsMemberExist(name, password);
        }

        public MemberDTO GetMembers(string keyword)
        {
            MemberDTO dto = new MemberDTO();
            dto.Members = dao.GetMembers(keyword);
            dto.Statuses = statusDAO.GetStatuses();
            dto.ActivityLevels = activityLevelDAO.GetLevels();
            return dto;
        }
        
        public void Update(MemberDetailDTO entity)
        {
            Member member = new Member();
            member.ID = entity.ID;
            member.Name = entity.Name;
            member.Phone = entity.Phone;
            member.Email = entity.Email;
            member.StatusID = entity.StatusID;
            member.Birthdate = entity.Birthdate;
            member.IsAdmin = entity.IsAdmin;
            member.Password = entity.Password;
            member.Height = entity.Height;
            member.Gender = entity.Gender;
            member.ActivityLevelID = entity.ActivityLevelID;
            dao.Update(member);
        }

        public bool Delete(int ID)
        {
            dao.Delete(ID);
            return true;
        }

        public bool Add(MemberDetailDTO entity)
        {
            Member member = new Member();
            member.Name = entity.Name;
            member.ID = entity.ID;
            member.Phone = entity.Phone;
            member.Email = entity.Email;
            member.StatusID = entity.StatusID;
            member.Birthdate = entity.Birthdate;
            member.IsAdmin = entity.IsAdmin;
            member.Password = entity.Password;
            member.JoinDate = DateTime.Now;
            member.Height = entity.Height;
            member.Gender = entity.Gender;
            member.TaiwanID = entity.TaiwanID;
            member.StatusID = entity.StatusID;
            member.ActivityLevelID = entity.ActivityLevelID;
            return dao.Add(member);
        }

        public bool IsPwdExist(string text)
        {
            return dao.IsPwdExist(text);
        }

        public bool IsEmailExist(string text)
        {
            return dao.IsEmailExist(text);
        }

        public bool IsTaiwanIDExist(string text)
        {
            return dao.IsTaiwanIDExist(text);
        }

        //恩旗
        public int AddMember(MemberDetailDTO entity)
        {
            Member member = new Member();
            member.Name = entity.Name;
            member.ID = entity.ID;
            member.Phone = entity.Phone;
            member.Email = entity.Email;
            member.StatusID = entity.StatusID;
            member.Birthdate = entity.Birthdate;
            member.IsAdmin = entity.IsAdmin;
            member.Password = entity.Password;
            member.JoinDate = DateTime.Now;
            member.Height = entity.Height;
            member.Gender = entity.Gender;
            member.TaiwanID = entity.TaiwanID;
            member.StatusID = entity.StatusID;
            member.ActivityLevelID = entity.ActivityLevelID;
            return dao.AddMember(member);
        }
    }
}
