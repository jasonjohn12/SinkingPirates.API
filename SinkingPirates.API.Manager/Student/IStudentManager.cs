using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SinkingPirates.API.Models;

namespace SinkingPirates.API.Manager.Student
{
    public interface IStudentManager
    {
        Task<List<StudentEntry>> GetAllStudents();
        Task<int>CreateNewStudent(StudentDto studentDto);
         Task<int> DeleteStudent(int studentId);
        Task<StudentDto> GetStudentById(int studentId);
    }
}
