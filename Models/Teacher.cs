using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hafiz136.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public String T_Name { get; set; }
        public String  T_Designation { get; set; }
        public String T_Cell { get; set; }
    }
}
