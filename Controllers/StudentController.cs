using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>{
            new Student {Id = 1, Name = "Gia Bao", Age = 18, Email = "Bao@gmail.com"},
            new Student {Id = 2, Name = "Gia Huy", Age = 23, Email = "Huy@gmail.com"}
        };

        // GET: /Student/Index
        public IActionResult Index()
        {
            return View(students);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Max(s => s.Id) + 1;
                students.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: /Student/Edit/{id}
        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Student/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.Email = updatedStudent.Email;
                return RedirectToAction(nameof(Index));
            }
            return View(updatedStudent);
        }

        // GET: /Student/Delete/{id}
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: /Student/Delete/{id}
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public IActionResult DeleteConfirmed(int id)
{
    var student = students.FirstOrDefault(s => s.Id == id);
    if (student != null)
    {
        students.Remove(student);
    }
    return RedirectToAction(nameof(Index));
}

    }
}
