using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hafiz136.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public String Stu_Name { get; set; }
        public String  Stu_Cell { get; set; }
        public String Email { get; set; }
    }
}
