using StudentWCFService.DAL;
using StudentWCFService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace StudentWCFService.BLL
{
    public class StudentBusinessLogic
    {
        public async Task<List<StudentDTO>> GetAllStudents()
        {
            return await DAL.StudentDataAccess.GetAllStudents();
        }

        public async Task<List<StudentDTO>> GetPassedStudents()
        {
            return await StudentDataAccess.GetPassedStudents();
        }

        public async Task<List<StudentDTO>> GetFaliedStudents()
        {
            return await StudentDataAccess.GetFaliedStudents();
        }
        public async Task<StudentDTO> GetStudentByID(int Id)
        {
            return await StudentDataAccess.GetStudentByID(Id);
        }

        public async Task<StudentDTO> AddNewStudent(StudentRequestDTO newStudent)
        {
            if(newStudent.Grade > 100)
            {
                throw new ArgumentException("Student Grade should be equal to or less than 100");
            }

            if (newStudent.Age > 150 || newStudent.Age < 5)
            {
                throw new ArgumentException("Student Age should be greater than 5 and less than 150");
            }
            try
            {
                return await StudentDataAccess.AddNewStudent(newStudent);
            }
            catch (Exception ex)
            {
                // Log and optionally add context
                Console.Error.WriteLine($"Error in BLL: {ex.Message}");
                throw;
            }
           
        }

        public async Task<StudentDTO> UpdateStudent(int Id, StudentRequestDTO updateRequest)
        {
            if (Id < 0)
            {
                throw new ArgumentException("Student ID should be greater than 0");

            }
            if (updateRequest.Grade > 100)
            {
                throw new ArgumentException("Student Grade should be equal to or less than 100");
            }

            if (updateRequest.Age > 150 || updateRequest.Age < 5)
            {
                throw new ArgumentException("Student Age should be greater than 5 and less than 150");
            }
            try
            {
                return await StudentDataAccess.UpdateStudent(Id, updateRequest);
            }
            catch (Exception ex)
            {
                // Log and optionally add context
                Console.Error.WriteLine($"Error in BLL: {ex.Message}");
                throw;
            }

        }

        public async Task<bool> DeleteStudent(int studentId)
        {
            if (studentId < 0)
            {
                throw new ArgumentException("Student ID should be greater than 0");
            }
            try
            {
                return await StudentDataAccess.DeleteStudent(studentId);
            }
            catch (Exception ex)
            {
                // Log and optionally add context
                Console.Error.WriteLine($"Error in BLL: {ex.Message}");
                throw;
            }
        }



    }
}