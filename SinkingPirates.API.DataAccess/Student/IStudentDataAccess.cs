using System.Collections.Generic;
using System.Threading.Tasks;
using SinkingPirates.API.Models;


namespace SinkingPirates.API.DataAccess
{
    public interface IStudentDataAccess
    {
        Task<List<StudentDto>> GetAllStudents();
        Task<List<StudentEntity>> GetInitialStudents(int userId);
        Task<int> CreateNewStudent(StudentDto studentDto);
        Task<StudentDto> GetStudentById(int studentId);
        //Task<List<EntryDto>> GetAllEntriesForStudents();
        Task<int> DeleteStudentById(int studentId);
        //StudentDto CreateStudent(StudentDto student);
        //IEnumerable<EntryDto> RetrieveAllEntries();
    }
}
