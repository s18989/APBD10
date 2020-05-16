using APBD09.DTOs;
using APBD09.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD09.Services
{
    public interface IStudentDbService
    {
        public IEnumerable<Student> GetStudents();
        public void ModifyStudent(Student student);
        public void DeleteStudent(String index);
        public void EnrollStudent(EnrollRequest student);
        public Enrollment PromoteStudents(int semester, string studies);

    }
}
