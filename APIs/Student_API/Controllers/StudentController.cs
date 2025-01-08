using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Student_DAL.DTOs;
using System.Data;

namespace Student_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentBusinessLogic _studentBusinessLogic;


        public StudentController(StudentBusinessLogic studentBusinessLogic)
        {
            _studentBusinessLogic = studentBusinessLogic;
        }

        [HttpGet("GetAllStudents", Name = "GetAllStudents")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {
            try
            {
                List<StudentDTO> students = await _studentBusinessLogic.GetAllStudents();

                if (students.Count == 0)
                {
                    return NotFound("No Students Found");
                }
                return Ok(students);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }



        }


        [HttpGet("GetPassedStudents", Name = "GetPassedStudents")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetPassedStudents()
        {
            try
            {
                List<StudentDTO> passedStudents = await _studentBusinessLogic.GetPassedStudents();

                if (passedStudents.Count == 0)
                {
                    return NotFound("No Students Found");
                }
                return Ok(passedStudents);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }



        }


        [HttpGet("GetFailedStudents", Name = "GetFailedStudents")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetFailedStudents()
        {
            try
            {
                List<StudentDTO> failedStudents = await _studentBusinessLogic.GetFailedStudents();

                if (failedStudents.Count == 0)
                {
                    return NotFound("No Students Found");
                }
                return Ok(failedStudents);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }



        }



        [HttpGet("GetAvgGrade", Name = "GetAvgGrade")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<double>> GetAvgGrade()
        {
            try
            {
                double avgGrade = await _studentBusinessLogic.GetAvgGrade();

                return Ok(avgGrade);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }



        }

        [HttpGet("GetStudentByID", Name = "GetStudentByID")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> GetStudentByID(int Id)
        {
            try
            {
                
                if(Id <=0)
                {
                    return BadRequest("Id should be greater than zero");
                }

                StudentDTO student = await _studentBusinessLogic.GetStudentByID(Id);

                if (student == null)
                {
                    return NotFound($"No Student with Id {Id} found");
                }

                return Ok(student);

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }



        }



        [HttpPost("AddNewStudent", Name = "AddNewStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> AddNewStudent(StudentUpdateDTO newStudentDTO)
        {
            try
            {
                // Validate input data
                if (newStudentDTO == null)
                {
                    return BadRequest("Student data is required.");
                }

                if (string.IsNullOrEmpty(newStudentDTO.Name) || newStudentDTO.Age < 0 || newStudentDTO.Grade < 0)
                {
                    return BadRequest("Invalid student data. Ensure Name is provided and Age/Grade are non-negative.");
                }

                // Call business logic to add the student
                var addedStudent = await _studentBusinessLogic.AddNewStudent(newStudentDTO);

                if (addedStudent == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add the student.");
                }

                // Return the added student
                return Ok(addedStudent);
            }
            catch (Exception ex)
            {
                // Log the error and return 500 status
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }



        [HttpPut("UpdateStudent", Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<StudentDTO>> UpdateStudent(int Id, StudentUpdateDTO newStudentDTO)
        {
            try
            {
                if (newStudentDTO == null)
                {
                    return BadRequest("Student data is required.");
                }

                if (string.IsNullOrEmpty(newStudentDTO.Name) || newStudentDTO.Age < 0 || newStudentDTO.Grade < 0)
                {
                    return BadRequest("Invalid student data.");
                }

                var student = await _studentBusinessLogic.UpdateStudent(Id, newStudentDTO);

                if (student == null)
                {
                    return NotFound($"No student found with ID {Id}");
                }

                return Ok(student);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }





    }
}

