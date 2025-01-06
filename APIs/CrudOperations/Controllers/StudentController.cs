using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudOperations.DataSimulation;
using CrudOperations.Models;

namespace CrudOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDataSimulation _studentDataSimulation;

        public StudentController(StudentDataSimulation studentDataSimulation)
        {
            _studentDataSimulation = studentDataSimulation;
        }

        [HttpGet]
        public ActionResult<List<StudentResponseDTO>>  GetAllStudents()
        {

            var allStudents =_studentDataSimulation.StudentsList.ToList();
            if (!allStudents.Any())
            {
                return NotFound("No students are currently available.");
            }


            return Ok(allStudents);
        }

        [HttpGet("GetStudentByID/{ID}")]
        public ActionResult <StudentResponseDTO> GetStudentByID(int ID)
        {
            if (ID <= 0)
            {
                return BadRequest("Invalid student ID. ID must be a positive integer.");
            }

            var student = _studentDataSimulation.StudentsList.Find(x=> x.ID == ID);
            if(student == null)
                return NotFound($"Student with ID {ID} was not found.");

            return Ok(student);
        }

        [HttpGet("GetStudentNameByID/{ID}")]
        public ActionResult<string> GetStudentNameByID(int ID)
        {
            
            if (ID <= 0)
            {
                return BadRequest("Invalid student ID. ID must be a positive integer.");
            }

            var student = _studentDataSimulation.StudentsList.Find(x => x.ID == ID);

            if (student == null)
                return NotFound($"Student with ID {ID} was not found.");


            if (string.IsNullOrWhiteSpace(student.Name))
            {
                return NotFound("Student name not found.");
            }


            
            return student.Name;
            
        }


        [HttpPut("UpdateStudentByID/{ID}")]
        public ActionResult<StudentResponseDTO> UpdateStudentByID(int ID, [FromForm] StudentResponseDTO studentDTO)
        {

            if (ID <= 0)
            {
                return BadRequest("Invalid student ID. ID must be a positive integer.");
            }

            var student = _studentDataSimulation.StudentsList.SingleOrDefault(x => x.ID == ID);
     

            if (student == null)
                return NotFound($"Student with ID {ID} was not found.");

            if (ID != studentDTO.ID)
            {
                return BadRequest("The student ID in the URL does not match the ID in the request body.");
            }


            StudentResponseDTO oldStudent = new StudentResponseDTO()
            {
                ID = student.ID,
                Name = student.Name,
                Age = student.Age,
                Grade = student.Grade
            };

           
            student.Name = studentDTO.Name;
            student.Age = studentDTO.Age;
            student.Grade = studentDTO.Grade;


            return Ok(new
            {
                message = "Student updated successfully.",
                oldStudent,
                student,
            });
        }


        [HttpDelete("DeleteStudentByID/{ID}")]
        public ActionResult<StudentResponseDTO> DeleteStudentByID(int ID)
        {

            if (ID <= 0)
            {
                return BadRequest("Invalid student ID. ID must be a positive integer.");
            }

            var student = _studentDataSimulation.StudentsList.FirstOrDefault(x => x.ID == ID);


            if (student == null)
                return NotFound($"Student with ID {ID} was not found.");



            StudentResponseDTO oldStudent = new StudentResponseDTO()
            {
                ID = student.ID,
                Name = student.Name,
                Age = student.Age,
                Grade = student.Grade
            };

            _studentDataSimulation.StudentsList.Remove(student);





            return Ok(new
            {
                message = "Student Removed successfully.",
                oldStudent
            });
        }



    }
    }
