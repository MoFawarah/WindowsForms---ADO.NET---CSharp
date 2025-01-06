using CrudOperations.Models;

namespace CrudOperations.DataSimulation
{
    public class StudentDataSimulation
    {
        public List<StudentResponseDTO> StudentsList { get; } = new List<StudentResponseDTO>
        {
            new StudentResponseDTO { ID = 1, Name = "Ratib", Age = 18, Grade = 9 },
            new StudentResponseDTO { ID = 2, Name = "Jane Smith", Age = 16, Grade = 10 },
            new StudentResponseDTO { ID = 3, Name = "Michael Johnson", Age = 19, Grade = 8 },
            new StudentResponseDTO { ID = 4, Name = "Sarah Wilson", Age = 17, Grade = 11 },
            new StudentResponseDTO { ID = 5, Name = "David Brown", Age = 20, Grade = 7 }
        };
    }
}
