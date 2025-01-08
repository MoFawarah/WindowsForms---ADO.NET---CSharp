using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_DAL.DTOs
{
    public class StudentUpdateDTO
    {
        public string Name { get; set; } = string.Empty; // Default value to avoid nulls
        public int Age { get; set; }
        public decimal Grade { get; set; }
    }
}
