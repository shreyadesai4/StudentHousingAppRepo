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

        public IActionResult StudentDetails(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult StudentCreate()
        {
            var newStudent = new Student();
            return View(newStudent);
        }

        [HttpPost]
        public IActionResult StudentCreate(Student student)
        {
            if (true) // ModelState.IsValid)
            {

                int newStudentId = students.Max(s => s.StudentID) + 1;
                student.StudentID = newStudentId;
                students.Add(student);
                return RedirectToAction("StudentIndex");
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult StudentEdit(int id)
        {
            var student = students.FirstOrDefault(s => s.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        public IActionResult StudentEdit(int id, Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.StudentID == id);

            if (existingStudent == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Email = student.Email;
                return RedirectToAction("Index");
            }
            return View(student);
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
        public IActionResult StudentRegistration()
        {
            var newStudent = new Student();
            return View(newStudent);
        }

        [HttpPost]
        public IActionResult StudentRegistration(Student student)
        {
            if (true) // ModelState.IsValid)
            {
                int newStudentID = students.Max(s => s.StudentID) + 1;
                student.StudentID = newStudentID;
                students.Add(student);

                return RedirectToAction("StudentDetails", new { id = newStudentID });
            }

            return View(student);
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


