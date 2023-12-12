using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentHousingApp.Models;
using StudentHousingApp.Data;
using System.Linq;

public class PropertyController : Controller
{
	private readonly ApplicationDbContext _context;

	public PropertyController(ApplicationDbContext context)
	{
		_context = context;
	}

	public IActionResult PropertyIndex()
	{
		var allProperties = _context.Properties.ToList();
		return View(allProperties);
	}

	public IActionResult PropertyDetails(int id)
	{
		var property = _context.Properties.FirstOrDefault(p => p.PropertyID == id);

		if (property == null)
		{
			return NotFound();
		}

		return View(property);
	}

	[HttpGet]
	public IActionResult PropertyCreate()
	{
		var newProperty = new Property();
		return View(newProperty);
	}

	[HttpPost]
	public IActionResult PropertyCreate(Property property)
	{
		if (ModelState.IsValid)
		{
			_context.Properties.Add(property);
			_context.SaveChanges();

			return RedirectToAction("PropertyIndex");
		}

		return View(property);
	}
}
