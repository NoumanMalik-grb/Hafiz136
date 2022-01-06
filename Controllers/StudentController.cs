using Hafiz136.Database;
using Hafiz136.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafiz136.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataBaseconnection _context;

        public StudentController(DataBaseconnection baseconnection)
        {
            _context = baseconnection;
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
      
        public ActionResult Create(Student student)
        {
            _context.students.Add(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
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
