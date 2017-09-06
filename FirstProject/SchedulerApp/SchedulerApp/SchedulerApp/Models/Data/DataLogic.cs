using SchedulerApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SchedulerApp.Models.Data
{
    public class DataLogic
    {
        DataSource db = new DataSource();

        public int Commit()
        {
            return db.SaveChanges();
        }

        #region Basic Course CRUD

        public void CreateCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public Course GetCourse(int courseId)
        {
            Course course = db.Courses.FirstOrDefault(c => c.Id == courseId);
            return course;
        }

        public void UpdateCourse(Course course)
        {
            Course courseToBeUpdated = db.Courses.FirstOrDefault(c => c.Id == course.Id);

            if (courseToBeUpdated != null)
            {
                db.Entry(courseToBeUpdated).CurrentValues.SetValues(course);
                db.SaveChanges();
            }
        }

        public void DeleteCourse(Course course)
        {
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        #endregion

        #region Basic Member CRUD

        public void CreateMember(Member member)
        {
            db.Members.Add(member);
            db.SaveChanges();
        }

        public Member GetMember(int memberId)
        {
            Member member = db.Members.FirstOrDefault(m => m.Id == memberId);
            return member;
        }

        public IEnumerable<Member> GetMembers(IEnumerable<int> memberIds)
        {
            List<Member> members = db.Members.Where(m => memberIds.Contains(m.Id)).ToList();
            return members;
        }

        public void UpdateMember(Member member)
        {
            Member memberToBeUpdated = db.Members.FirstOrDefault(m => m.Id == member.Id);

            if (memberToBeUpdated != null)
            {
                db.Entry(memberToBeUpdated).CurrentValues.SetValues(member);
                db.SaveChanges();
            }
        }

        public void DeleteMember(Member member)
        {
            db.Members.Remove(member);
            db.SaveChanges();
        }

        #endregion

        public IEnumerable<Member> GetStudentsByCourse(int courseId)
        {
            Course course = db.Courses.Include(c => c.Students).FirstOrDefault(c => c.Id == courseId);
            List<Member> students = course.Students.ToList();

            return students;
        }

    }
}
