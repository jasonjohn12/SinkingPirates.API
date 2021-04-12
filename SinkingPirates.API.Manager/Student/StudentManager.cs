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

            var students = await _studentDataAccess.GetInitialStudents(1);

            var initialStudents = new List<StudentEntry>();
            var lastStudentId = -1;
            foreach (var student in students)
            {
                if (student.StudentId != lastStudentId)
                {
                    var createdStudent = new StudentEntry()
                    {
                        StudentId = student.StudentId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Grade = student.Grade,
                        Entries = new List<Entry>()

                    };

                    initialStudents.Add(createdStudent);
                }
                if (student.EntryStudentId > 0)
                {
                    // gives me the last student that was added
                    var currentStudent = initialStudents[initialStudents.Count - 1];
                    var entry = new Entry()
                    {
                        Id = student.EntryId,
                        CreatedByUserId = student.EntryCreatedByUserId,
                        CreatedAtDateUTC = student.EntryCreatedUTC,
                        StudentId = student.EntryStudentId,
                        Note = student.Note
                    };

                    currentStudent.Entries.Add(entry);
                }

                lastStudentId = student.StudentId;
            }
            return initialStudents;

        }

        public async Task<int> CreateNewStudent(StudentDto studentDto)
        {
            return await _studentDataAccess.CreateNewStudent(studentDto);

        }

        public async Task<int> DeleteStudent(int studentId)
        {

            var student = await _studentDataAccess.GetStudentById(studentId);
            return 0;
        }

        public async Task<StudentDto> GetStudentById(int studentId)
        {
            var student = await _studentDataAccess.GetStudentById(studentId);
            return student;


        }
    }
}
