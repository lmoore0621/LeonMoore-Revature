using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassSchedule2._0.Models.ScheduleDb;

namespace ClassSchedule2._0.Models.Services
{
    public class ClassService
    {
        private SchedularDbEntities db = new SchedularDbEntities();

        #region Basic CRUD

        public void CreateClass(Class classObj)
        {
            db.Classes.Add(classObj);
            db.SaveChanges();
        }

        public IEnumerable<Class> GetAllClasses()
        {
            List<Class> classes = db.Classes.OrderBy(c => c.Course.Name).ToList();
            return classes;
        }

        public Class GetClass(int classId)
        {
            Class classObj = db.Classes.FirstOrDefault(c => c.Id == classId);
            return classObj;
        }

        public void UpdateClass(Class classObj)
        {
            Class classToUpdate = db.Classes.FirstOrDefault(c => c.Id == classObj.Id);
            db.Entry(classToUpdate).OriginalValues.SetValues(classObj);

            db.SaveChanges();
        }

        public void DeleteClass(Class classObj)
        {
            db.Classes.Remove(classObj);
            db.SaveChanges();
        }

        public void DeleteClass(int classId)
        {
            Class classObj = GetClass(classId);
            DeleteClass(classObj);
        }
        
        #endregion

        public void AssignClassToProfessor(int classId, int professorId)
        {
            Class classObj = GetClass(classId);
            classObj.ProfessorId = professorId;

            db.SaveChanges();
        }

        public void AssignStudentToClass(int classId, int studentId)
        {
            MembersService membersService = new MembersService();
            Member student = membersService.GetMember(studentId);

            Class classObj = GetClass(classId);
            classObj.Students.Add(student);

            db.SaveChanges();
        }

        public void AssignStudentsToClass(int classId, IEnumerable<int> studentIds)
        {
            MembersService membersService = new MembersService();
            IEnumerable<Member> students = membersService.GetMembers(studentIds);

            Class classObj = GetClass(classId);

            foreach (var student in students)
            {
                classObj.Students.Add(student);
            }
            db.SaveChanges();
        }
    }
}