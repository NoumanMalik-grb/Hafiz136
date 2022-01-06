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
    public class CourseController : Controller
    {
        private readonly DataBaseconnection _context;

        public CourseController(DataBaseconnection data)
        {
            _context = data;
        }
        
        public ActionResult Index()
        {
            var k = _context.courses.ToList();
            return View(k);
        }

       
        public ActionResult Details(int? id)
        {
            var k = _context.courses.FirstOrDefault(k => k.Id == id);
            return View(k);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
      
        public ActionResult Create(Course course)
        {
            _context.courses.Add(course);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


       
        public ActionResult Edit(int? id)
        {
            var k = _context.courses.Find(id);
            return View(k);
        }

       
        [HttpPost]
        
        public ActionResult Edit(int id, Course course)
        {
            _context.Update(course);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

      
        public ActionResult Delete(int? id)
        {
            var k = _context.courses.FirstOrDefault(k => k.Id == id);
            return View(k);
           
        }

      
        [HttpPost]
       
        public ActionResult Delete(int id, Course course)
        {
            _context.Remove(course);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
