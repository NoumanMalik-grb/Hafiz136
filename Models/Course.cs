using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hafiz136.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public String cou_Name { get; set; }
        public String  couCode { get; set; }
    }
}
