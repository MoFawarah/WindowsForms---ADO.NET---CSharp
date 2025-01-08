using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_DAL.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Default value to avoid nulls
        public int Age { get; set; }
        public decimal Grade { get; set; }

        public StudentDTO()
        {

        }

        public StudentDTO(int Id, string name, int age, decimal grade)
        {
            this.Id = Id;
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
    }
}
