using CrudOperations.Models;

namespace CrudOperations.DataSimulation
{
    public class StudentDataSimulation
    {
        public static readonly List<StudentResponseDTO> StudentsList = new List<StudentResponseDTO>
        {
            new StudentResponseDTO { ID = 1, Name = "Ratib", Age = 18, Grade = 50 },
            new StudentResponseDTO { ID = 2, Name = "Jane Smith", Age = 16, Grade = 49 },
            new StudentResponseDTO { ID = 3, Name = "Michael Johnson", Age = 19, Grade = 77 },
            new StudentResponseDTO { ID = 4, Name = "Sarah Wilson", Age = 17, Grade = 99 },
            new StudentResponseDTO { ID = 5, Name = "David Brown", Age = 20, Grade = 36 }
        };
    }
}
