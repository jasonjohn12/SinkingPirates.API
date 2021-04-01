using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DataAccess;
using Microsoft.Extensions.Configuration;
using SinkingPirates.API.Models;

namespace SinkingPirates.API.DataAccess.Student
{
    public class StudentDataAccess : BaseRepository, IStudentDataAccess
    {
        public StudentDataAccess(IConfiguration configuration) : base(configuration, "SQLite")
        {

        }

        public async Task<int> CreateNewStudent(StudentDto studentDto)
        {
            var userId = 1;
            var query = @"INSERT INTO Student (FirstName, LastName, Grade, UserId) VALUES (@FirstName, @LastName, @Grade, @UserId)";
            DynamicParameters _params = new DynamicParameters(new
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Grade = studentDto.Grade,
                UserId = userId
            });

            return await ExecuteAsync(query, param: _params);

        }

        public async Task<int> DeleteStudentById(int studentId)
        {
            DynamicParameters _params = new DynamicParameters(new
            {
                StudentId = studentId
            });
            var query = @"DELETE FROM Student WHERE StudenId = @StudentId";
            return await ExecuteAsync(query, param: _params);
        }

        public async Task<List<StudentDto>> GetAllStudents()
        {
            var query = "SELECT * FROM Students";

            return await QueryAsync<StudentDto>(query);


        }

        public async Task<List<StudentEntity>> GetInitialStudents(int userId)
        {
            var query = @"SELECT * FROM InitialStudents WHERE UserId = @UserId";
            DynamicParameters _params = new DynamicParameters(new
            {
                UserId = userId
            });
            var students = await QueryAsync<StudentEntity>(query, param: _params);
            return students;
        }

        public async Task<StudentDto> GetStudentById(int studentId)
        {
            var query = @"SELECT * FROM Student WHERE StudentId = @StudentId";
            DynamicParameters _params = new DynamicParameters(new
            {

                StudentId = studentId
            });

            var student = await QueryAsync<StudentDto>(query, param: _params);
            return student.FirstOrDefault();
        }
    }
}
