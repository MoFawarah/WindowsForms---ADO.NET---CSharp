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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {

        [OperationContract]
        Task<List<StudentDTO>> GetAllStudents();

        [OperationContract]
        Task<List<StudentDTO>> GetPassedStudents();

        [OperationContract]
        Task<StudentDTO> GetStudentByID(int Id);

        [OperationContract]
        Task<List<StudentDTO>> GetFaliedStudents();

        [OperationContract]
        Task<StudentDTO> AddNewStudent(StudentRequestDTO newStudent);

        [OperationContract]
        Task<StudentDTO> UpdateStudent(int Id, StudentRequestDTO updateRequest);


        [OperationContract]
        Task<bool> DeleteStudent(int Id);


    }




}
