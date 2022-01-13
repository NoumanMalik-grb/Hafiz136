using Hafiz136.Database;
using Hafiz136.Models;
using Hafiz136.ViewMOdel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hafiz136.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataBaseconnection _context;
        private readonly IWebHostEnvironment _webHost;

        public StudentController(DataBaseconnection baseconnection, IWebHostEnvironment webHost)
        {
            _context = baseconnection;
            _webHost = webHost;
        }
        public ActionResult Index()
        {
            var k = _context.students.ToList();
            return View(k);
        }

        
        public ActionResult Details(int? id)
        {
            var k = _context.students.FirstOrDefault(k => k.Id == id);
            return View(k);
        }

       
        public ActionResult Create()
        {
            return View();
        }       
        [HttpPost]      
        public ActionResult Create(int id,UploadStudentImage model )
        {
            string uploadfile = uploadimg(model);
            var student = new Student
            {
                Stu_Name=model.Stu_Name,
                Stu_Cell=model.Stu_Cell,
                Student_Picture=uploadfile,
                Email=model.Email
            };
            _context.students.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        //for upload image
        private string uploadimg(UploadStudentImage model)
        {
            string uploadfile = null;
            if (model.Student_Picture!=null)
            {
                var upload = Path.Combine(_webHost.WebRootPath, "Projectimg");
                uploadfile = Guid.NewGuid().ToString()
                + "-" + model.Student_Picture.FileName;
                string fileroote = Path.Combine(upload, uploadfile);
                using (var filestream = new FileStream(fileroote, FileMode.Create))
                {
                    model.Student_Picture.CopyToAsync(filestream);
                }
               
            }

            return uploadfile;
        }
        public ActionResult Edit(int id)
        {
            var k = _context.students.Find(id);
            return View(k);
        }

        [HttpPost]
     
        public ActionResult Edit(int id, Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
        public ActionResult Delete(int id)
        {
            var k = _context.students.FirstOrDefault(k => k.Id == id);
            return View(k);
        }

       
        [HttpPost]
       
        public ActionResult Delete(int id, Student student)
        {
            _context.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
