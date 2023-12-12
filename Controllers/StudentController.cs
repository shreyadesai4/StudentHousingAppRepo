using Microsoft.AspNetCore.Mvc;
using StudentHousingApp.Models;
using StudentHousingApp.Data;
using System.Linq;

namespace StudentHousingApp.Controllers
{
	public class StudentController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StudentController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult StudentIndex()
		{
			var allStudents = _context.Students.ToList();
			return View(allStudents);
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
			if (ModelState.IsValid)
			{
				var existingStudent = _context.Students.FirstOrDefault(s => s.Email == student.Email);

				if (existingStudent == null)
				{
					_context.Students.Add(student);
					_context.SaveChanges();
					return RedirectToAction("StudentDetails", new { id = student.StudentID });
				}

				ModelState.AddModelError(string.Empty, "A student with this email already exists");
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
				var authenticatedStudent = _context.Students.FirstOrDefault(s =>
					s.Email == student.Email && s.Password == student.Password);

				if (authenticatedStudent != null)
				{
					return RedirectToAction("StudentDetails", new { id = authenticatedStudent.StudentID });
				}

				ModelState.AddModelError(string.Empty, "Invalid email or password");
			}

			return View(student);
		}

		[HttpGet]
		public IActionResult StudentDetails(int id)
		{
			var student = _context.Students.FirstOrDefault(s => s.StudentID == id);

			if (student != null)
			{
				return View(student);
			}

			return NotFound();
		}
	}
}
