using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hafiz136.ViewMOdel
{
    public class UploadStudentImage
    {
        [Required]
        public String Stu_Name { get; set; }
        [Required]
        public String Stu_Cell { get; set; }
        [Required]
        public IFormFile Student_Picture { get; set; }
        [Required]
        public String Email { get; set; }
    }
}
