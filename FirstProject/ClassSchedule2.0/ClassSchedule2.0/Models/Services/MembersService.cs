using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassSchedule2._0.Models.ScheduleDb;

namespace ClassSchedule2._0.Models.Services
{
    public class MembersService
    {
        private SchedularDbEntities db = new SchedularDbEntities();

        #region Basic CRUD

        public void CreateMember(Member member)
        {
            db.Members.Add(member);
            db.SaveChanges();
        }

        public IEnumerable<Member> GetAllMembers()
        {
            List<Member> members = db.Members.OrderBy(m => m.LastName).ThenBy(m => m.FirstName).ToList();
            return members;
        }

        public Member GetMember(int memberId)
        {
            Member member = db.Members.FirstOrDefault(m => m.Id == memberId);
            return member;
        }

        public void UpdateMember(Member member)
        {
            Member memberToUpdate = db.Members.FirstOrDefault(m => m.Id == member.Id);
            db.Entry(memberToUpdate).OriginalValues.SetValues(member);

            db.SaveChanges();
        }

        public void DeleteMember(Member member)
        {
            db.Members.Remove(member);
            db.SaveChanges();
        }

        public void DeleteMember(int memberId)
        {
            Member member = GetMember(memberId);
            DeleteMember(member);
        }

        #endregion

        public IEnumerable<Member> GetMembers(IEnumerable<int> memberIds)
        {
            List<Member> members = db.Members.Where(m => memberIds.Contains(m.Id)).OrderBy(m => m.LastName).ThenBy(m => m.FirstName).ToList();
            return members;
        }

    }
}