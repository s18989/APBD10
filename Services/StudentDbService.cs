using APBD09.DTOs;
using APBD09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD09.Services
{
    public class StudentDbService : IStudentDbService
    {
        private readonly StudentDbContext _context;
        private readonly StudiesDbContext _context2;
        private readonly EnrollmentDbContext _context3;
        public StudentDbService(StudentDbContext context)
        {
            _context = context;
        }
        public StudentDbService(StudiesDbContext context)
        {
            _context2 = context;
        }
        public StudentDbService(EnrollmentDbContext context)
        {
            _context3 = context;
        }


        public void DeleteStudent(string index)
        {
            var st = _context.Student.FirstOrDefault(st => st.IndexNumber.Equals(index));
            if (st == null)
            {
                throw new Exception();
            }
            _context.Remove(st);
            _context.SaveChanges();
        }

        public void EnrollStudent(EnrollRequest student)
        {
            if(student.IndexNumber == null)
            {
                throw new Exception();
            }
            if (student.FirstName == null)
            {
                throw new Exception();
            }
            if (student.LastName == null)
            {
                throw new Exception();
            }
            if (student.BirthDate == null)
            {
                throw new Exception();
            }
            if (student.Studies == null)
            {
                throw new Exception();
            }

            var st = _context2.Studies.FirstOrDefault(st => st.Name.Equals(student.Studies));
            if (st == null)
            {
                throw new Exception();
            }

            var st2 = _context3.Enrolment.FirstOrDefault(stu => stu.IdStudy == st.IdStudy && stu.Semester == 1);
            var enrollment = new Enrollment();
            if (st2 == null)
            {
                enrollment.IdEnrollment = _context3.Enrolment.Last().IdEnrollment + 1;
                enrollment.Semester = 1;
                enrollment.StartDate = DateTime.Now;
                enrollment.IdStudy = st.IdStudy;

                _context3.Add(enrollment);
                _context3.SaveChanges();
            }

            var st3 = _context.Student.FirstOrDefault(st => st.IndexNumber.Equals(student.IndexNumber));
            if (st3 != null)
            {
                throw new Exception();
            }
            else
            {
                var student2 = new Student();
                student2.IndexNumber = student.IndexNumber;
                student2.FirstName = student.FirstName;
                student2.LastName = student.LastName;
                student2.BirthDate = student.BirthDate;
                student2.IdEnrollment = enrollment.IdEnrollment;

            }

        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Student.ToList();
        }

        public void ModifyStudent(Student student)
        {
            var st = _context.Student.FirstOrDefault(st => st.IndexNumber.Equals(student.IndexNumber));
            if(st == null)
            {
                throw new Exception();
            }
            st.FirstName = student.FirstName != null ? student.FirstName : st.FirstName;
            st.LastName = student.LastName != null ? student.LastName : st.LastName;
            st.BirthDate = student.BirthDate != null ? student.BirthDate : st.BirthDate;

            _context.Update(st);
            _context.SaveChanges();

        }

        public Enrollment PromoteStudents(int semester, string studies)
        {
            var st = _context2.Studies.FirstOrDefault(st => st.Name.Equals(studies));
            var en = _context3.Enrolment.FirstOrDefault(en => en.Semester.Equals(semester) && en.IdStudy == st.IdStudy);
            if (en == null)
            {
                throw new Exception();
            }
            var enrollment = _context3.Enrolment.FirstOrDefault(en => en.Semester.Equals(semester+1) && en.IdStudy == st.IdStudy);
            if(enrollment == null)
            {
                enrollment = new Enrollment();
                enrollment.IdEnrollment = _context3.Enrolment.Max().IdEnrollment + 1;
                enrollment.IdStudy = en.IdStudy;
                enrollment.StartDate = DateTime.Now;
                enrollment.Semester = en.Semester + 1;
                _context3.Add(enrollment);
                _context3.SaveChanges();

            }

            var students = _context.Student.Where(st => st.IdEnrollment.Equals(en.IdEnrollment)).ToList();
            students.ForEach(st => st.IdEnrollment = enrollment.IdEnrollment);

            return enrollment;
        }
    }
}
