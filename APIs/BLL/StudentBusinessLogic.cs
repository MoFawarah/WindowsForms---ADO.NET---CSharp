using DAL;
using Student_DAL.DTOs;
using System.Data;

namespace BLL
{
    public class StudentBusinessLogic
    {
        public async Task<List<StudentDTO>> GetAllStudents()
        {
            return await StudentDataAccess.GetAllStudents();
        }

        public async Task<List<StudentDTO>> GetPassedStudents()
        {
            return await StudentDataAccess.GetPassedStudents();
        }

        public async Task<List<StudentDTO>> GetFailedStudents()
        {
            return await StudentDataAccess.GetFailedStudents();
        }

        public async Task<double> GetAvgGrade()
        {
            return await StudentDataAccess.GetAvgGrade();
        }

        public async Task<StudentDTO?> GetStudentByID(int Id)
        {
            return await StudentDataAccess.GetStudentByID(Id);
        }

        public async Task<StudentDTO?> AddNewStudent(StudentUpdateDTO student)
        {
            return await StudentDataAccess.AddNewStudent(student);
        }

        public async Task<StudentDTO?> UpdateStudent(int Id, StudentUpdateDTO updateRequest)
        {
            return await StudentDataAccess.UpdateStudent(Id, updateRequest);
        }

        public async Task <bool> DeleteStudent(int studentId)
        {
           return await StudentDataAccess.DeleteStudent(studentId);
        }

        public double Sum(double num1, double num2)
        {
            return StudentDataAccess.Sum(num1, num2);
        }



    }
}
