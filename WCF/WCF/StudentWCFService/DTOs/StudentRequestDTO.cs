using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentWCFService.DTOs
{
    public class StudentRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public decimal Grade { get; set; }
    }
}