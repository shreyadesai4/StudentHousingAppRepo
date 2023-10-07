using Microsoft.AspNetCore.Mvc;
using StudentHousingApp.Models;

namespace StudentHousingApp.Controllers
{

    public class StudentController : Controller
    {

        // database
        private static List<Student> students = new List<Student>
    {
        new Student { StudentID = 1, FirstName = "Rabia", LastName = "Sarpal", Email = "rabia@miss.com" },
        new Student { StudentID = 2, FirstName = "Shreya", LastName = "Desai", Email = "shreya@thane.com" },
        new Student { StudentID = 3, FirstName = "Harsh", LastName = "Rajmachikar", Email = "harsh@oakville.com" },
    };

        // basic views
        public IActionResult StudentIndex()
        {
            return View(students);
        }



        // login

        [HttpGet]
        public IActionResult StudentDelete(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult StudentDeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);

            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult StudentLogin()
        {
            var newStudent = new Student();
            return View(newStudent);
        }

        [HttpPost]
        public IActionResult StudentLogin(Student student)
        {
            if (ModelState.IsValid)
            {
                var authenticatedStudent = students.FirstOrDefault(s =>
                    s.Email == student.Email && s.Password == student.Password);

                if (authenticatedStudent != null)
                {
                    return RedirectToAction("StudentDetails", new { id = authenticatedStudent.StudentID });
                }

                ModelState.AddModelError(string.Empty, "Invalid email or password");
            }

            return View(student);
        }

    }

}


