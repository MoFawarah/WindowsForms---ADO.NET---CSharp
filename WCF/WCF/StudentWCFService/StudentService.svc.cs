using StudentWCFService.BLL;
using StudentWCFService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace StudentWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IStudentService
    {
        private readonly StudentBusinessLogic _studentBusinessLogic = new StudentBusinessLogic();

        public async Task<List<StudentDTO>> GetAllStudents()
        {
            return await _studentBusinessLogic.GetAllStudents();
        }

        public async Task<List<StudentDTO>> GetPassedStudents()
        {
            return await _studentBusinessLogic.GetPassedStudents();
        }
        public async Task<List<StudentDTO>> GetFaliedStudents()
        {
            return await _studentBusinessLogic.GetFaliedStudents();
        }

        public async Task<StudentDTO> GetStudentByID(int Id)
        {
            return await _studentBusinessLogic.GetStudentByID(Id);
        }

        public async Task<StudentDTO> AddNewStudent(StudentRequestDTO newStudent)
        {
            try
            {
                return await _studentBusinessLogic.AddNewStudent(newStudent);
            }
            catch (Exception ex)
            {
                // Optionally log the exception here
                Console.Error.WriteLine($"Error in AddNewStudent: {ex.Message}");
                throw new Exception($"Error in AddNewStudent: {ex.Message}");
            }
        }

        public async Task<StudentDTO> UpdateStudent(int Id, StudentRequestDTO updateRequest)
        {
            try
            {
                return await _studentBusinessLogic.UpdateStudent(Id, updateRequest);
            }
            catch (Exception ex)
            {
                // Optionally log the exception here
                Console.Error.WriteLine($"Error in AddNewStudent: {ex.Message}");
                throw new Exception($"Error in AddNewStudent: {ex.Message}");
            }
        }

        public async Task<bool> DeleteStudent(int Id)
        {
            return await _studentBusinessLogic.DeleteStudent(Id);
        }
    }
}
