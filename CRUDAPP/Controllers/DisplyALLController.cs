using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace CRUDAPP.Controllers
{
	public class DisplyALLController : Controller
	{
		EmployyeDB dbobj=new EmployyeDB();
		public IActionResult AllProfiles(Employee obj)
		{
			List<Employee> getlist = dbobj.GetEmployeeList(obj);
			return View(getlist);
		}
	}
}
