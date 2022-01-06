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
    public class TeacherController : Controller
    {
        private DataBaseconnection _data;

        public TeacherController(DataBaseconnection data)
        {
            _data = data;
        }
        public ActionResult Index()
        {
            var k = _data.teachers.ToList();
            return View(k);
        }

        
        public ActionResult Details(int? id)
        {
            var k = _data.teachers.FirstOrDefault(k => k.Id == id);
            return View(k);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
       
        public ActionResult Create(Teacher teacher)
        {
            _data.teachers.Add(teacher);
            _data.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
        public ActionResult Edit(int id)
        {
            var k = _data.teachers.Find(id);
            return View(k);
        }

       
        [HttpPost]
       
        public ActionResult Edit(int id, Teacher teacher)
        {
            _data.Update(teacher);
            _data.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
        public ActionResult Delete(int? id)
        {
            var k = _data.teachers.FirstOrDefault(k => k.Id == id);
            return View(k);
        }

       
        [HttpPost]
      
        public ActionResult Delete(int id, Teacher teacher)
        {
            _data.Remove(teacher);
            _data.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
