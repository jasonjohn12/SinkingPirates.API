using System;
using System.Linq;

using System.Collections.Generic;
using System.Threading.Tasks;
using SinkingPirates.API.DataAccess.Student;
using SinkingPirates.API.Models;
using SinkingPirates.API.DataAccess;
using Microsoft.Extensions.Caching.Memory;

namespace SinkingPirates.API.Manager.Student
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentDataAccess _studentDataAccess;
        private readonly IEntryDataAccess _entryDataAccess;
        private readonly IUserDataAccess _userDataAccess;
        private readonly IUserRoleDataAccess _userRoleDataAccess;


        public StudentManager(IStudentDataAccess studentDataAccess,
            IEntryDataAccess entryDataAccess,
            IUserDataAccess userDataAccess,
            IUserRoleDataAccess userRoleDataAccess
            )
        {
            _studentDataAccess = studentDataAccess;
            _entryDataAccess = entryDataAccess;
            _userDataAccess = userDataAccess;
            _userRoleDataAccess = userRoleDataAccess;
           
        }
        public async Task<List<StudentEntry>> GetAllStudents()
        {
            string key = "UserRole";
            int userRole;
            //if (!_memoryCache.TryGetValue(key, out userRole))
            //{
            //    //discuss if we need to pass the userId in queryparam
            //    // or something we get for jwt token

            //    //security check before getting userId from cache
            //    // think about how to handle cache
 
            //    //userRole = await _userRoleDataAccess.GetUserRoleId(1);
            //    //_memoryCache.Set(key, userRole);
            //}
           // return obj;


            var students = await _studentDataAccess.GetAllStudents();
            List<int> studentIds = students.Select(x => x.StudentId).ToList();

            var entries = await _entryDataAccess.GetAllStudentEntries(studentIds);
            Console.WriteLine("entries", entries);
            var studentWithEntries = students.Select(s => new StudentEntry
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Grade = s.Grade,
                Entries = entries.Where(e => e.StudentId == s.StudentId).ToList()
            });
            return studentWithEntries.ToList();
        }

        public async Task<int> CreateNewStudent(StudentDto studentDto)
        {
            return await _studentDataAccess.CreateNewStudent(studentDto);
          
        }

        public async Task<int> DeleteStudent(int studentId)
        {
            //string key = "UserData";
            //UserToRegister user;
            //if (!_memoryCache.TryGetValue(key, out user))
            //{
            //   user = await _userDataAccess.GetUserAccessLevel(1);
            //    _memoryCache.Set(key, user);
            //}
            // if admin delete any student

            string key = "UserRole";
            int userRole;
            //if (!_memoryCache.TryGetValue(key, out userRole))
            //{
            //    //discuss if we need to pass the userId in queryparam
            //    // or something we get for jwt token
            //    userRole = await _userRoleDataAccess.GetUserRoleId(1);
            //    _memoryCache.Set(key, userRole);
            //}
            //if (userRole == 1) return await _studentDataAccess.DeleteStudentById(studentId);
          // is userId is associated with the userId from student we are safe to delete it
            var student = await _studentDataAccess.GetStudentById(studentId);

            // ask if we should extract this from jwt httpcontext or make api call 
           // if(student.UserId == user.UserId) return await _studentDataAccess.DeleteStudentById(studentId);
            return 0;
        }

        public async Task<StudentDto> GetStudentById(int studentId)
        {
            var student = await _studentDataAccess.GetStudentById(studentId);
            return student;


        }
    }
}
