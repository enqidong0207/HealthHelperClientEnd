using HHFirstDraft.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHFirstDraft.DAL;
using HHFirstDraft.DAL;
using XxxFitnessCLub.DAL;

namespace HHFirstDraft.DAL.DAO
{
    public class MemberDAO : HHContext
    {
        public List<MemberDetailDTO> GetMembers()
        {
            List<MemberDetailDTO> Members = new List<MemberDetailDTO>();
            var list = db.Members.ToList();
            foreach (Member item in list)
            {
                MemberDetailDTO dto = new MemberDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.Password = item.Password;
                dto.Height = (int)item.Height;
                dto.Email = item.Email;
                dto.Phone = item.Phone;
                dto.StatusID = item.StatusID;
                dto.Status = item.Status.Name;
                dto.IsAdmin = item.IsAdmin;
                dto.TaiwanID = item.TaiwanID;
                dto.ActivityLevelID = item.ActivityLevelID;
                dto.ActivityLevel = item.ActivityLevel.Description;
                dto.Birthdate = item.Birthdate;
                dto.JoinDate = item.JoinDate;
                if (item.Gender)
                {
                    dto.Gender = true;
                    dto.GenderString = "男";
                }
                else
                {
                    dto.Gender = false;
                    dto.GenderString = "女";
                }
                Members.Add(dto);
            }
            return Members;
        }
        public MemberDetailDTO GetMember(int ID)
        {
            Member member = db.Members.First(x => x.ID == ID);
            MemberDetailDTO dto = new MemberDetailDTO();
            dto.ID = ID;
            dto.Name = member.Name;
            dto.Password = member.Password;
            dto.Phone = member.Phone;
            dto.IsAdmin = member.IsAdmin;
            dto.Height = (int)member.Height;
            if (member.Gender)
            {
                dto.Gender = true;
                dto.GenderString = "男";
            }
            else
            {
                dto.Gender = false;
                dto.GenderString = "女";
            }
            dto.ActivityLevelID = member.ActivityLevelID;
            dto.ActivityLevel = member.ActivityLevel.Description;
            dto.TaiwanID = member.TaiwanID;
            dto.StatusID = member.StatusID;
            dto.Status = member.Status.Name;
            dto.JoinDate = member.JoinDate;
            dto.Birthdate = member.Birthdate;
            dto.Email = member.Email;
            return dto;
        }
        public int IsMemberExist(string name, string password)
        {
            Member member = db.Members.FirstOrDefault(x => x.Name == name && x.Password == password);
            if (member != null)
            {
                return member.ID;
            }
            else
            {
                return 0;
            }
           
        }

        public void Update(Member entity)
        {
            try
            {
                Member member = db.Members.First(x => x.ID == entity.ID);
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
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                Member member = db.Members.First(x => x.ID == ID);
                db.Members.Remove(member);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Add(Member member)
        {
            try
            {
                db.Members.Add(member);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool IsPwdExist(string text)
        {
            Member member = db.Members.FirstOrDefault(x => x.Password == text);
            if (member == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsTaiwanIDExist(string text)
        {
            Member member = db.Members.FirstOrDefault(x => x.TaiwanID == text);
            if (member == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsEmailExist(string text)
        {
            Member member = db.Members.FirstOrDefault(x => x.Email == text);
            if (member == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<MemberDetailDTO> GetMembers(string keyword)
        {
            List<MemberDetailDTO> Members = new List<MemberDetailDTO>();
            var list = db.Members.Where(x => x.Name.Contains(keyword) 
            || x.Email.Contains(keyword) 
            || x.TaiwanID.Contains(keyword)
            || x.Phone.Contains(keyword)).ToList();
            foreach (Member item in list)
            {
                MemberDetailDTO dto = new MemberDetailDTO();
                dto.ID = item.ID;
                dto.Name = item.Name;
                dto.Password = item.Password;
                dto.Height = (int)item.Height;
                dto.Email = item.Email;
                dto.Phone = item.Phone;
                dto.StatusID = item.StatusID;
                dto.Status = item.Status.Name;
                dto.IsAdmin = item.IsAdmin;
                dto.TaiwanID = item.TaiwanID;
                dto.ActivityLevel = item.ActivityLevel.Description;
                dto.Birthdate = item.Birthdate;
                dto.JoinDate = item.JoinDate;
                dto.ActivityLevelID = item.ActivityLevelID;

                if (item.Gender)
                {
                    dto.Gender = true;
                    dto.GenderString = "男";
                }
                else
                {
                    dto.Gender = false;
                    dto.GenderString = "女";
                }

                Members.Add(dto);
            }
            return Members;
        }

        //恩旗
        public int AddMember(Member member)
        {
            try
            {
                db.Members.Add(member);
                db.SaveChanges();
                return member.ID;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
