using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudOperations.DataSimulation;
using CrudOperations.Models;

namespace CrudOperations.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentController : ControllerBase
    {

      

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<StudentResponseDTO>>GetAllStudents()
        {

            var allStudents = StudentDataSimulation.StudentsList.ToList();
            if (!allStudents.Any())
            {
                return NotFound("No students are currently available.");
            }


            return Ok(allStudents);
        }


        //[HttpGet("Passed", Name = "GetPassedStudents")]
        [HttpGet("GetPassedStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<StudentResponseDTO>>GetPassedStudents()
        {
            var passedStudents = StudentDataSimulation.StudentsList.Where(x => x.Grade >= 50).ToList();
            if (!passedStudents.Any())
            {
                return NotFound("No Passed Students Found");
            }


            return Ok(passedStudents);
        }


        [HttpGet("GetAvgGrade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<double> GetAvgGrade()
        {


         
            if (StudentDataSimulation.StudentsList.Count == 0)
            {
                return NotFound("No students are available to calculate the average.");
            }

            double avg = StudentDataSimulation.StudentsList.Average(x => x.Grade);  


            return Ok(avg);
        }


        [HttpGet("GetStudentByID/{ID}", Name = "GetStudentByID")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult <StudentResponseDTO> GetStudentByID(int ID)
        {
            if (ID <= 0)
            {
                return BadRequest("Invalid student ID. ID must be a positive integer.");
            }

            var student = StudentDataSimulation.StudentsList.FirstOrDefault(x=> x.ID == ID);
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

            var student = StudentDataSimulation.StudentsList.Find(x => x.ID == ID);

            if (student == null)
                return NotFound($"Student with ID {ID} was not found.");


            if (string.IsNullOrWhiteSpace(student.Name))
            {
                return NotFound("Student name not found.");
            }


            
            return student.Name;
            
        }


        [HttpPut("UpdateStudentByID/{ID}")]


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StudentResponseDTO> UpdateStudentByID(int ID, StudentResponseDTO studentDTO)
        {

            if (ID <= 0)
            {
                return BadRequest("Invalid Student Data");
            }

            var student = StudentDataSimulation.StudentsList.FirstOrDefault(x => x.ID == ID);
     

            if (student == null)
                return NotFound($"Student with ID {ID} was not found.");
           
            student.Name = studentDTO.Name;
            student.Age = studentDTO.Age;
            student.Grade = studentDTO.Grade;


            return Ok(student);
        }


        [HttpPost("AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StudentResponseDTO> AddStudent(StudentResponseDTO newStudent)
        {

           if (newStudent == null || string.IsNullOrEmpty(newStudent.Name) || newStudent.Age< 0 || newStudent.Grade < 0)
            {
                return BadRequest("Invalid Student Data");
            }

            newStudent.ID = StudentDataSimulation.StudentsList.Count > 0 ? StudentDataSimulation.StudentsList.Max(x => x.ID) + 1 : 1;

            
           StudentDataSimulation.StudentsList.Add(newStudent);

            return CreatedAtRoute("GetStudentByID", new { ID = newStudent.ID }, newStudent);  
        
        }






        [HttpDelete("DeleteStudentByID/{ID}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<StudentResponseDTO> DeleteStudentByID(int ID)
        {

            if (ID <= 0)
            {
                return BadRequest("Invalid student ID. ID must be a positive integer.");
            }

            var student = StudentDataSimulation.StudentsList.FirstOrDefault(x => x.ID == ID);


            if (student == null)
                return NotFound($"Student with ID {ID} was not found.");



            /*StudentResponseDTO oldStudent = new StudentResponseDTO()
            {
                ID = student.ID,
                Name = student.Name,
                Age = student.Age,
                Grade = student.Grade
            };*/

            StudentDataSimulation.StudentsList.Remove(student);


            return Ok(student);
        }



    }
    }
